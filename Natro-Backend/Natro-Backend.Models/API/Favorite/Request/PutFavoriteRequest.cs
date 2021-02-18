using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.API.Favorite.Request
{
    public class PutFavoriteRequest : BaseRequest
    {
        public string Domain { get; set; }
    }
}
