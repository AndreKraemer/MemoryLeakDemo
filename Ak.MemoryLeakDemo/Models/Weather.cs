using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Weather
    {
        [XmlAttribute]
        public ushort Number { get; set; }


        [XmlAttribute]
        public string Value { get; set; }


        [XmlAttribute]
        public string Icon { get; set; }
    }
}