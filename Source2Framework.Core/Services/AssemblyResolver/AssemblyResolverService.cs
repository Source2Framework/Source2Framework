namespace Source2Framework.Services.AssemblyResolver
{
    using System.Reflection;

    using CounterStrikeSharp.API.Core.Hosting;
    using CounterStrikeSharp.API.Core.Plugin;

    using Source2Framework.Models;

    public sealed partial class AssemblyResolverService : BaseService<AssemblyResolverService>
    {
        public required IScriptHostConfiguration? ScriptHostConfiguration;

        public AssemblyResolverService(ILogger<AssemblyResolverService> logger, IPluginContext pluginContext) : base(logger, pluginContext)
        {
            this.ScriptHostConfiguration = Reflection.GetFieldValue<IScriptHostConfiguration, PluginContext>(pluginContext as PluginContext, "_hostConfiguration");
        }

        public override void Initialize(bool hotReload)
        {
            AppDomain.CurrentDomain.AssemblyResolve += this.ResolveAssembly;
        }

        private Assembly ResolveAssembly(object? sender, ResolveEventArgs args)
        {
            if (args.Name.Equals("Source2Framework.SDK", StringComparison.OrdinalIgnoreCase))
            {
                return Assembly.LoadFrom($"{this.ScriptHostConfiguration?.SharedPath}/Source2Framework.SDK/Source2Framework.SDK.dll");
            }

            return null!;
        }

        public override void Shutdown(bool hotReload)
        {
            AppDomain.CurrentDomain.AssemblyResolve -= this.ResolveAssembly;
        }
    }
}
