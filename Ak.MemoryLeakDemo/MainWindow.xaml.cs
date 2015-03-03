// --------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System.Windows;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            System.Diagnostics.Process.Start("http://andrekraemer.de");
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