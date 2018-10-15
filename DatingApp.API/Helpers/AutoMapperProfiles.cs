using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photo.FirstOrDefault(p => p.IsMain).url);
                })
                .ForMember(dest => dest.age, opt => {
                   opt.ResolveUsing(d => d.DateOfBirth.CalcuateAge());
                });
            CreateMap<User, UserForDetailedDto>()
               .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photo.FirstOrDefault(p => p.IsMain).url);
                })
                .ForMember(dest => dest.Age, opt => {
                   opt.ResolveUsing(d => d.DateOfBirth.CalcuateAge());
                });
            CreateMap<photo, PhotosForDetailedDto>();
        }
    }
}