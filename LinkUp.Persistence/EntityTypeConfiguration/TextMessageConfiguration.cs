using LinkUp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp.Persistence.EntityTypeConfiguration
{
    public class TextMessageConfiguration : IEntityTypeConfiguration<TextMessage>
    {
        public void Configure(EntityTypeBuilder<TextMessage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Text).HasMaxLength(250);
        }
    }
}
