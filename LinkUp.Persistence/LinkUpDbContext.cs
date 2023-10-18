using LinkUp.Application.Interfaces;
using LinkUp.Domain;
using LinkUp.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Persistence
{
    public class LinkUpDbContext : DbContext, ILinkUpDbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<PersonalChat> personalChats { get; set; }
        //public DbSet<TextMessage> textMessage { get; set; }

        public LinkUpDbContext(DbContextOptions<LinkUpDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PersonalChatConfiguration());
            //builder.ApplyConfiguration(new TextMessageConfiguration());
            base.OnModelCreating(builder);
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=GLEB-PC\SQLEXPRESS;Database=LinkUpDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }*/
    }
}
