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