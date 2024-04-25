namespace Source2Framework
{
    using System.Reflection;
    using Source2Framework.Models;

    public static class API
    {
        /// <summary>
        /// Returns the version of Source2Framework SDK running on the server
        /// </summary>
        /// <returns></returns>
        public static int GetVersion()
        {
            return Assembly.GetAssembly(typeof(IS2FModule))!.GetName().Version!.Build;
        }

        /// <summary>
        /// Returns the assembly version of Source2Framework running on the server as a string including git commit hash
        /// </summary>
        /// <example>1.0.0+9d8b6be</example>
        public static string GetVersionString()
        {
            return Assembly.GetAssembly(typeof(IS2FModule))!.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
        }
    }
}
