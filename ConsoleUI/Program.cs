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
            CarManager carManager = new CarManager(new EfCarDal());

            //GetAll
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.DailyPrice} - {car.Description}");
            }

            //Id = 2
            var CarWithId = carManager.Get(2);
            Console.WriteLine($"{CarWithId.Id} - {CarWithId.DailyPrice} - {CarWithId.Description}");

        }
    }
}
