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