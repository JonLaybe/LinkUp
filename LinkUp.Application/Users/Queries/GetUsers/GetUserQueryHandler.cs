using AutoMapper;
using LinkUp.Application.Common.Exceptions;
using LinkUp.Application.Interfaces;
using LinkUp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinkUp.Application.Users.Queries.GetUsers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserProfileVM>
    {
        private readonly ILinkUpDbContext _contextDb;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(ILinkUpDbContext contextDb, IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<UserProfileVM> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            User user = await _contextDb.users.FirstOrDefaultAsync(user => user.UserId == request.UserId, cancellationToken);

            if (user == null || user.UserId != request.UserId)
                throw new NotFoundException(nameof(user), request.UserId);

            return _mapper.Map<UserProfileVM>(user);
        }
    }
}
