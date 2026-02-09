using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface.Interfaces
{
    // Public factory interface
    public interface IPluginFactory
    {
        IPlugin CreatePlugin(string pluginName);
        IEnumerable<string> GetAvailablePlugins();
    }
}
