using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    // Veritabanı ile ilişkili Metotlar için.
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
