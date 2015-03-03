// --------------------------------------------------------------------------------------
// <copyright file="City.cs" company="André Krämer - Software, Training & Consulting">
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
    public class City
    {
        public Coord Coord { get; set; }

        public string Country { get; set; }

        public Sun Sun { get; set; }

        [XmlAttribute]
        public uint Id { get; set; }


        [XmlAttribute]
        public string Name { get; set; }
    }
}