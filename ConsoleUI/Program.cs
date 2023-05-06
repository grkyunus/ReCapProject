using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // InmemoryCardal();
            CarManager carManager = new CarManager(new EfCar());
            


           
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