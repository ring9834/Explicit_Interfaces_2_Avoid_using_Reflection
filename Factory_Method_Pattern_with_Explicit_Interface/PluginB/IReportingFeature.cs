using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface.PluginB
{
    // Plugin B with different capabilities
    public interface IReportingFeature
    {
        void GenerateReport();
    }
}
