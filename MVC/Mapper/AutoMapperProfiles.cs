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
            //CreateMap<Thing, ThingResponse>().ReverseMap();
            CreateMap<CategoryRequest, Category>().ReverseMap();
            ////CreateMap<ThingCreationDto, Thing>();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            //CreateMap<Thing, ThingViewModel>().ReverseMap();
        }
    }
}
