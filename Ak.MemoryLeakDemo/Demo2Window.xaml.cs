// --------------------------------------------------------------------------------------
// <copyright file="Demo2Window.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Windows;
using Ak.MemoryLeakDemo.ViewModels;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///     This Demo shows how memory can grow by using a static dictionary as
    ///     a cache
    /// </summary>
    public partial class Demo2Window : Window
    {
        private static int _lastCacheKey;
        private static ObjectCache _cache;
        private static readonly Random Randomizer = new Random();

        public Demo2Window()
        {
            InitializeComponent();
        }

        private void DictionaryCacheButton_Click(object sender, RoutedEventArgs e)
        {
            int offset = 0;
            if (DictionaryCache.Cache.Count > 0)
            {
                offset = DictionaryCache.Cache.Last().Key + 1;
            }
            for (int i = 0; i < 1000; i++)
            {
                Logfile entry = GenerateLogfile(i);
                DictionaryCache.Cache.Add(offset + i, entry);
            }
            Label1.Content = string.Format("{0} Dateien im Cache", DictionaryCache.Cache.Count);
        }

        private static Logfile GenerateLogfile(int id)
        {
            var entry = new Logfile
            {
                Id = id,
                Path = Path.GetRandomFileName(),
                Size = Randomizer.Next(50, 200)
            };
            return entry;
        }

        #region Better Solution
        // using a proper Cache helps because items get removed if you
        // are running out of memory
        private ObjectCache MemoryCache
        {
            get
            {
                if (_cache == null)
                {
                    // Those values are just for demo purposes
                    // in a real application you should set them
                    // to values that suit your needs
                    // for example the pollingInterval should be a bit higher
                    var config = new NameValueCollection
                    {
                        {"pollingInterval", "00:00:02"},
                        {"physicalMemoryLimitPercentage", "20"},
                        {"cacheMemoryLimitMegabytes", "120"}
                    };

                    //instantiate cache
                    _cache = new MemoryCache("CustomCache", config);
                }
                return _cache;
            }
        }

        private void RealCacheButton_Click(object sender, RoutedEventArgs e)
        {
            var policy = new CacheItemPolicy {SlidingExpiration = TimeSpan.FromMinutes(30)};
            for (int i = 0; i < 1000; i++)
            {
                _lastCacheKey++;
                MemoryCache.Add(_lastCacheKey.ToString(), GenerateLogfile(i), policy);
            }

            Label2.Content = string.Format("{0} Dateien im Cache", MemoryCache.GetCount());
        }

        #endregion
    }
}