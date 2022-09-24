using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları
            //yetkisi var mı? şartlar uyugn mu? vb. kodlar
            //business layerda bu kodlar yazılır
            return new SuccessDataResult <List<Car>>(_carDal.GetAll());
        }

        public IResult Add(Car car)
        {
            if(car.CarName.Length < 2)
            {
                Console.WriteLine("Araba adı minimum 2 karakter olmalıdır.");
                return new ErrorResult();
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                return new ErrorResult();
            }
            else
            {
                _carDal.Add(car);
            }
            return new Result(true, "Araba eklendi.");
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.BrandId == id) );
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
    }
}
