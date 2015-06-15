﻿namespace dotnetthoughts.CaptureItPlus
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public class PluginManager<T> : IDisposable
    {
        private T plugin;

        public IEnumerable<T> LoadFromAssembly(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (typeof(T).IsAssignableFrom(type) && !type.IsInterface)
                {
                    T result = (T)Activator.CreateInstance(type);
                    yield return result;
                }
            }
        }

        public object ExecutePlugin(string pluginName, string methodName, object[] parameters)
        {
            if (plugin == null)
            {
                plugin = (T)Activator.CreateInstance(Type.GetType(pluginName));
            }
            return plugin.GetType().GetMethod(methodName).Invoke(plugin, parameters);
        }

        public void Dispose()
        {
            plugin = default(T);
        }
    }
}
