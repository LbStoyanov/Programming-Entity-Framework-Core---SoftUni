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
            


            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string command = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, command);

            //var result = GetGoldenBooks(db);

            var result = GetBooksByPrice(db);

            Console.WriteLine(result);
        }

       

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            //TASK-01-Age Restriction:

            //Return in a single string all book titles, each on a new line, that have an age restriction, equal to 
            //the given command. Order the titles alphabetically.
            //Read input from the console in your main method and call your method with the necessary arguments.
            //Print the returned string to the console. Ignore the casing of the input.
            //Use method public static string GetBooksByAgeRestriction(BookShopContext context, string command)

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

        public static string GetGoldenBooks(BookShopContext context)
        {
            //TASK-02-Golden Books
            //Return in a single string title of the golden edition books that have less than 5000 copies,
            //each on a new line. Order them by book id ascending.
            //Call the GetGoldenBooks(BookShopContext context) method in your Main() and print the returned string to the console.


            var goldenBooks = context
                .Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();


            return String.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            //TASK-03-Book by Price
            //Return in a single string all titles and prices of books with a price higher than 40,
            //each on a new row in the format given below. Order them by price descending.

            StringBuilder result = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(b => b.BookPrice)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.BookTitle} - ${book.BookPrice:f2}");
            }



            return result.ToString().TrimEnd();
        }
    }
}


