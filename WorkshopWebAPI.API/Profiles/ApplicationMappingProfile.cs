using AutoMapper;
using WorkshopWebAPI.API.DTO;
using WorkshopWebAPI.API.Persistence.Models;

namespace WorkshopWebAPI.API.Profiles
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Customer, CustomerOuputDTO>()
                .ForMember(dst => dst.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy/MM/dd")))
                .ForMember(dst => dst.Enabled, opt => opt.Ignore())
                .AfterMap((src, dst) =>
                {
                    dst.Enabled = (DateTime.Now.Year - src.Birthdate.Year) > 18;
                });
        }
    }
}
