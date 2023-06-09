﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();


        // Alt kod IEntityRepository sayesinde gerek yoktur.

        //List<Car> GetAll();
        //List<Car> GetById(int carId);
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
    }
}
