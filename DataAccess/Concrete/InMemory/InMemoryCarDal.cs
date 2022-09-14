using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        /*List<Car> _cars; //veritabanimi temsil ediyor

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{CarId = 1, BrandId = 1, ColorId=1, DailyPrice = 50, Description = "Aile Arabası", ModelYear = "1997" },
                new Car{CarId = 2, BrandId = 1, ColorId=2, DailyPrice = 70, Description = "Aile Arabası", ModelYear = "2002" },
                new Car{CarId = 3, BrandId = 2, ColorId=3, DailyPrice = 150, Description = "Spor Araba", ModelYear = "2009" },
                new Car{CarId = 4, BrandId = 3, ColorId=4, DailyPrice = 100, Description = "Makam Arabası", ModelYear = "1995" },
                new Car{CarId = 5, BrandId = 2, ColorId=5, DailyPrice = 200, Description = "Limuzin", ModelYear = "2000" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c=>c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c=>c.ColorId == colorId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }*/
    }
}
