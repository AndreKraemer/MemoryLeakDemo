using System;
using System.Collections.Generic;
using System.Linq;
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
using Ak.MemoryLeakDemo.Views;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    /// Interaction logic for Demo4Window.xaml
    /// </summary>
    public partial class Demo4Window : Window
    {
        private int _clicks = 0;
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
