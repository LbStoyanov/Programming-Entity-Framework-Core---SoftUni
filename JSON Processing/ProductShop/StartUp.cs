using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.User;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        //private static IMapper mapper;
        public static void Main(string[] args)
        {
            //STEPS WHEN MAKE IMPORT
            //1.Create DTOs folder
            //2.Create DTO class for the respectiv json(Check for validations too!!!)
            //3.Create a map in the profile class
            //4.Initialize the mappper by giving the config
            //Deserialization => From json to dto
            //Serialization => From dto to json

            //mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<ProductShopProfile>();
            //}));

            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string inputJson = File.ReadAllText("../../../Datasets/users.json");
            //string output = ImportUsers(dbContext, inputJson);
            //Console.WriteLine(output);

            //string inputJson = File.ReadAllText("../../../Datasets/products.json");
            //string output = ImportProducts(dbContext, inputJson);
            //Console.WriteLine(output);

            //string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //string output = ImportCategories(dbContext, inputJson);
            //Console.WriteLine(output);




            //string json = GetProductsInRange(dbContext);

            //File.WriteAllText("../../../ExportResults/products-in-range.json", json);


            string json = GetSoldProducts(dbContext);

            File.WriteAllText("../../../ExportResults/user-sold-products.json", json);

        }

        //Problem 01 - Import users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> users = new List<User>();

            foreach (ImportUserDto dto in userDtos)
            {
                User user = Mapper.Map<User>(dto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Task 02 - Import products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productsDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> validProducts = new List<Product>();

            foreach (var productDto in productsDtos)
            {
                Product product = Mapper.Map<Product>(productDto);
                validProducts.Add(product);
            }

            context.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //Task 03 - Import categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDto[] categoriesDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            IList<Category> validCategories = new List<Category>();

            foreach (var categoryDto in categoriesDtos)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }
                Category category = Mapper.Map<Category>(categoryDto);

                validCategories.Add(category);
            }

            context.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //Task 04 - Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var dto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(dto);
                categoryProducts.Add(categoryProduct);
            }

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Task 05 - Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)

                //Manual mapping!!
                //.Select(p => new
                //{
                //    name = p.Name,
                //    price = p.Price,
                //    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                //})
                .ProjectTo<ExportProductsInRangeDto>()
                .ToArray();


            string json = JsonConvert.SerializeObject(products,Formatting.Indented);

            return json;
        }

        //Task 06 - Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUsersWithSoldProductsDto>()
                .ToArray();

            string json = JsonConvert.SerializeObject(usersWithSoldProducts,Formatting.Indented);

            return json;
        }


    }
}