using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinkUp.Application.Common.Exceptions;
using LinkUp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinkUp.Application.Users.Queries.GetUserByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserProfileVM>
    {
        private readonly ILinkUpDbContext _contextDb;
        private readonly IMapper _mapper;

        public GetUserByNameQueryHandler(ILinkUpDbContext contextDb, IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<UserProfileVM> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var users = await _contextDb.users.Where(user =>
                (user.FirstName + ' ' + user.LastName).Contains(request.UserName))
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserProfileVM() { Users = users };
        }
    }
}
