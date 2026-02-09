using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface.Interfaces
{
    // Factory registration interface (hidden from consumers)
    internal interface IPluginFactoryInternal
    {
        IPlugin CreateInstance();
        string PluginKey { get; }
    }
}
