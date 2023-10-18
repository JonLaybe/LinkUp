using AutoMapper;
using LinkUp.Application.Common.Exceptions;
using LinkUp.Application.Interfaces;
using LinkUp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Application.Users.Queries.Authentication
{
    public class UserAuthenticationQueryHandler : IRequestHandler<AuthenticationQuery, UserAuthenticationVM>
    {
        private ILinkUpDbContext _contextDb;
        private IMapper _mapper;

        public UserAuthenticationQueryHandler(ILinkUpDbContext contextDb, IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<UserAuthenticationVM> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
        {
            User user = await _contextDb.users.FirstOrDefaultAsync(user => user.Email == request.Email && user.Password == request.Password, cancellationToken);

            if (user == null)
            {
                throw new CheckFailedException(nameof(user));
            }

            return _mapper.Map<UserAuthenticationVM>(user);
        }
    }
}
