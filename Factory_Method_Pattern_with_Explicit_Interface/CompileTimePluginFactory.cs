using Factory_Method_Pattern_with_Explicit_Interface.Interfaces;
using Factory_Method_Pattern_with_Explicit_Interface.PluginA;
using Factory_Method_Pattern_with_Explicit_Interface.PluginB;
using Factory_Method_Pattern_with_Explicit_Interface.PluginC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method_Pattern_with_Explicit_Interface
{
    /// <summary>
    /// Factory that knows all plugins at compile time
    /// Uses explicit interfaces for registration
    /// </summary>
    public class CompileTimePluginFactory : IPluginFactory
    {
        // Registry of known plugins - populated at construction
        private readonly Dictionary<string, IPluginFactoryInternal> _pluginRegistry;

        public CompileTimePluginFactory()
        {
            _pluginRegistry = new Dictionary<string, IPluginFactoryInternal>();

            // MANUAL REGISTRATION - compile-time safe!
            // No reflection, just create instances and register them
            RegisterPlugin(new DataProcessorPlugin());
            RegisterPlugin(new ReportGeneratorPlugin());
            RegisterPlugin(new FullSuitePlugin());
        }

        private void RegisterPlugin(PluginBase plugin)
        {
            // Use explicit interface to get factory capabilities
            var factoryPlugin = (IPluginFactoryInternal)plugin;
            _pluginRegistry[factoryPlugin.PluginKey] = factoryPlugin;
            Console.WriteLine($"Registered plugin: {factoryPlugin.PluginKey}");
        }

        public IPlugin CreatePlugin(string pluginName)
        {
            if (!_pluginRegistry.TryGetValue(pluginName, out var factory))
            {
                throw new ArgumentException($"Plugin '{pluginName}' not found. Available: {string.Join(", ", GetAvailablePlugins())}");
            }

            // Create instance using explicit interface - NO REFLECTION!
            return factory.CreateInstance();
        }

        public IEnumerable<string> GetAvailablePlugins()
        {
            return _pluginRegistry.Keys;
        }

        // Advanced: Create with specific interface type
        public T CreatePlugin<T>(string pluginName) where T : class
        {
            var plugin = CreatePlugin(pluginName);

            if (plugin is T typedPlugin)
                return typedPlugin;

            throw new InvalidOperationException($"Plugin '{pluginName}' does not implement {typeof(T).Name}");
        }
    }
}
