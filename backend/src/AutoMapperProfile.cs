using AutoMapper;
using backend.src.DTOs;
using backend.src.Models;

namespace backend.src
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductReadDTO>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<ProductCreateDTO, Product>();

            CreateMap<Category, CategoryReadDTO>();
            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<CategoryCreateDTO, Category>();

            CreateMap<User, UserReadDTO>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<UserCreateDTO, User>();

            CreateMap<Image, ImageReadDTO>();
            CreateMap<ImageCreateDTO, Image>();
            CreateMap<ImageUpdateDTO, Image>();

        }
    }
}
