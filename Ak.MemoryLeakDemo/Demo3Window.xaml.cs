// --------------------------------------------------------------------------------------
// <copyright file="Demo3Window.xaml.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using Ak.MemoryLeakDemo.Models;

namespace Ak.MemoryLeakDemo
{
    /// <summary>
    ///  Create some serializers and watch memory growing
    /// This bug gets nasty in production for example when you have this code in a 
    /// web service that gets called very often
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
            var serializer = new XmlSerializer(typeof(WeatherInfo), new XmlRootAttribute("Current"));
            WeatherInfo info;
            
            using (XmlReader reader = XmlReader.Create(Directory.GetCurrentDirectory() + "/App_Data/weather.xml"))
            {
                info = (WeatherInfo) serializer.Deserialize(reader);
            }
        }

        #region Solution
        // the chosen constructor of the xmlserializer class generates a dynamic assembly everytime when it's called
        // this assembly gets loaded into the current app domain and because of that it never gets unloaded
        // Solution:
        // Use one of the following constructors of XML Serializer if possible because they are caching
        // the dynamically generated assembly:
        // -XmlSerializer(type)  
        // -XmlSerializer(type, defaultNameSpace) 
        // if you do need one of the other constructors like in my example, declare the serializer as static
        // or cache it
        // e. g. private static XmlSerializer serializer = new XmlSerializer(typeof(WeatherInfo), new XmlRootAttribute("Current"));
        #endregion
    }
}