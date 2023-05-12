using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    // False durumunda çalışır.
    public class ErrorDataResult<T> : DataResult<T>
    {
        // data ve mesaj
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        // data 
        public ErrorDataResult(T data):base(data,false)
        {
            
        }
        // mesaj
        public ErrorDataResult(string message):base(default,false,message)
        {
            
        }
        //boş
        public ErrorDataResult():base(default,false)
        {
            
        }
    }
}
