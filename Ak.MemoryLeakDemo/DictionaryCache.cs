using System.Collections.Generic;
using Ak.MemoryLeakDemo.ViewModels;

namespace Ak.MemoryLeakDemo
{
    public static class DictionaryCache
    {
        private static Dictionary<int, Logfile> _cache = new Dictionary<int, Logfile>();

        public static Dictionary<int, Logfile> Cache
        {
            get { return _cache; }
        }
    }
}