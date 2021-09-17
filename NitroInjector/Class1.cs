using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroInjector
{
    public static class NitroInjectorManager
    {
        private static Dictionary<String, object> singletonInstanceMapper = new Dictionary<string, object>();
        private static Dictionary<String, string> scopedInstanceMapper = new Dictionary<string, string>();
        public static void RegisterSingleton<T>(string named)
        {
            if (singletonInstanceMapper.ContainsKey(named)) throw new Exception("instance is already exists");
            singletonInstanceMapper.Add(named, (T)Activator.CreateInstance(typeof(T)));
        }
        public static void RegisterScoped<T>(string named)
        {
            if (scopedInstanceMapper.ContainsKey(named)) throw new Exception("instance is already exists");
            scopedInstanceMapper.Add(named, typeof(T).FullName);
        }
        private static object CreateScopedInstance(string named)
        {
            if (!scopedInstanceMapper.ContainsKey(named)) throw new Exception("instance not in register scope");

            if (!string.IsNullOrEmpty(scopedInstanceMapper[named]))
            {
                Type type = Type.GetType(scopedInstanceMapper[named]);
                return Activator.CreateInstance(type);
            }

            throw new Exception("instance wrong");
        }
        public static object GetInstance(string named)
        {
            if (singletonInstanceMapper.ContainsKey(named)) return singletonInstanceMapper[named];
            if (scopedInstanceMapper.ContainsKey(named)) return CreateScopedInstance(named);
            return null;
        }
    }
}
