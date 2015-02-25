using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Pressure
    {
        [XmlAttribute]
        public decimal Value { get; set; }


        [XmlAttribute]
        public string Unit { get; set; }
    }
}