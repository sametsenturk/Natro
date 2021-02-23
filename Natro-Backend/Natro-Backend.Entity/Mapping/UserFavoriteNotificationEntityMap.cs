using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Entity.Mapping
{
    public class UserFavoriteNotificationEntityMap : IEntityTypeConfiguration<UserFavoriteNotificationEntity>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteNotificationEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserFavoriteID).IsRequired();
        }
    }
}
