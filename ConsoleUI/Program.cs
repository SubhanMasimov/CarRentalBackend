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

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.Id} - {brand.Name}");
            }


        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var carDto in carManager.GetCarDetails())
            {
                Console.WriteLine($"{carDto.Id} - {carDto.CarName} - {carDto.BrandName} -- {carDto.ColorName} -- {carDto.DailyPrice}");
            }
        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.DailyPrice} - {car.Description}");
            }
        }
    }
}
