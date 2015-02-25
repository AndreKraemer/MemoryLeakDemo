using System;
using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Lastupdate
    {
        [XmlAttribute]
        public DateTime Value { get; set; }
    }
}