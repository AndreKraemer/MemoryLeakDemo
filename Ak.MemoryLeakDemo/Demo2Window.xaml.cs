using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ak.MemoryLeakDemo.ViewModels;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    /// Interaction logic for Demo2Window.xaml
    /// </summary>
    public partial class Demo2Window : Window
    {
        private static int _lastCacheKey = 0;
        private static ObjectCache _cache = null;
        private static Random _randomizer = new Random();
        public Demo2Window()
        {
            InitializeComponent();
        }

        private void DictionaryCacheButton_Click(object sender, RoutedEventArgs e)
        {
           
            var offset = 0;
            if (DictionaryCache.Cache.Count > 0)
            {
                offset = DictionaryCache.Cache.Last().Key + 1;
            }
            for (int i = 0; i < 1000; i++)
            {
                var entry = GenerateLogfile(i);
                DictionaryCache.Cache.Add(offset + i, entry);
            }
            Label1.Content = string.Format("{0} Dateien im Cache", DictionaryCache.Cache.Count);
        }

        private static Logfile GenerateLogfile(int id)
        {
            
            var entry = new Logfile
            {
                Id = id,
                Path = System.IO.Path.GetRandomFileName(),
                Size = _randomizer.Next(50, 200)
            };
            return entry;
        }

        #region Hidden
        private ObjectCache MemoryCache
        {
            get
            {
                if (_cache == null)
                {
                    var config = new NameValueCollection
                    {
                        {"pollingInterval", "00:00:02"},
                        {"physicalMemoryLimitPercentage", "20"},
                        {"cacheMemoryLimitMegabytes", "35"}
                    };

                    //instantiate cache
                    _cache = new MemoryCache("CustomCache", config);
                }
                return _cache;
            }
        }



        private void RealCacheButton_Click(object sender, RoutedEventArgs e)
        {
            var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(30) };
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
