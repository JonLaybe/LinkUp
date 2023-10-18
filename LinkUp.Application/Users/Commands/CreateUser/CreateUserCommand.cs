using MediatR;
using System;

namespace LinkUp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
