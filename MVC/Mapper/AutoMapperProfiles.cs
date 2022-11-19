using AutoMapper;
using MVC.Dto;
using MVC.Entities;
using MVC.Models;

namespace MVC.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, CategoryRequest>().ReverseMap();

            CreateMap<Thing, ThingViewModel>().ReverseMap();
        }
    }
}
