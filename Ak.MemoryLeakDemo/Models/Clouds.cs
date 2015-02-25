using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Clouds
    {
        [XmlAttribute]
        public byte Value { get; set; }


        [XmlAttribute]
        public string Name { get; set; }
    }
}