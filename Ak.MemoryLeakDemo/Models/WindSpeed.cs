// --------------------------------------------------------------------------------------
// <copyright file="WindSpeed.cs" company="André Krämer - Software, Training & Consulting">
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
    public class WindSpeed
    {
        [XmlAttribute]
        public decimal Value { get; set; }


        [XmlAttribute]
        public string Name { get; set; }
    }
}