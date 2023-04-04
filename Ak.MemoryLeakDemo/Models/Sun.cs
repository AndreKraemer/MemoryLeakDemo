// --------------------------------------------------------------------------------------
// <copyright file="Sun.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2015 - 2023 André Krämer https://www.andrekraemer.de - 
//      GPL3 License (see license.txt)
// </copyright>
// <summary>
//  Memory Leak Demo Projekt
// </summary>
// --------------------------------------------------------------------------------------

using System;
using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Sun
    {
        [XmlAttribute]
        public DateTime Rise { get; set; }


        [XmlAttribute]
        public DateTime Set { get; set; }
    }
}