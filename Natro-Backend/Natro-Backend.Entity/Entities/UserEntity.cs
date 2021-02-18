using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Entity.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual List<UserFavoriteEntity> Favorites { get; set; }
    }
}
