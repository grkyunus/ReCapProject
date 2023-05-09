using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Runtime.CompilerServices;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // InmemoryCardal();
            //CarTest1(carManager);

            #region Color

            ColorManager colorManager = new ColorManager(new EfColor());
            //clAdd(colorManager);
            //clDelete(colorManager);
            //clUpdate(colorManager);
            // clGetAll(colorManager);
            //clGetId(colorManager,5); // Sistemde 3 bulunmamaktadır.

            #endregion

            #region Car

            //CarManager carManager = new CarManager(new EfCar());
            //crAdd(carManager);
            //crDelete(carManager);
            //crUpdate(carManager);



            #endregion

            #region Brand

            BrandManager brandManager = new BrandManager(new EfBrand());
            //brAdd(brandManager);
            //brDelete(brandManager);
            brUpdate(brandManager, 2);

            #endregion



            Console.ReadLine();
        }




        #region Temel kod test

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
                //CarId = 1,
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 150,
                ModelYear = 2022,
                Description = "Renault Clio"
            };
            carManager.Update(carToUpdate);

            // Araba Silme Testi

            //carManager.Delete(new Car { CarId = 3 });

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

        #endregion

        #region Color Test || yukarının kodu tert olarak aşşağıdan yukarıya doğru uymaktadır.

        private static void clGetId(ColorManager colorManager, int X)
        {
            if (colorManager.GetById(X).Any())
            {
                foreach (var color in colorManager.GetById(X))
                {
                    Console.WriteLine("{0} --- {1}", color.ColorId, color.ColorName);
                }
            }
            else
            {
                Console.WriteLine("Aranılan Id bulunamadı.");
            }

        }

        private static void clGetAll(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0} --- {1}", color.ColorId, color.ColorName);
            }
        }

        private static void clUpdate(ColorManager colorManager, int X)
        {
            var colorToUpdateId = colorManager.GetById(X);
            
            
            if (colorToUpdateId.Count == X)
            {
                colorManager.Update(new Color { ColorId = X, ColorName = "Gray == Gri" });
            }
            else
            {
                Console.WriteLine("Aranılan Id bulunamadı.");
            }
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

        #endregion

        #region Car Test


        private static void crUpdate(CarManager carManager)
        {
            throw new NotImplementedException();
        }

        private static void crDelete(CarManager carManager)
        {
            throw new NotImplementedException();
        }

        private static void crAdd(CarManager carManager)
        {
            carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = 20 });
        }


        #endregion

        #region Brand Test

        private static void brUpdate(BrandManager brandManager, int X)
        {
            var brandToUpdateId = brandManager.GetById(X);
            if ()
            {
                brandManager.Update(new Brand { BrandId = X, BrandName = "Audi" });
                Console.WriteLine("İstenilen işlem gerçekleştirildi.\n İyi günler dileriz.");
            }
            else
            {
                Console.WriteLine("Aranılan Id bulunamadı.");
            }

        }

        private static void brDelete(BrandManager brandManager)
        {
            brandManager.Delete(new Brand { BrandId = 2 });
            Console.WriteLine("Silme işlemi gerçekleştirildi.");
        }

        private static void brAdd(BrandManager brandManager)
        {
            brandManager.Add(new Brand { BrandName = "Audiy" });
            brandManager.Add(new Brand { BrandName = "Bmw" });
            brandManager.Add(new Brand { BrandName = "Ford" });
        }

        #endregion




    }
}