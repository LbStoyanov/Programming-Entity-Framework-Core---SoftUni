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
            //TASK-01-Age Restriction:
            //Return in a single string all book titles, each on a new line, that have an age restriction, equal to 
            //the given command. Order the titles alphabetically.
            //Read input from the console in your main method and call your method with the necessary arguments.
            //Print the returned string to the console. Ignore the casing of the input.
            //Use method public static string GetBooksByAgeRestriction(BookShopContext context, string command)


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


