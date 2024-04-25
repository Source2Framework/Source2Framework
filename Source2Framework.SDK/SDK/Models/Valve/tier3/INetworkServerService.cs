namespace Source2Framework.Models
{
    using CounterStrikeSharp.API.Core;
    using CounterStrikeSharp.API.Modules.Memory;
    using CounterStrikeSharp.API;

    public class INetworkServerService : NativeObject
    {
        private readonly VirtualFunctionWithReturn<nint, nint> GetIGameServerFunc;

        public INetworkServerService() : base(NativeAPI.GetValveInterface(0, "NetworkServerService_001"))
        {
            this.GetIGameServerFunc = new VirtualFunctionWithReturn<nint, nint>(this.Handle, GameData.GetOffset("INetworkServerService_GetIGameServer"));
        }

        public INetworkGameServer GetIGameServer()
        {
            return new INetworkGameServer(this.GetIGameServerFunc.Invoke(this.Handle));
        }
    }
}