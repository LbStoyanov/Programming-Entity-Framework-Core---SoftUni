using System.Xml.Serialization;

namespace Trucks.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader sr = new StringReader(inputXml);

            T supplierDtos = (T)xmlSerializer.Deserialize(sr);

            return supplierDtos;
        }

        public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

            using StringReader sr = new StringReader(inputXml);

            T[] supplierDtos = (T[])xmlSerializer.Deserialize(sr);

            return supplierDtos;
        }
    }
}
