namespace Trucks.DataProcessor.ExportDto
{
    using System.Xml.Serialization;
    using Trucks.DataProcessor.ImportDto;

    [XmlType("Despatcher")]
    public class ExportDespatcherDto
    {
        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; } = null!;

        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlArray("Trucks")]
        public ExportTruckDto[] Trucks { get; set; } = null!;
    }
}