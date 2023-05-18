using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelper
{
    // Guid benzersiz bir kimlik oluşturmak için kullanılır.
    public class GuidHelpers
    {
        // Alt taraftaki sistem oluşturulduğunda her seferinde yeni bir guid oluşturur.
        public static string CreatGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
