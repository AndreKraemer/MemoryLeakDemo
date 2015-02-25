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