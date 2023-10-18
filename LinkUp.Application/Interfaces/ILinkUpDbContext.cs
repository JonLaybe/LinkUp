using LinkUp.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinkUp.Application.Interfaces
{
    public interface ILinkUpDbContext
    {
        DbSet<User> users { get; set; }
        DbSet<PersonalChat> personalChats { get; set; }
        //DbSet<TextMessage> textMessage { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
