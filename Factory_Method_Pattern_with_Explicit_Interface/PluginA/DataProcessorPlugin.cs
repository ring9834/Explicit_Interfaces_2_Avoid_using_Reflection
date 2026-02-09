using Factory_Method_Pattern_with_Explicit_Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface.PluginA
{
    public class DataProcessorPlugin : PluginBase, IAdvancedFeature
    {
        public override string Name => "DataProcessor";

        public override void Execute()
        {
            Console.WriteLine($"[{Name}] Processing data...");
            Console.WriteLine($"[{Name}] Data validation complete");
        }

        // IAdvancedFeature implementation
        public void AdvancedOperation()
        {
            Console.WriteLine($"[{Name}] Performing advanced data analysis");
        }

        // Factory creation - knows its own type without reflection
        protected override IPlugin CreateConcreteInstance()
        {
            return new DataProcessorPlugin();
        }
    }
}
