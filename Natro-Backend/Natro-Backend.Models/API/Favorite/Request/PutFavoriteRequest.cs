using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.API.Favorite.Request
{
    public class PutFavoriteRequest : BaseRequest
    {
        public string Domain { get; set; }
        public bool IsAvailableToBuy { get; set; }
        public string Nameserver1 { get; set; }
        public string Nameserver2 { get; set; }
        public DateTime LastChange { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
