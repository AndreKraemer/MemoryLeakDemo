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