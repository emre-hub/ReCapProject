using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //soyut bir data access layer erişimi;
        //constructorda parametre olarak gelir.
        //buraya bir orm teknolojisi gelecek
        //bu yarın bir gün nhibernate, entityframework veya dapper olabilir  : 

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //iş kodları
            //yetkisi var mı? şartlar uyugn mu? vb. kodlar
            //business layerda bu kodlar yazılır
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {
            if(car.CarName.Length < 2)
            {
                Console.WriteLine("Araba adı minimum 2 karakter olmalıdır.");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
            }
            else
            {
                _carDal.Add(car);
            }
        }
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
