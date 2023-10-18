using MediatR;
using System;

namespace LinkUp.Application.Users.Queries.GetUserByName
{
    public class GetUserByNameQuery : IRequest<UserProfileVM>
    {
        public string UserName { get; set; }
    }
}
