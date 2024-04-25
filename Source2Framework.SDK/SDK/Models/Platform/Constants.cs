namespace Source2Framework
{
    using System.Runtime.InteropServices;

    public static partial class Constants
    {
        public static readonly OSPlatform Platform = SDK.GetOperatingSystem();

        public static readonly bool IsWindows = Platform == OSPlatform.Windows;

        public static readonly bool IsLinux = Platform == OSPlatform.Linux;
    }
}
