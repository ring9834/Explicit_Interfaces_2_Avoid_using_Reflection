using Factory_Method_Pattern_with_Explicit_Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface.PluginB
{
    public class ReportGeneratorPlugin : PluginBase, IReportingFeature
    {
        public override string Name => "ReportGenerator";

        public override void Execute()
        {
            Console.WriteLine($"[{Name}] Generating reports...");
            Console.WriteLine($"[{Name}] Reports compiled successfully");
        }

        // IReportingFeature implementation
        public void GenerateReport()
        {
            Console.WriteLine($"[{Name}] Exporting detailed PDF report");
        }

        protected override IPlugin CreateConcreteInstance()
        {
            return new ReportGeneratorPlugin();
        }
    }
}
