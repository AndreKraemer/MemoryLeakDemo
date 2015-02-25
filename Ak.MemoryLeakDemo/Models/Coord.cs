using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Coord
    {
        [XmlAttribute]
        public decimal Lon { get; set; }


        [XmlAttribute]
        public decimal Lat { get; set; }
    }
}