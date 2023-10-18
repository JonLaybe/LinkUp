using LinkUp.Domain;
using MediatR;
using System;

namespace LinkUp.Application.Users.Queries.GetUsers
{
    public class GetUserQuery : IRequest<UserProfileVM>
    {
        public int UserId { get; set; }
    }
}
