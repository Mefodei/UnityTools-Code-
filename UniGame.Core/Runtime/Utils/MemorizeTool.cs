﻿namespace UniGreenModules.UniCore.Runtime.Utils
{
    using System;
    using System.Collections.Generic;

    public class MemorizeTool
    {

        public static Func<TKey,TData> Create<TKey,TData>(Func<TKey,TData> factory, Action<TData> disposableAction = null) {

            var cache = new Dictionary<TKey,TData>(16);

            TData CacheMapFunc(TKey x)
            {
                if (cache.TryGetValue(x, out var value) == false || value == null) {
                    value    = factory(x);
                    cache[x] = value;
                }
                return value;
            }

            void ClearCache()
            {
                foreach (var data in cache) {
                    disposableAction?.Invoke(data.Value);
                }
                cache.Clear();
            }
            
#if UNITY_EDITOR
            //clean up cache if Assembly Reload
            UnityEditor.AssemblyReloadEvents.beforeAssemblyReload += ClearCache;
            UnityEditor.EditorApplication.playModeStateChanged += x => ClearCache();
#endif      
            return CacheMapFunc;

        }

    }
}
