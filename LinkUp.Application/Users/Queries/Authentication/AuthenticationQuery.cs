using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Application.Users.Queries.Authentication
{
    public class AuthenticationQuery : IRequest<UserAuthenticationVM>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
