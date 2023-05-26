using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
        // SecurityKey nesnesi oluşturularak simetrik şifrele algoritması kullanarak "securityKey"i byte dizisi dönüştürür
        // ve bunun temel alarak "SymmetricSecurityKey" nesne oluşturulur. 
    public class SecurityKeyHelpler
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
