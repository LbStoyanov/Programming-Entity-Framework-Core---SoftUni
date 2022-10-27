namespace BookShop
{
    using BookShop.Models.Enums;
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
            //DbInitializer.ResetDatabase(db);

            string command = Console.ReadLine();
            var result = GetBooksByAgeRestriction(db, command);


            //var result = GetGoldenBooks(db);

            Console.WriteLine(result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();
           

            return result.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;

            bool isParsed = AgeRestriction.TryParse(command,true, out ageRestriction);
            if (!isParsed)
            {
                return String.Empty;
            }

            var bookTitles = context
                               .Books
                               .Where(b => b.AgeRestriction == ageRestriction)
                               .Select(b => b.Title)
                               .OrderBy(t => t)                            
                               .ToList();


            return string.Join(Environment.NewLine, bookTitles);
        }
    }
}


