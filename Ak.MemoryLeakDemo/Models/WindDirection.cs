// --------------------------------------------------------------------------------------
// <copyright file="WindDirection.cs" company="Andr� Kr�mer - Software, Training & Consulting">
//      Copyright (c) 2015 Andr� Kr�mer http://andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class WindDirection
    {
        [XmlAttribute]
        public byte Value { get; set; }


        [XmlAttribute]
        public string Code { get; set; }


        [XmlAttribute]
        public string Name { get; set; }
    }
}