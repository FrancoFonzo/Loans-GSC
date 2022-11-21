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

            CreateMap<Person, PersonResponse>().ReverseMap();
            CreateMap<Person, PersonRequest>().ReverseMap();

            CreateMap<Thing, ThingViewModel>().ReverseMap();
            CreateMap<Thing, CreateThingViewModel>().ReverseMap();

            CreateMap<Loan, LoanResponse>().ReverseMap();
            CreateMap<Loan, LoanRequest>().ReverseMap();
        }
    }
}
