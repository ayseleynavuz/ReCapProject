using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalAddTest(rentalManager);


            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}
            //carManager.Add(new Car { CarId = 6, CarName = "fff" });
            //carManager.Delete(new Car { CarId = 5 });
            //carManager.Update(new Car { CarId=6,CarName="ggg"});


            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 4, ColorName = "Purple" });
            colorManager.Update(new Color { ColorId = 4, ColorName = "Gray" });
            colorManager.Delete(new Color { ColorId = 4, ColorName = "Gray" });


            //arabaları listeleme
            EfCarDal efCarDal = new EfCarDal();
            foreach (var car in efCarDal.GetCarDetails())
            {
                Console.WriteLine("car name: "+ car.CarName+"brand name:"+ car.BrandName+"color name:"+car.ColorName+"daily price:"+car.DailyPrice);
            }
            
        }

        private static void RentalAddTest(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.CarId);
            }
        }



    }
}
