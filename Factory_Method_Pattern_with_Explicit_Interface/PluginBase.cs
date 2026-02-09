using Factory_Method_Pattern_with_Explicit_Interface.Interfaces;

namespace Factory_Method_Pattern_with_Explicit_Interface
{
    /// <summary>
    /// Base class that automatically registers plugins with the factory
    /// using explicit interface implementation
    /// </summary>
    public abstract class PluginBase : IPlugin, IPluginFactoryInternal
    {
        // Explicit implementation hides factory registration from plugin API
        IPlugin IPluginFactoryInternal.CreateInstance()
        {
            // Each plugin knows how to create itself - no reflection!
            return CreateConcreteInstance();
        }

        string IPluginFactoryInternal.PluginKey => Name;

        // Abstract method each plugin implements
        protected abstract IPlugin CreateConcreteInstance();

        // IPlugin members (to be implemented by derived classes)
        public abstract string Name { get; }
        public abstract void Execute();
    }
}
