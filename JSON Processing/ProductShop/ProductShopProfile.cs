using AutoMapper;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.User;
using ProductShop.DTOs.Users;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(d => d.SellerFullName, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.ByuerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.ByuerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));


            this.CreateMap<User, ExportUsersWithSoldProductsDto>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold
                .Where(p => p.BuyerId.HasValue)));
        }
    }
}
