using Natro_Backend.DAL.Abstract;
using Natro_Backend.Models.API.FavoriteNotification.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Natro_Backend.BLL.Operation.UserFavoriteNotificationOperations
{
    public class UserFavoriteNotificationOperations
    {
        private IUserFavoriteNotificationService _userFavoriteNotificationService;
        private IUserFavoriteService _userFavoriteService;

        public UserFavoriteNotificationOperations(IUserFavoriteNotificationService userFavoriteNotificationService, IUserFavoriteService userFavoriteService)
        {
            _userFavoriteNotificationService = userFavoriteNotificationService;
            _userFavoriteService = userFavoriteService;
        }

        public GetUserFavoriteNotificationsResponse GetUserFavoriteNotifications(int userId)
        {
            GetUserFavoriteNotificationsResponse response = new GetUserFavoriteNotificationsResponse()
            {
                IsSuccess = true
            };

            response.UserFavoriteNotifications = _userFavoriteNotificationService.Get(x => x.UserFavorite.UserID == userId).ToList();
            
            foreach(var item in response.UserFavoriteNotifications)
            {
                item.UserFavorite = _userFavoriteService.Get(x => x.ID == item.UserFavoriteID).FirstOrDefault();
            }

            foreach(var item in response.UserFavoriteNotifications)
            {
                _userFavoriteNotificationService.Delete(item);
            }
            
            return response;
        }

    }
}
