using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    [XmlType(AnonymousType = true)]
    public class Humidity
    {
        [XmlAttribute]
        public byte Value { get; set; }


        [XmlAttribute]
        public string Unit { get; set; }
    }
}