using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Entity.Mapping
{
    public class UserEntityMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(256).IsRequired();
        }
    }
}
