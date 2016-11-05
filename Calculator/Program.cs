using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            // Setup MEF for loading and searching the things were interested in.            
            InitializeMef();

            Console.WriteLine("Enter an expression in reverse polish notation; quit to stop.");
            Console.WriteLine("Each operator and constant should be seperated with spaces.");
            Console.Write("> ");

            var input = Console.ReadLine();

            while (input.Equals("quit", StringComparison.OrdinalIgnoreCase) == false)
            {
                try
                {
                    var infixNotation = new InfixVisitor();

                    var expression = ExpressionBuilder.CreateExpression(input);

                    infixNotation.Visit(expression);

                    Console.WriteLine(infixNotation.ToString() + " = " + expression.Eval());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.Write("> ");

                input = Console.ReadLine();
            }
        }

        internal static ExpressionContainer ExpressionContainerLib = new ExpressionContainer();

        private static void InitializeMef()
        {
            string pluginFolder = ConfigurationManager.AppSettings["pluginfolder"];

            if (String.IsNullOrWhiteSpace(pluginFolder))
            {
                return;
            }

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
          
            if (Directory.Exists(pluginFolder))
            {
                DirectoryCatalog dc = new DirectoryCatalog(pluginFolder);
                catalog.Catalogs.Add(dc);

                var fs = new FileSystemWatcher(pluginFolder, "*.dll");
                fs.Created += (_, __) => dc.Refresh();

                fs.EnableRaisingEvents = true;
            }

            CompositionContainer container = new CompositionContainer(catalog);
            // Pass in the ExpressionContainerLib instance, since this type has Import attributes.
            container.ComposeParts(ExpressionContainerLib);
        }
    }
}
