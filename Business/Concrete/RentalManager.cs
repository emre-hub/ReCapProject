using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            foreach(var r in _rentalDal.GetAll())
            {
                if(r.CarId == rental.CarId && r.ReturnDate == null)
                {
                    Console.WriteLine("Bu araç zaten başkası için kiralanmış");
                    return new ErrorDataResult<Rental>("Bu araç zaten başkası için kiralanmış");
                }
            }

            try
            {
                _rentalDal.Add(rental);
                return new Result(true, "Yeni araç kiralama bilgisi eklendi.");
            }
            catch
            {
                return new ErrorDataResult<Rental>("Bir hata meydana geldi.");
            }
        }

        public IResult Update(Rental rental)
        {
            foreach (var r in _rentalDal.GetAll())
            {
                if (r.CarId == rental.CarId && r.ReturnDate == null)
                {
                    return new ErrorDataResult<Rental>("Bu araç zaten başkası için kiralanmış");
                }
            }
            try
            {
                _rentalDal.Update(rental);
                return new Result(true, "Araç kiralama bilgisi güncellendi.");
            }
            catch
            {
                return new ErrorDataResult<Rental>("Bir hata meydana geldi.");
            }
        }
        public IResult Delete(Rental rental)
        {
            try
            {
                _rentalDal.Delete(rental);
                return new Result(true, "Aracın kiralanma bilgisi silindi.");
            }
            catch
            {
                return new ErrorDataResult<Rental>("Bir hata meydana geldi.");
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetRentalByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == id));
        }

        public IDataResult<List<Rental>> GetRentalByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == id));
        }

        public IDataResult<List<Rental>> GetRentDate(DateTime rentDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate == rentDate));
        }

        public IDataResult<List<Rental>> GetReturnDate(DateTime? returnDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == returnDate));
        }
    }
}
