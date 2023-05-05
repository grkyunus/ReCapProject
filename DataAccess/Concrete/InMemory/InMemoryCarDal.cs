using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{CarId = 1, BrandId = 2, ColorId = 1, ModelYear = 2012, DailyPrice = 3000, Description = "Araç Audi ve rengi Beyaz..."},
                new Car{CarId = 2, BrandId = 2, ColorId = 2, ModelYear = 2015, DailyPrice = 2600, Description = "Araç Audi ve rengi Siyah..."},
                new Car{CarId = 3, BrandId = 3, ColorId = 4, ModelYear = 2018, DailyPrice = 3200, Description = "Araç Ford ve rengi Mavi ..."},
                new Car{CarId = 4, BrandId = 4, ColorId = 1, ModelYear = 2016, DailyPrice = 1800, Description = "Araç Volvo ve rengi Beyaz ..."},
                new Car{CarId = 5, BrandId = 5, ColorId = 3, ModelYear = 2023, DailyPrice = 3800, Description = "Araç Tesla ve rengi Gri ..."},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
