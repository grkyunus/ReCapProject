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


            #region Brand

            BrandManager brandManager = new BrandManager(new EfBrand());
            //brAdd(brandManager);
            //brDelete(brandManager,2);
            //brUpdate(brandManager, 2);
            //brGetAll(brandManager);
            //brGetId(brandManager,2);

            #endregion

            #region Car

            CarManager carManager = new CarManager(new EfCar());
            //crAdd(carManager);
            //crDelete(carManager);
            //crUpdate(carManager);
            //crGetByBrandId(carManager, 1);
            //crGetByColorId(carManager, 2);
            //crGetById(carManager, 5);
            //crGetCarDetail(carManager);
            ctGetAll(carManager);

            #endregion




            Console.ReadLine();
        }



        #region Temel kod test

        //private static void CarTest1()
        //{
        //    CarManager carManager = new CarManager(new EfCar());
        //    Car carToAdd = new Car
        //    {
        //        BrandId = 1,
        //        ColorId = 2,
        //        DailyPrice = 100,
        //        ModelYear = 2021,
        //        Description = "Peugeot 301"
        //    };
        //    carManager.Add(carToAdd);

        //    // Araba Güncelleme Testi
        //    Car carToUpdate = new Car
        //    {
        //        //CarId = 1,
        //        BrandId = 1,
        //        ColorId = 1,
        //        DailyPrice = 150,
        //        ModelYear = 2022,
        //        Description = "Renault Clio"
        //    };
        //    carManager.Update(carToUpdate);

        //    // Araba Silme Testi

        //    //carManager.Delete(new Car { CarId = 3 });

        //    // Araba Listeleme Testi         
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine("{0} - {1} - {2}", car.CarId, car.Description, car.DailyPrice);
        //    }
        //}

        //static void InmemoryCardal()
        //{
        //    CarManager carManager = new CarManager(new InMemoryCarDal());

        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.Description);
        //    }

        //    BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }

        //    ColorManager colorManager = new ColorManager(new InMemoryColorDal());

        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.ColorName);
        //    }
        //}

        #endregion

        #region Color Test
        // yukarının kodu tert olarak aşşağıdan yukarıya doğru uymaktadır.

        //private static void clGetId(ColorManager colorManager, int X)
        //{
        //    if (colorManager.GetById(X).Any())
        //    {
        //        foreach (var color in colorManager.GetById(X))
        //        {
        //            Console.WriteLine("{0} --- {1}", color.ColorId, color.ColorName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }

        //}

        //private static void clGetAll(ColorManager colorManager)
        //{
        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine("{0} --- {1}", color.ColorId, color.ColorName);
        //    }
        //}

        //private static void clUpdate(ColorManager colorManager, int X)
        //{
        //    var colorToUpdateId = colorManager.GetById(X);


        //    if (colorToUpdateId.Count > 0)
        //    {
        //        colorManager.Update(new Color { ColorId = X, ColorName = "Gray == Gri" });
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }
        //}

        //private static void clDelete(ColorManager colorManager)
        //{
        //    colorManager.Delete(new Color { ColorId = 3, ColorName = "to be deleted == silinecek" });
        //}

        //private static void clAdd(ColorManager colorManager)
        //{
        //    colorManager.Add(new Color { ColorName = "White == Beyaz" });
        //    colorManager.Add(new Color { ColorName = "Red == Kırmızı" });
        //    colorManager.Add(new Color { ColorName = "test == test" });
        //}

        #endregion


        #region Brand Test

        //private static void brGetId(BrandManager brandManager,int X)
        //{
        //    if (brandManager.GetById(X).Any())
        //    {
        //        foreach (var brand in brandManager.GetById(X))
        //        {
        //            Console.WriteLine("{0} --- {1}", brand.BrandId, brand.BrandName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }
        //}

        //private static void brGetAll(BrandManager brandManager)
        //{
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine("{0} --- {1}", brand.BrandId,brand.BrandName);
        //    }
        //}

        //private static void brUpdate(BrandManager brandManager, int X)
        //{
        //    var brandToUpdateId = brandManager.GetById(X);
        //    if (brandToUpdateId.Count > 0)
        //    {
        //        brandManager.Update(new Brand { BrandId = X, BrandName = "Audi" });
        //        Console.WriteLine("İstenilen işlem gerçekleştirildi.\n İyi günler dileriz.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }

        //}

        //private static void brDelete(BrandManager brandManager,int X)
        //{
        //    var brandToDeleteId = brandManager.GetById(X);
        //    if (brandToDeleteId.Count>0)
        //    {
        //        brandManager.Delete(new Brand { BrandId = X });
        //        Console.WriteLine("Silme işlemi gerçekleştirildi.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }

        //}

        //private static void brAdd(BrandManager brandManager)
        //{
        //    brandManager.Add(new Brand { BrandName = "Audiy" });
        //    brandManager.Add(new Brand { BrandName = "Bmw" });
        //    brandManager.Add(new Brand { BrandName = "Ford" });
        //}

        #endregion

        #region CarTest

        private static void ctGetAll(CarManager carManager)
        {
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} --- {1} --- {2} --- {3} --- {4}", cars.CarId, cars.BrandId, cars.ColorId, cars.DailyPrice, cars.Description);
            }
        }

        private static void crGetCarDetail(CarManager carmanager)
        {
            //carmanager = new carmanager(new EfCar());
            foreach (var car in carmanager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} --- {1} --- {2} --- {3} --- {4}", car.CarId, car.BrandName, car.ColorName, car.DailyPrice, car.Description);
            }
        }

        //private static void crGetById(CarManager carManager,int X)
        //{
        //    if (carManager.GetById(X).Any())
        //    {
        //        foreach (var cars in carManager.GetById(X))
        //        {
        //            Console.WriteLine("{0} --- {1} --- {2} --- {3}", cars.CarId, cars.ColorId, cars.DailyPrice, cars.Description);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }
        //}

        //private static void crGetByColorId(CarManager carManager,int X)
        //{
        //    if (carManager.GetCarsByColorId(X).Any())
        //    {
        //        foreach (var cars in carManager.GetCarsByColorId(X))
        //        {
        //            Console.WriteLine("{0} --- {1} --- {2} --- {3}", cars.CarId, cars.ColorId, cars.DailyPrice, cars.Description);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }
        //}

        //private static void crGetByBrandId(CarManager carManager,int X)
        //{
        //    if (carManager.GetCarsByBrandId(X).Any())
        //    {
        //        foreach (var cars in carManager.GetCarsByBrandId(X))
        //        {
        //            Console.WriteLine("{0} --- {1} --- {2} --- {3}", cars.CarId,cars.ColorId,cars.DailyPrice,cars.Description);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }
        //}

        //private static void crUpdate(CarManager carManager,int X)
        //{
        //    var carUpdateId = carManager.GetById(X);
        //    if (carUpdateId.Count > 0)
        //    {
        //        carManager.Update(new Car { CarId = X, BrandId =3, ColorId=1, DailyPrice = 4500, ModelYear = 2000, Description= "Araç güncellemesi çalıştı." });
        //        Console.WriteLine("İstenilen işlem gerçekleştirildi.\n İyi günler dileriz.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }
        //}

        //private static void crDelete(CarManager carManager,int X)
        //{
        //    var carDeleteId = carManager.GetById(X);
        //    if (carDeleteId.Count >0)
        //    {
        //        carManager.Delete(new Car { CarId = X });
        //        Console.WriteLine("Silme işlemi gerçekleştirildi.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Aranılan Id bulunamadı.");
        //    }
        //}

        //private static void crAdd(CarManager carManager)
        //{
        //    carManager.Add(new Car { BrandId = 6, ColorId = 9, ModelYear = 2016, DailyPrice = 3800, Description = "Yeni Araç Eklendi." });
        //}


        #endregion



    }
}