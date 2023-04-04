// --------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 - 2023 André Krämer https://www.andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using Ak.MemoryLeakDemo.ViewModels;
using System.Windows;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logfile _logfile;
        private string _path = @"c:\temp\file1.log";

        public MainWindow()
        {
            InitializeComponent();

            _logfile = new Logfile
            {
                Id = 1,
                Size = 1,
                Path = _path,
                Content = new byte[1024]
            };

        }

        private void Demo1_Click(object sender, RoutedEventArgs e)
        {
            var view = new Demo1Window();
            view.Show();
        }


        private void Demo2_Click(object sender, RoutedEventArgs e)
        {
            var view = new Demo2Window();
            view.Show();
        }


        private void Demo3_Click(object sender, RoutedEventArgs e)
        {
            var view = new Demo3Window();
            view.Show();
        }


        private void Demo4_Click(object sender, RoutedEventArgs e)
        {
            var view = new Demo4Window();
            view.Show();
        }


        private void Demo5_Click(object sender, RoutedEventArgs e)
        {
            var view = new Demo5Window();
            view.Show();
        }

        private void UrlButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.andrekraemer.de");
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((App) Application.Current).Login();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ((App) Application.Current).Logout();
        }
    }
}