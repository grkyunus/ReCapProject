using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    // True durumunda çalışır.
    public class SuccessDataResult<T> : DataResult<T>
    {
        // Data ve mesaj için.
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        // sadece data için.
        public SuccessDataResult(T data):base(data,true)
        {
            
        }
        //sadece mesaj için.
        public SuccessDataResult(string message) : base(default,true,message)
        {
            
        }
        // hiç bir döndü verilmemesi durumunda.
        public SuccessDataResult() : base(default,true)
        {
            
        }
    }
}
