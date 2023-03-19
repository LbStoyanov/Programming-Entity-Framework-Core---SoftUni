using CarDealer.Data;
using CarDealer.DTOs.Import;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            StreamReader sr = new StreamReader(inputXml);

            ImportSupplierDto[] supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(sr);



            return "";
        }
    }
}