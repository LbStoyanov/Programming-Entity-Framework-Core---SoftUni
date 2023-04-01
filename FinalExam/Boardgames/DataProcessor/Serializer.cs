using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Include(c => c.BoardgamesSellers)
                .ThenInclude(x => x.Boardgame)
                .AsNoTracking()
                .ToArray()
                .Where(x => x.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(x => new
                {
                    Boardgames = x.BoardgamesSellers
                        .Where(y => y.Boardgame.YearPublished >= year && y.Boardgame.Rating <= rating)
                        .Select(bg => new
                        {
                            Name =bg.Boardgame.Name,
                            Rating = bg.Boardgame.Rating,
                            Mechanics = bg.Boardgame.Mechanics,
                            CategoryType = bg.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(z => z.Rating)
                        .ThenBy(z => z.Name)
                })
                .OrderByDescending(x => x.Boardgames.Count())
                .ThenBy(x => x.Boardgames.Select(y => y.Name))
                .Take(5)
                .ToList();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}