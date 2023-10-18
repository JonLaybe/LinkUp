using AutoMapper;
using LinkUp.Application.Common.Mappings;
using LinkUp.Domain;
using MediatR;
using System;

namespace LinkUp.Application.Users.Queries.GetUserByName
{
    public class UserProfileVM : IRequest
    {
        public IList<UserLookupDto> Users { get; set; }
    }
}
