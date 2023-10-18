using LinkUp.Application.Interfaces;
using LinkUp.Domain;
using MediatR;
using System;

namespace LinkUp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommnadHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ILinkUpDbContext _context;

        public CreateUserCommnadHandler(ILinkUpDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                PhotoPreview = string.Empty,
                DateCreate = DateTime.Now,
            };

            await _context.users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user.UserId;
        }
    }
}
