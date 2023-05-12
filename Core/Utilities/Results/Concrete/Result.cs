using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    //Çalışma alanı
    public class Result : IResult
    {

        public Result(bool success,string message) 
        {
            Message = message;
            // bool değer koymamamızın sebebi alt contructorde bulunması.
        }

        public Result(bool success)
        {
            Success = success;
        }

        // readonly özelliği sayesinde constructor ile set edilebilir durumda.
        public bool Success { get; }
        public string Message { get; }
    }
}
