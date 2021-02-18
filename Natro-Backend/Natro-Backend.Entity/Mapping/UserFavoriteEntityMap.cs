using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Entity.Mapping
{
    public class UserFavoriteEntityMap : IEntityTypeConfiguration<UserFavoriteEntity>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.Domain).HasMaxLength(30).IsRequired();

            builder.HasIndex(x => x.UserID);
        }
    }
}
