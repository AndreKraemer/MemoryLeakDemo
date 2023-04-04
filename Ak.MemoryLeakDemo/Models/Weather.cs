// --------------------------------------------------------------------------------------
// <copyright file="Weather.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 - 2023 André Krämer https://www.andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Weather
    {
        [XmlAttribute]
        public ushort Number { get; set; }


        [XmlAttribute]
        public string Value { get; set; }


        [XmlAttribute]
        public string Icon { get; set; }
    }
}