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
            //CarTest1(carManager);
            CarManager carManager = new CarManager(new EfCar());
            ColorManager colorManager = new ColorManager(new EfColor());
            //clAdd(colorManager);
            //clDelete(colorManager);
            //clUpdate(colorManager);
            // clGetAll(colorManager);





            Console.ReadLine();
        }

        private static void clGetAll(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0} --- {1}", color.ColorId,color.ColorName);
            }
        }

        private static void clUpdate(ColorManager colorManager)
        {
            colorManager.Update(new Color { ColorId = 9, ColorName = "Gray == Gri" });
        }

        private static void clDelete(ColorManager colorManager)
        {
            colorManager.Delete(new Color { ColorId = 3, ColorName = "to be deleted == silinecek" });
        }

        private static void clAdd(ColorManager colorManager)
        {
            colorManager.Add(new Color { ColorName = "White == Beyaz" });
            colorManager.Add(new Color { ColorName = "Red == Kırmızı" });
            colorManager.Add(new Color { ColorName = "test == test" });
        }

        private static void CarTest1()
        {
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

            carManager.Delete(new Car { CarId = 3 });

            // Araba Listeleme Testi         
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} - {1} - {2}", car.CarId, car.Description, car.DailyPrice);
            }
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