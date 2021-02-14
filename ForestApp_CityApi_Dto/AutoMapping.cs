using AutoMapper;
using ForestApp_CityApi_Entity;
using System;

namespace ForestApp_CityApi_Dto
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CityDto, City>().ReverseMap().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Name));
        }

    }
}
