using LinkUp.Application.Common.Exceptions;
using LinkUp.Application.Interfaces;
using LinkUp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinkUp.Application.Users.Commands.UpdateUser
{
    public class UpdateCommnadHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ILinkUpDbContext _contextDb;

        public UpdateCommnadHandler(ILinkUpDbContext contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _contextDb.users.FirstOrDefaultAsync(user =>
                user.UserId == request.UserId, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            entity.UserId = request.UserId;
            entity.PhotoPreview = request.PhotoPreview;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            await _contextDb.SaveChangesAsync(cancellationToken);
        }
    }
}
