using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id = 1, BrandId = 2, ColorId = 1, ModelYear = 2012, DailyPrice = 3000, Description = "Araç Audi ve rengi Beyaz..."},
                new Car{Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2015, DailyPrice = 2600, Description = "Araç Audi ve rengi Siyah..."},
                new Car{Id = 3, BrandId = 3, ColorId = 4, ModelYear = 2018, DailyPrice = 3200, Description = "Araç Ford ve rengi Mavi ..."},
                new Car{Id = 4, BrandId = 4, ColorId = 1, ModelYear = 2016, DailyPrice = 1800, Description = "Araç Volvo ve rengi Beyaz ..."},
                new Car{Id = 5, BrandId = 5, ColorId = 3, ModelYear = 2023, DailyPrice = 3800, Description = "Araç Tesla ve rengi Gri ..."},
            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {

            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }

  
}
