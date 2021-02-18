using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.API.Favorite.Response
{
    public class GetFavoritesResponse : BaseResponse
    {
        public List<UserFavoriteEntity> Favorites { get; set; }
    }
}
