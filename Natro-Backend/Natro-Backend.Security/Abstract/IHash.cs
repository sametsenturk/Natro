using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Security.Abstract
{
    public interface IHash
    {
        string Hash(string text);
    }
}
