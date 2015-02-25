using System.Xml.Serialization;

namespace Ak.MemoryLeakDemo.Models
{
    public class Precipitation
    {
        [XmlAttribute]
        public string Mode { get; set; }
    }
}