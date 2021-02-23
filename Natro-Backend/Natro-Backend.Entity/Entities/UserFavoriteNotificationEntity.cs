using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Natro_Backend.Entity.Entities
{
    public class UserFavoriteNotificationEntity : BaseEntity
    {
        public int UserFavoriteID { get; set; }

        [ForeignKey("UserFavoriteID")]
        public virtual UserFavoriteEntity UserFavorite { get; set; }
    }
}
