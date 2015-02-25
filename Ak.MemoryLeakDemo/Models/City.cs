using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class City
    {
        public Coord Coord { get; set; }


        public string Country { get; set; }

        public Sun Sun { get; set; }

        [XmlAttribute]
        public uint Id { get; set; }


        [XmlAttribute]
        public string Name { get; set; }
    }
}