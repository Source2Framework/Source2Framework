namespace Source2Framework.Models
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;

    using System.Runtime.InteropServices;

    public unsafe class INetworkSystem : NativeObject
    {
        private delegate nint CNetworkSystem_UpdatePublicIp(nint a1);

        private CNetworkSystem_UpdatePublicIp UpdatePublicIpInternal;

        public INetworkSystem() : base(NativeAPI.GetValveInterface(0, "NetworkSystemVersion001"))
        {
            this.UpdatePublicIpInternal = Marshal.GetDelegateForFunctionPointer<CNetworkSystem_UpdatePublicIp>(*(nint*)(*(nint*)(this.Handle) + 0x100));
        }

        public byte* UpdatePublicIp()
        {
            return (byte*)(this.UpdatePublicIpInternal.Invoke(this.Handle) + 0x4);
        }

        public string GetAddress()
        {
            byte* ip = this.UpdatePublicIp();
            return $"{ip[0]}.{ip[1]}.{ip[2]}.{ip[3]}";
        }
    }
}
