using Factory_Method_Pattern_with_Explicit_Interface.Interfaces;
using Factory_Method_Pattern_with_Explicit_Interface.PluginA;
using Factory_Method_Pattern_with_Explicit_Interface.PluginB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface.PluginC
{
    // Plugin C with both capabilities
    public class FullSuitePlugin : PluginBase, IAdvancedFeature, IReportingFeature
    {
        public override string Name => "FullSuite";

        public override void Execute()
        {
            Console.WriteLine($"[{Name}] Running full suite...");
            AdvancedOperation();
            GenerateReport();
        }

        public void AdvancedOperation()
        {
            Console.WriteLine($"[{Name}] Machine learning analysis");
        }

        public void GenerateReport()
        {
            Console.WriteLine($"[{Name}] Interactive dashboard generated");
        }

        protected override IPlugin CreateConcreteInstance()
        {
            return new FullSuitePlugin();
        }
    }
}
