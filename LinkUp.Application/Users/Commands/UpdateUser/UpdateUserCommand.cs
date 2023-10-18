using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int UserId { get; set; }
        public string PhotoPreview { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
