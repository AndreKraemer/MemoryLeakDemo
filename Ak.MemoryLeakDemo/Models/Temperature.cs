// --------------------------------------------------------------------------------------
// <copyright file="Temperature.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 André Krämer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Temperature
    {
        [XmlAttribute]
        public decimal Value { get; set; }


        [XmlAttribute]
        public decimal Min { get; set; }


        [XmlAttribute]
        public byte Max { get; set; }


        [XmlAttribute]
        public string Unit { get; set; }
    }
}