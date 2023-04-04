// --------------------------------------------------------------------------------------
// <copyright file="Demo5Window.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 - 2023 André Krämer https://www.andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using MuPDFLib;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///     Instruction: Open some of the pdf files from the app_data directory
    ///     Solution: Have a look at MuPDF.cs in the MuPDF projecct
    /// </summary>
#region solution
            // This demo shows an issue caused by blocking Finalizers. In order to demonstrate this, the
            // implementation of IDisposable was commented out and the finalizer was modified.
            // In order to Block the finalizer, a thread.sleep was introduced in the "fake" logging library.
            // So in order to solve that issue: Delete the thread.sleep and implement IDisposable for MuPDF
#endregion
    public partial class Demo5Window : Window
    {
        private static BitmapSource[] _bitmaps = new BitmapSource[0];
        private int _currentPage;
        private int _pageCount;

        public Demo5Window()
        {
            InitializeComponent();
        }

        private void LoadPdf(string pdfFilename)
        {
            FileNameLabel.Content = pdfFilename;
            var muPdf = new MuPDF(pdfFilename, "");
            _pageCount = muPdf.PageCount;
            Array.Resize(ref _bitmaps, _pageCount);
            for (var page = 1; page <= _pageCount; page++)
            {
                var pdfPage = new MuPDF(pdfFilename, "") {Page = page};
                _bitmaps[page - 1] = pdfPage.GetBitmapSource(450, 0, 300, 300, 0, RenderType.RGB, false, false, 10000000);
            }
            _currentPage = 1;
            
            UpdateImage();


        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "*.pdf|*.pdf"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                LoadPdf(openFileDialog.FileName);
            }
        }

        private void UpdateImage()
        {
            if (_currentPage > 0 && _currentPage <= _pageCount && _pageCount > 0)
            {
                Image1.Source = _bitmaps[_currentPage - 1];
            }
            PageNumberLabel.Content = _currentPage.ToString();
            PageCountLabel.Content = _pageCount.ToString();
            PrevButton.IsEnabled = _currentPage > 1;
            NextButton.IsEnabled = _pageCount > _currentPage;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            UpdateImage();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            UpdateImage();
        }
    }
}