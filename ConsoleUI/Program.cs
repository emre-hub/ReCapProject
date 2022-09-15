using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //CarId, BrandId, ColorId, ModelYear, DailyPrice, Description

            List<Car> cars = new List<Car> {
                new Car{ BrandId = 1, CarName = "Citroen" , ColorId=1, DailyPrice = 50, Description = "Sedan Araba", ModelYear = "1997" },
                new Car{ BrandId = 1, CarName = "Renault" , ColorId=2, DailyPrice = 70, Description = "Hatchback Araba", ModelYear = "2002" },
                new Car{ BrandId = 2, CarName = "BMW" , ColorId=3, DailyPrice = 150, Description = "Spor Araba", ModelYear = "2009" },
                new Car{ BrandId = 3, CarName = "Mercedes" , ColorId=4, DailyPrice = 100, Description = "Makam Arabası", ModelYear = "1995" },
                new Car{ BrandId = 2, CarName = "Jeep" , ColorId=5, DailyPrice = 200, Description = "Cip 4X4", ModelYear = "2000" }
            };

            //foreach(var car in cars)
            //{
            //    carManager.Add(car);
            //}

            foreach(var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}