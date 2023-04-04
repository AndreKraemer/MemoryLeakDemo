// --------------------------------------------------------------------------------------
// <copyright file="Demo4Window.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 - 2023 André Krämer https://www.andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System.Windows;
using System.Windows.Controls;
using Ak.MemoryLeakDemo.ViewModels;
using Ak.MemoryLeakDemo.Views;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///     Have a look at Demo4View1ViewModel for the problem description and the solution
    /// </summary>
    public partial class Demo4Window : Window
    {
        private int _clicks;

        public Demo4Window()
        {
            InitializeComponent();
        }

        private void ChangeViewModel_Click(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();

            UserControl view = _clicks%2 == 0
                ? (UserControl) new Demo4View1 {DataContext = new Demo4View1ViewModel()}
                : new Demo4View2 {DataContext = new Demo4View2ViewModel()};

            ContentGrid.Children.Add(view);
            _clicks++;
        }
    }
}