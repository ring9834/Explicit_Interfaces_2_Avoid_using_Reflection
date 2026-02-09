using Factory_Method_Pattern_with_Explicit_Interface.PluginA;
using Factory_Method_Pattern_with_Explicit_Interface.PluginB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Plugin System WITHOUT Reflection ===");
            Console.WriteLine("Using Explicit Interfaces for Compile-Time Safety\n");

            // ===== DEMO 1: Compile-Time Factory =====
            Console.WriteLine("\n1. COMPILE-TIME FACTORY:");
            Console.WriteLine(new string('=', 30));

            var compileTimeFactory = new CompileTimePluginFactory();

            Console.WriteLine("\nAvailable plugins:");
            foreach (var plugin in compileTimeFactory.GetAvailablePlugins())
            {
                Console.WriteLine($"  - {plugin}");
            }

            // Create and use plugins
            var dataPlugin = compileTimeFactory.CreatePlugin("DataProcessor");
            dataPlugin.Execute();

            // Access specific interface
            var reportPlugin = compileTimeFactory.CreatePlugin("ReportGenerator");
            if (reportPlugin is IReportingFeature reporting)
            {
                reporting.GenerateReport();
            }
        }
    }
}
