using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllTest();
            //CarDtoTest();
            //BrandTest();
            //IResultCarTest();

        }

        private static void IResultCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"{car.Id} - {car.DailyPrice} - {car.Description}");
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id} - {brand.Name}");
            }
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var carDto in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{carDto.Id} - {carDto.CarName} - {carDto.BrandName} -- {carDto.ColorName} -- {carDto.DailyPrice}");
            }
        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id} - {car.DailyPrice} - {car.Description}");
            }
        }
    }
}
