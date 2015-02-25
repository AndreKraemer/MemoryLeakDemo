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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((App) Application.Current).Login();

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Logout();

        }


    }
}
