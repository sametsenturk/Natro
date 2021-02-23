using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Natro_Backend.BLL.Operation.UserFavoriteNotificationOperations;
using Natro_Backend.Models.API.FavoriteNotification.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Natro_Backend.API.Controllers
{
    public class NotificationController : BaseController
    {
        private UserFavoriteNotificationOperations _userFavoriteNotificationOperations;

        public NotificationController(UserFavoriteNotificationOperations userFavoriteNotificationOperations)
        {
            _userFavoriteNotificationOperations = userFavoriteNotificationOperations;
        }

        [HttpGet]
        [Route("getUserFavoriteNotifications")]
        public GetUserFavoriteNotificationsResponse GetUserFavoriteNotifications() => _userFavoriteNotificationOperations.GetUserFavoriteNotifications(userId: int.Parse(this.GetClaimValue(ClaimTypes.NameIdentifier)));

    }
}
