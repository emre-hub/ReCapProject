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
            return new SuccessDataResult <List<Car>>(_carDal.GetAll());
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new Result(true, "Araba eklendi.");
        }

        public IResult Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new Result(true, "Araba güncellendi.");
            }
            catch
            {
                return new ErrorDataResult<Customer>("Bir hata meydana geldi.");
            }
        }
        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new Result(true, "Araba silindi.");
            }
            catch
            {
                return new ErrorDataResult<Customer>("Bir hata meydana geldi.");
            }
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
