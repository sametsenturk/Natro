using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Natro_Backend.BLL.Operation.UserFavoriteOperations;
using Natro_Backend.Models.API.Favorite.Request;
using Natro_Backend.Models.API.Favorite.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Natro_Backend.API.Controllers
{
    public class FavoriteController : BaseController
    {
        private UserFavoriteOperations _userFavoriteOperations;

        public FavoriteController(UserFavoriteOperations userFavoriteOperations)
        {
            _userFavoriteOperations = userFavoriteOperations;
        }

        [HttpGet]
        [Route("getlist")]
        public GetFavoritesResponse GetList() => _userFavoriteOperations.GetList(
                userId: int.Parse(this.GetClaimValue(ClaimTypes.NameIdentifier))
            );

        [HttpPut]
        [Route("put")]
        public PutFavoriteResponse Put([FromBody] PutFavoriteRequest request) => _userFavoriteOperations.Put(
                request: request,
                userId: int.Parse(this.GetClaimValue(ClaimTypes.NameIdentifier))
            );

        [HttpDelete("delete/{id}")]        
        public DeleteFavoriteResponse Delete(int id) => _userFavoriteOperations.Delete(
                favoriteId: id,
                userId: int.Parse(this.GetClaimValue(ClaimTypes.NameIdentifier))
            );

    }
}
