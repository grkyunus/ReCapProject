using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                if (car.Description.Length >= 2 && car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                }
                else
                {
                    throw new Exception("Araç ismi minimum 2 karakter olmalıdır. Ve Araba günlük fiyatı 0'dan büyük olmalıdır.");
                }

                // Araba ekleme işlemini gerçekleştir.
            }
        }

        public void Delete(Car car)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                _carDal.Delete(car);
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);

        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);

        }

        public void Update(Car car)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                if (car.Description.Length >= 2 && car.DailyPrice > 0)
                {
                    _carDal.Update(car);
                }
                else
                {
                    throw new Exception("Araç ismi minimum 2 karakter olmalıdır. Ve Araba günlük fiyatı 0'dan büyük olmalıdır.");
                }

            }
        }
    }
}
