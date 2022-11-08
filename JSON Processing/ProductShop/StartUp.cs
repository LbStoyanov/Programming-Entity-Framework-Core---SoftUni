using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        //private static IMapper mapper;
        public static void Main(string[] args)
        {
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

            string inputJson = File.ReadAllText("../../../Datasets/categories.json");
            string output = ImportCategories(dbContext, inputJson);
            Console.WriteLine(output);


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

    }
}