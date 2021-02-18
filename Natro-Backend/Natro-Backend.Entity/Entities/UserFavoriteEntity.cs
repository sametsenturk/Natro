using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Natro_Backend.Entity.Entities
{
    public class UserFavoriteEntity : BaseEntity
    {
        public string Domain { get; set; }
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual UserEntity User { get; set; }
    }
}
