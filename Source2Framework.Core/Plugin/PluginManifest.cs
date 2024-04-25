namespace Source2Framework
{
    using CounterStrikeSharp.API.Core;

    public sealed partial class Plugin : BasePlugin
    {
        public override string ModuleName => "Source2Framework";

        public override string ModuleDescription => "Core plugin for the Source2Framework";

        public override string ModuleAuthor => "Nexd @ Eternar";

        public override string ModuleVersion => API.GetVersionString();
    }
}
