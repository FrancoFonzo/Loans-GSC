using AutoMapper;
using LoansAPI.Dto.Requests;
using LoansAPI.Dto.Responses;
using LoansAPI.Entities;
using LoansAPI.Models;

namespace LoansAPI.Mapper
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
