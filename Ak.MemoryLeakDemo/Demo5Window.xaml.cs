using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using MuPDFLib;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///     Interaction logic for Demo5Window.xaml
    /// </summary>
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