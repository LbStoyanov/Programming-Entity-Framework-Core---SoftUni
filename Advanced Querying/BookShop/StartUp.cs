namespace BookShop
{
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine().ToLower();

            var result = GetBooksByAgeRestriction(db, command);

            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder result = new StringBuilder();

            var books = context
                               .Books
                               .Include(b=>b)
                               .ToList()
                               .Where(b => b.AgeRestriction.ToString().ToLower() == command)
                               .OrderBy(b => b.Title)
                               .Select(b=>b.Title)                             
                               .ToList();

            foreach (var book in books)
            {
                result.AppendLine(book);
            }


            return result.ToString().TrimEnd();
        }
    }
}


