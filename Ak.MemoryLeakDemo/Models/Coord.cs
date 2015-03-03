// --------------------------------------------------------------------------------------
// <copyright file="Coord.cs" company="André Krämer - Software, Training & Consulting">
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
    public class Coord
    {
        [XmlAttribute]
        public decimal Lon { get; set; }


        [XmlAttribute]
        public decimal Lat { get; set; }
    }
}