using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Ak.MemoryLeakDemo.ViewModels;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    /// Interaction logic for Demo1Window.xaml
    /// </summary>
    public partial class Demo1Window : Window
    {

        public Demo1Window()
        {
            InitializeComponent();
            var logEntries = GenerateLogEntries(1000);
            LogFileGrid.ItemsSource = new ObservableCollection<Logfile>(logEntries);

            var app = Application.Current as App;

            app.LoggedIn += (s, e) =>
            {
                Title = "Demo 1 - LoggedIn";
                LogFileGrid.IsEnabled = true;
                this.Effect = null;
                this.Background = new SolidColorBrush(Colors.White);
            };

            app.LoggedOut += (s, e) =>
            {
                Title = "Demo 1 - LoggedOut";
                LogFileGrid.IsEnabled = false;
                var blur = new BlurEffect();
                blur.Radius = 10;
                this.Background = new SolidColorBrush(Colors.DarkGray);
                this.Effect = blur;
            };
        }

        #region commented

        void app_LoggedOut(object sender, EventArgs e)
        {
            Title = "Demo 1 - LoggedOut";
            LogFileGrid.IsEnabled = false;
            var blur = new BlurEffect();
            blur.Radius = 10;
            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;
        }

        void app_LoggedIn(object sender, EventArgs e)
        {
            Title = "Demo 1 - LoggedIn";
            LogFileGrid.IsEnabled = true;
            this.Effect = null;
            this.Background = new SolidColorBrush(Colors.White);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            var app = Application.Current as App;
            app.LoggedIn -= app_LoggedIn;
            app.LoggedOut -= app_LoggedOut;
        }
        #endregion

        private static IEnumerable<Logfile> GenerateLogEntries(int count)
        {
            var randomizer = new Random();
            for (var i = 0; i < count; i++)
            {
                var entry = new Logfile
                {
                    Id = i,
                    Path = System.IO.Path.GetRandomFileName(),
                    Size = randomizer.Next(50, 200)
                };
                yield return entry;
            }
        }
    }
}
