using AutoMapper;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.DTO;

namespace eCommerce.Core.Mapper
{
    public class ApplicationUserMappingProfile:Profile
    {
        public ApplicationUserMappingProfile() {
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.success, opt => opt.Ignore())
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }
    }
}
