﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {

                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id, BrandName = b.BrandName, ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice, Description = c.Description,
                                 Model = c.Model, ModelYear = c.ModelYear,
                                 ImagePath = (from m in context.Images where m.CarId == c.Id select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
