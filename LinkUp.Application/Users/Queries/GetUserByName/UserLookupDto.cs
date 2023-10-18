using AutoMapper;
using LinkUp.Application.Common.Mappings;
using LinkUp.Domain;
using System;

namespace LinkUp.Application.Users.Queries.GetUserByName
{
    public class UserLookupDto : IMapWith<User>
    {
        public int UserId { get; set; }
        public string PhotoPreview { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userVm => userVm.UserId, opt => opt.MapFrom(user => user.UserId))
                .ForMember(userVm => userVm.PhotoPreview, opt => opt.MapFrom(user => user.PhotoPreview))
                .ForMember(userVm => userVm.FirstName, opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userVm => userVm.LastName, opt => opt.MapFrom(user => user.LastName))
                .ForMember(userVm => userVm.DateCreate, opt => opt.MapFrom(user => user.DateCreate));
        }
    }
}
