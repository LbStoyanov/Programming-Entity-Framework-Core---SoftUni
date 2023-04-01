using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Newtonsoft.Json;
using Trucks.Utilities;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        private static XmlHelper xmlHelper;

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            xmlHelper = new XmlHelper();

            ImportCreatorDto[] creatorsDtos = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString,"Creators");

            ICollection<Creator> validCreators = new HashSet<Creator>();

            foreach (ImportCreatorDto creatorDto in creatorsDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Boardgame> validBoardgames = new HashSet<Boardgame>();

                foreach (ImportBoardgameDto bgDto in creatorDto.Boardgames)
                {
                    if (!IsValid(bgDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = bgDto.Name,
                        Rating = bgDto.Rating,
                        YearPublished = bgDto.YearPublished,
                        CategoryType = (CategoryType)bgDto.CategoryType,
                        Mechanics = bgDto.Mechanics
                    };

                    validBoardgames.Add(boardgame);

                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                    Boardgames = validBoardgames,
                };

                validCreators.Add(creator);

                sb.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                    creator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportSellerDto[] sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            ICollection<Seller> validSellers = new HashSet<Seller>();
            ICollection<int> existingSellerIds = context.Sellers
                .Select(x => x.Id)
                .ToList();

            foreach (ImportSellerDto sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };

                foreach (int sellerId in sellerDto.BoardgamesIds.Distinct())
                {
                    if (!existingSellerIds.Contains(sellerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        SellerId = sellerId
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);

                    validSellers.Add(seller);

                    sb.AppendLine(
                        string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
                }
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();
            

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
