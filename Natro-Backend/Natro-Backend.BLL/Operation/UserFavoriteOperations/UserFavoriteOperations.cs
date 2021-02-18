using Natro_Backend.Constants;
using Natro_Backend.DAL.Abstract;
using Natro_Backend.Entity.Entities;
using Natro_Backend.Models.API.Favorite.Request;
using Natro_Backend.Models.API.Favorite.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Natro_Backend.BLL.Operation.UserFavoriteOperations
{
    public class UserFavoriteOperations
    {
        private IUserFavoriteService _userFavoriteService;

        public UserFavoriteOperations(IUserFavoriteService userFavoriteService)
        {
            _userFavoriteService = userFavoriteService;
        }

        public GetFavoritesResponse GetList(int userId)
        {
            GetFavoritesResponse response = new GetFavoritesResponse();
            response.Favorites = _userFavoriteService.Get(x => x.UserID == userId).ToList();
            response.IsSuccess = true;
            return response;
        }

        public PutFavoriteResponse Put(PutFavoriteRequest request, int userId)
        {
            PutFavoriteResponse response = new PutFavoriteResponse();
            var favorite = _userFavoriteService.Get(x => x.Domain == request.Domain && x.UserID == userId).FirstOrDefault();
            if (favorite == null)
            {
                _userFavoriteService.Add(new UserFavoriteEntity
                {
                    Domain = request.Domain,
                    UserID = userId
                });
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = GlobalConstants.ErrorMessageConstants.AlreadyExists;
            }
            return response;
        }

        public DeleteFavoriteResponse Delete(int favoriteId, int userId)
        {
            DeleteFavoriteResponse response = new DeleteFavoriteResponse();
            var favorite = _userFavoriteService.Get(x => x.ID == favoriteId && x.UserID == userId).FirstOrDefault();
            if (favorite != null)
            {
                _userFavoriteService.Delete(favorite);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = GlobalConstants.ErrorMessageConstants.DeleteFailed;
            }
            return response;
        }

    }
}
