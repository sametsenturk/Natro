using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.API.FavoriteNotification.Response
{
    public class GetUserFavoriteNotificationsResponse : BaseResponse
    {
        public List<UserFavoriteNotificationEntity> UserFavoriteNotifications { get; set; }
    }
}
