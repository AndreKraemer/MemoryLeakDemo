using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
using Ak.MemoryLeakDemo.Models;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    /// Interaction logic for Demo3Window.xaml
    /// </summary>
    public partial class Demo3Window : Window
    {
        public Demo3Window()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {

            var serializerCount = 0;
            int.TryParse(SerializerCount.Text, out serializerCount);

            for (var i = 1; i <= serializerCount; i++)
            {
                makeSerializer();
            }

            int totalCreated = Convert.ToInt32(GeneratedSerializerCount.Content);
            totalCreated += serializerCount;
            GeneratedSerializerCount.Content = totalCreated.ToString();
        }

        private void makeSerializer()
        {
    
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherInfo), new XmlRootAttribute("Current"));
            WeatherInfo info;

            using (XmlReader reader = XmlReader.Create(Directory.GetCurrentDirectory() + "/App_Data/weather.xml"))
            {
                info = (WeatherInfo)serializer.Deserialize(reader);
            }
        }
    }
}
