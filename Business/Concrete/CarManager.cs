using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //soyut bir data access layer erişimi;
        //constructorda parametre olarak gelir.
        //buraya bir orm teknolojisi gelecek
        //bu yarın bir gün nhibernate, entityframework veya dapper olabilir  : 

        ICarDal _carDal;
        IColorService _colorService;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult <List<Car>>(_carDal.GetAll());
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarIsAlreadyExist(car.CarId),
                ModifyCarName_AddColorNameToCarName(car));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarIsAlreadyExist(car.CarId),
                ModifyCarName_AddColorNameToCarName(car));
            if (result != null)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarAdded);
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

        private IResult CheckIfCarIsAlreadyExist(int carId)
        {
            //car is already exist
            var result = _carDal.GetAll(c => c.CarId == carId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarIsAlreadyExist);
            }
            return new SuccessResult();
        }


        //ilgili metod service injection amaçlı kullanılmıştır : 
        private IResult ModifyCarName_AddColorNameToCarName(Car car)
        {
            try
            {
                var colors = (List<Color>)_colorService.GetAll();
                foreach (var color in colors)
                {
                    if (color.ColorId == car.ColorId)
                        car.CarName += " " + color.ColorName;
                }
            }
            catch
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
