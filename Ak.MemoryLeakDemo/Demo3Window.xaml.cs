using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using Ak.MemoryLeakDemo.Models;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///     Interaction logic for Demo3Window.xaml
    /// </summary>
    public partial class Demo3Window : Window
    {
        public Demo3Window()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var serializerCount = Convert.ToInt32(SerializerCount.Text);

            for (var i = 0; i < serializerCount; i++)
            {
                MakeSerializer();
            }

            var totalCreated = Convert.ToInt32(GeneratedSerializerCount.Content);
            totalCreated += serializerCount;
            GeneratedSerializerCount.Content = totalCreated.ToString();
        }

        private void MakeSerializer()
        {
            var serializer = new XmlSerializer(typeof (WeatherInfo), new XmlRootAttribute("Current"));
            WeatherInfo info;

            using (XmlReader reader = XmlReader.Create(Directory.GetCurrentDirectory() + "/App_Data/weather.xml"))
            {
                info = (WeatherInfo) serializer.Deserialize(reader);
            }
        }

        #region Solution

        // Folgende Konstruktoren cachen die dynamische Assembly:
        // -XmlSerializer(type)  
        // -XmlSerializer(type, defaultNameSpace) 
        // Falls ein anderer Konstruktor benötigt wird, dann muss der erstellte Serializer gecached werden

        #endregion
    }
}