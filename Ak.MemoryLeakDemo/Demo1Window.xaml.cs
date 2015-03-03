// --------------------------------------------------------------------------------------
// <copyright file="Demo1Window.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
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
    /// Open this Window several time and close it again. With the current implementation
    /// it will remain in memory
    /// </summary>
    public partial class Demo1Window : Window
    {

        public Demo1Window()
        {
            InitializeComponent();
            var logEntries = GenerateLogEntries(1000);
            LogFileGrid.ItemsSource = new ObservableCollection<Logfile>(logEntries);

            var app = Application.Current as App;

            app.LoggedIn += (sender, e) =>
            {
                Title = "Demo 1 - LoggedIn";
                LogFileGrid.IsEnabled = true;
                this.Effect = null;
                this.Background = new SolidColorBrush(Colors.White);
            };

            app.LoggedOut += (sender, e) =>
            {
                Title = "Demo 1 - LoggedOut";
                LogFileGrid.IsEnabled = false;
                var blur = new BlurEffect();
                blur.Radius = 10;
                this.Background = new SolidColorBrush(Colors.DarkGray);
                this.Effect = blur;
            };
        }


        #region Solution
        // Extract to named methods from the anonymous event handlers like this

        //void app_LoggedOut(object sender, EventArgs e)
        //{
        //    Title = "Demo 1 - LoggedOut";
        //    LogFileGrid.IsEnabled = false;
        //    var blur = new BlurEffect();
        //    blur.Radius = 10;
        //    this.Background = new SolidColorBrush(Colors.DarkGray);
        //    this.Effect = blur;
        //}

        //void app_LoggedIn(object sender, EventArgs e)
        //{
        //    Title = "Demo 1 - LoggedIn";
        //    LogFileGrid.IsEnabled = true;
        //    this.Effect = null;
        //    this.Background = new SolidColorBrush(Colors.White);
        //}

        // Modify the constructor like this 
        // public void Demo1Window()
        //{
        // ...
        //    app.LoggedIn -= app_LoggedIn;
        //    app.LoggedOut -= app_LoggedOut;
        //}

        // override OnClosing and deregister the event listener
        //protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    var app = Application.Current as App;
        //    app.LoggedIn -= app_LoggedIn;
        //    app.LoggedOut -= app_LoggedOut;
        //}
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
