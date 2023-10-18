using AutoMapper;
using LinkUp.Application.Common.Mappings;
using LinkUp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Application.Users.Queries.Authentication
{
    public class UserAuthenticationVM : IMapWith<User>
    {
        public string PhotoPreview { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserAuthenticationVM>().
                ForMember(userVm => userVm.PhotoPreview, opt => opt.MapFrom(user => user.PhotoPreview)).
                ForMember(userVm => userVm.FirstName, opt => opt.MapFrom(user => user.FirstName)).
                ForMember(userVm => userVm.LastName, opt => opt.MapFrom(user => user.LastName)).
                ForMember(userVm => userVm.DateCreate, opt => opt.MapFrom(user => user.DateCreate));
        }
    }
}
