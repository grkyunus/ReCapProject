using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // InmemoryCardal();
            CarManager carManager = new CarManager(new EfCar());

            Car carToAdd = new Car
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 100,
                ModelYear = 2021,
                Description = "Peugeot 301"
            };
            carManager.Add(carToAdd);

            // Araba Güncelleme Testi
            Car carToUpdate = new Car
            {
                CarId = 1,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 150,
                ModelYear = 2022,
                Description = "Renault Clio"
            };
            carManager.Update(carToUpdate);

            // Araba Silme Testi

             carManager.Delete(new Car{ CarId=3 });

            // Araba Listeleme Testi
            var cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("{0} - {1} - {2}", car.CarId, car.Description, car.DailyPrice);
            }


            Console.ReadLine();
        }

        static void InmemoryCardal()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }



    }
}