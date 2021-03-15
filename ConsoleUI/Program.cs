using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            //GetAll
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.DailyPrice} - {car.Description}");
            }

            //Id = 2
            var CarWithId = carManager.GetById(2);
            Console.WriteLine($"{CarWithId.Id} - {CarWithId.DailyPrice} - {CarWithId.Description}");

            //Delete
            var deleteToCar = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 10, ModelYear = 2012, Description = "Auto Diesel" };
            carManager.Delete(deleteToCar);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.DailyPrice} - {car.Description}");
            }

        }
    }
}
