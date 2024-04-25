namespace Source2Framework.Models
{
    using System.Reflection;

    /// <summary>
    /// Wrapper class for <see cref="System.Reflection"/>
    /// </summary>
    public static class Reflection
    {
        /// <summary>
        /// Gets a <see langword="static"/> field in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return">Field <see cref="Type"/></typeparam>
        /// <typeparam name="Class"><see langword="class"/> that contains the field</typeparam>
        /// <param name="field">Field name</param>
        /// <returns>Field value</returns>
        public static Return? GetFieldValue<Return, Class>(string field) where Class : class
            => GetFieldValue<Return, Class>(null, field);

        /// <summary>
        /// Gets a <see langword="static"/> property in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return">Property <see cref="Type"/></typeparam>
        /// <typeparam name="Class"><see langword="class"/> that contains the field</typeparam>
        /// <param name="property">Property name</param>
        /// <returns>Property value</returns>
        public static Return? GetPropertyValue<Return, Class>(string property) where Class : class
            => GetPropertyValue<Return, Class>(null, property);

        /// <summary>
        /// Sets a <see langword="static"/> field in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Class"><see langword="class"/> that contains the field</typeparam>
        /// <typeparam name="Value">Field <see cref="Type"/></typeparam>
        /// <param name="field">Field name</param>
        /// <param name="value">Value you want to set the field to</param>
        public static void SetFieldValue<Class, Value>(string field, Value value) where Class : class
            => SetFieldValue<Class, Value>(null, field, value);

        /// <summary>
        /// Sets a <see langword="static"/> property in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Class"><see langword="class"/> that contains the property</typeparam>
        /// <typeparam name="Value">Property <see cref="Type"/></typeparam>
        /// <param name="property">Property name</param>
        /// <param name="value">Value you want to set the property to</param>
        public static void SetPropertyValue<Class, Value>(string property, Value value) where Class : class
            => SetPropertyValue<Class, Value>(null, property, value);

        /// <summary>
        /// Invokes a <see langword="static"/> method from a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return">Method return <see cref="Type"/></typeparam>
        /// <typeparam name="Class"><see langword="class"/> that contains the method</typeparam>
        /// <param name="method">Method name you want to invoke</param>
        /// <param name="args">method arguments</param>
        /// <returns><typeparamref name="Return"/> from the method</returns>
        public static Return? Invoke<Return, Class>(string method, params object[] args) where Class : class
            => Invoke<Return, Class>(null, method, args);

        /// <summary>
        /// Invokes a <see langword="static"/> method that returns <see langword="void"/> from a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Class"><see langword="class"/> that contains the method</typeparam>
        /// <param name="method">Method name you want to invoke.</param>
        /// <param name="args">method arguments.</param>
        public static void InvokeVoid<Class>(string method, params object[] args) where Class : class
            => InvokeVoid<Class>(null, method, args);

        /// <summary>
        /// Invokes a <see langword="static"/> method from a hidden class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return"> Method return <see cref="Type"/></typeparam>
        /// <param name="assembly">Assembly where the class (and method..) is located.</param>
        /// <param name="class">Name of the hidden class</param>
        /// <param name="method">Name of the method within the hidden class.</param>
        /// <returns><typeparamref name="Return"/> returned from the method.</returns>
        public static Return? InvokeInternal<Return>(Assembly assembly, string @class, string method)
            => InvokeInternal<Return>(assembly, @class, method, null);

        /// <summary>
        /// Invokes a <see langword="static"/> method that returns <see langword="void"/> in the given <see cref="Assembly"/> from a hidden class that is unavailable due to its protection level.
        /// </summary>
        /// <param name="assembly">Assembly where the class (and method..) is located.</param>
        /// <param name="class">Name of the hidden class</param>
        /// <param name="method">Name of the method within the hidden class.</param>
        public static void InvokeInternalVoid(Assembly assembly, string @class, string method)
            => InvokeInternalVoid(assembly, @class, method, null);

        /// <summary>
        /// Gets a <see langword="static"/> or instance field in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return">Field <see cref="Type"/></typeparam>
        /// <typeparam name="Class"><see langword="class"/> that contains the field</typeparam>
        /// <param name="pThis">Instance, or <see langword="null"/> if <see langword="static"/></param>
        /// <param name="field">Field name</param>
        /// <returns>Field value</returns>
        public static Return? GetFieldValue<Return, Class>(Class? pThis, string field)
            where Class : class
        {
            FieldInfo? info = typeof(Class).GetField(field, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            return (Return?)info?.GetValue(pThis);
        }

        /// <summary>
        /// Gets a <see langword="static"/> or instance property in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return">Property <see cref="Type"/></typeparam>
        /// <typeparam name="Class"><see langword="class"/> that contains the field</typeparam>
        /// <param name="pThis">Instance, or <see langword="null"/> if <see langword="static"/></param>
        /// <param name="property">Property name</param>
        /// <returns>Property value</returns>
        public static Return? GetPropertyValue<Return, Class>(Class? pThis, string property)
            where Class : class
        {
            PropertyInfo? info = typeof(Class).GetProperty(property, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            return (Return)info?.GetValue(pThis)!;
        }

        /// <summary>
        /// Sets a <see langword="static"/> or instance field in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Class"><see langword="class"/> that contains the field</typeparam>
        /// <typeparam name="Value">Field <see cref="Type"/></typeparam>
        /// <param name="pThis">Instance, or <see langword="null"/> if <see langword="static"/></param>
        /// <param name="field">Field name</param>
        /// <param name="value">Value you want to set the field to</param>
        public static void SetFieldValue<Class, Value>(Class? pThis, string field, Value value)
            where Class : class
        {
            FieldInfo? info = typeof(Class).GetField(field, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            info?.SetValue(pThis, value);
        }

        /// <summary>
        /// Sets a <see langword="static"/> or instance property in a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Class"><see langword="class"/> that contains the property</typeparam>
        /// <typeparam name="Value">Property <see cref="Type"/></typeparam>
        /// <param name="pThis">Instance, or <see langword="null"/> if <see langword="static"/></param>
        /// <param name="property">Property name</param>
        /// <param name="value">Value you want to set the property to</param>
        public static void SetPropertyValue<Class, Value>(Class? pThis, string property, Value value)
            where Class : class
        {
            PropertyInfo? info = typeof(Class).GetProperty(property, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            info?.SetValue(pThis, value);
        }

        /// <summary>
        /// Invokes a <see langword="static"/> or instance method from a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return">Method return <see cref="Type"/></typeparam>
        /// <typeparam name="Class"><see langword="class"/> that contains the method</typeparam>
        /// <param name="pThis">Instance, or <see langword="null"/> if <see langword="static"/> method</param>
        /// <param name="method">Method name you want to invoke</param>
        /// <param name="args">method arguments</param>
        /// <returns><typeparamref name="Return"/> from the method</returns>
        public static Return? Invoke<Return, Class>(Class? pThis, string method, params object[] args)
            where Class : class
        {
            MethodInfo? targetMethod = typeof(Class).GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            return (Return?)targetMethod?.Invoke(pThis, args);
        }

        /// <summary>
        /// Invokes a <see langword="static"/> or instance method that returns <see langword="void"/> from a class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Class"><see langword="class"/> that contains the method</typeparam>
        /// <param name="pThis">Instance, or <see langword="null"/> if <see langword="static"/> method</param>
        /// <param name="method">Method name you want to invoke.</param>
        /// <param name="args">method arguments.</param>
        public static void InvokeVoid<Class>(Class? pThis, string method, params object[] args) where Class : class
        {
            MethodInfo? targetMethod = typeof(Class).GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            targetMethod?.Invoke(pThis, args);
        }

        /// <summary>
        /// Invokes a <see langword="static"/> method from a hidden class that is unavailable due to its protection level.
        /// </summary>
        /// <typeparam name="Return"> Method return <see cref="Type"/></typeparam>
        /// <param name="assembly">Assembly where the class (and method..) is located.</param>
        /// <param name="class">Name of the hidden class</param>
        /// <param name="method">Name of the method within the hidden class.</param>
        /// <param name="args">Method arguments.</param>
        /// <returns><typeparamref name="Return"/> returned from the method.</returns>
        public static Return? InvokeInternal<Return>(Assembly assembly, string @class, string method, params object[]? args)
        {
            Type? versionType = assembly.GetType(@class);
            MethodInfo? methodInfo = versionType?.GetMethod(method);
            return (Return?)methodInfo?.Invoke(null, args);
        }

        /// <summary>
        /// Invokes a <see langword="static"/> method that returns <see langword="void"/> in the given <see cref="Assembly"/> from a hidden class that is unavailable due to its protection level.
        /// </summary>
        /// <param name="assembly">Assembly where the class (and method..) is located.</param>
        /// <param name="class">Name of the hidden class</param>
        /// <param name="method">Name of the method within the hidden class.</param>
        /// <param name="args">Method arguments.</param>
        public static void InvokeInternalVoid(Assembly assembly, string @class, string method, params object[]? args)
        {
            Type? versionType = assembly.GetType(@class);
            MethodInfo? methodInfo = versionType?.GetMethod(method);
            methodInfo?.Invoke(null, args);
        }

        /// <summary>
        /// Gets <see cref="Assembly"/> from the current <see cref="AppDomain"/> by name.
        /// </summary>
        /// <param name="name"><see cref="Assembly"/> name that you want to get.</param>
        /// <returns><see cref="Assembly"/> if found, otherwise <see langword="null"/></returns>
        public static Assembly? GetAssembly(string name)
            => AppDomain.CurrentDomain.GetAssemblies().ToList().Find(x => x.GetName().Name == name);

        /// <summary>
        /// Finds every <see cref="Type"/> in the given <see cref="Assembly"/> that derives from the given <see cref="Type"/>
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/> where the <see cref="Type"/> is located</param>
        /// <param name="baseType"><see cref="Type"/> of the <see langword="class"/> that is derived from</param>
        /// <returns>Collection of <see cref="Type"/> that inherits from the given <see cref="Type"/>.</returns>
        public static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
            => assembly.GetTypes().Where(baseType.IsSubclassOf);

        /// <summary>
        /// Finds the first <see cref="Type"/> in the given <see cref="Assembly"/> that derives from the given <see cref="Type"/>
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/> where the <see cref="Type"/> is located</param>
        /// <param name="baseType"><see cref="Type"/> of the <see langword="class"/> that is derived from</param>
        /// <returns><see cref="Type"/> that inherits from the given <see cref="Type"/>.</returns>
        public static Type FindDerivedType(Assembly assembly, Type baseType)
            => FindDerivedTypes(assembly, baseType).First();
    }
}
