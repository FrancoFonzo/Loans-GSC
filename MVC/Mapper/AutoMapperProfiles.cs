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
            CreateMap<Category, CategoryResponse>()
                .ForMember(dest => dest.Things, opt => opt.MapFrom(src => src.Things.Select(t => t.Description)));
            
            CreateMap<CategoryRequest, Category>().ReverseMap();            

            CreateMap<Thing, ThingViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ReverseMap();
            CreateMap<Thing, CreateThingViewModel>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ReverseMap();

        }
    }
}
