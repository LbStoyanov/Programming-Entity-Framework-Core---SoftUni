using System.Text;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;
using Trucks.Utilities;

namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Data;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        private static XmlHelper XmlHelper;

        

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            XmlHelper = new XmlHelper();

            ImportDespatcherDto[] despatcherDtoS =
                XmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();

            foreach (ImportDespatcherDto despatcherDto in despatcherDtoS)
            {
                if (!IsValid(despatcherDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Truck> validTrucks = new HashSet<Truck>();

                foreach (ImportTruckDto truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType,

                    };

                    validTrucks.Add(truck);
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };

                validDespatchers.Add(despatcher);
                output.AppendLine(string.Format($"Successfully imported despatcher – {despatcher.Name} with {validTrucks.Count} trucks."))
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return output.ToString().TrimEnd();

        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}