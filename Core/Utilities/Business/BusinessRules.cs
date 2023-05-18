using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    // Buranın amacı belirtilen iş kurallarını daha düzenli olarak okunmasına destek 
    // params kullanuldığında istenildiği kadar IResult parametresi gönderilebilir.

    public class BusinessRules
    {

        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
