using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroInjector
{
    public static class Extension
    {
        public static void RegisterSingleton(this object target, string named)
        {
            InjectorManager.RegisterSingleton<object>(named, target);
        }

        public static void RegisterScoped(this object target, string named)
        {
            InjectorManager.RegisterScoped<object>(named, target);
        }
    }
}
