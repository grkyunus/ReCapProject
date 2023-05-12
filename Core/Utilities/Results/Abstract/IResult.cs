using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        // İşlem gerçekleşip gerçekleşmediğine dair 
        bool Success { get; }
        // İşleme uygun mesaj kısmı 
        string Message { get; }
    }
}
