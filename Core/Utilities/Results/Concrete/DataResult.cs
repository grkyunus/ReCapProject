using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    //Çalışma alanı
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success, string message) : base(success, message)
        {
            Data = data;
        }
        // Yukarıdaki yapı ile beraber alt kısımdaki yapıyı çalıştırmıyoruz. base result bağlıdır.

        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
