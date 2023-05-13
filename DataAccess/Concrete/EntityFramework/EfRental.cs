using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRental : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
           using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rcp_Rentals
                             join car in context.Rcp_Car on r.CarId equals car.Id
                             join b in context.Rcp_Brand on car.BrandId equals b.Id
                             join m in context.Rcp_Model on car.ModelId equals m.Id
                             join c in context.Rcp_Color on car.ColorId equals c.Id
                             join cu in context.Rcp_Customers on r.CustomerId equals cu.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 ModelName = m.ModelName,
                                 ColorName = c.ColorName,
                                 ModelYear = m.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 CustomerId = cu.Id,
                                 FirstName = cu.FirstName,
                                 LastName = cu.LastName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
            }
        }
    }
}
