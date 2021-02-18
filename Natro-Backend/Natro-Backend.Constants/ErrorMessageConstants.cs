using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Constants
{
    public partial class GlobalConstants
    {
        public partial class ErrorMessageConstants
        {
            public const string LoginFailed = "Username or password incorrect.";
            public const string DeleteFailed = "Data could not be deleted.";
            public const string AlreadyExists = "Data could not be added because it is already exists.";
        }
    }
}
