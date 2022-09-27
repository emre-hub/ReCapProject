using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetRentalByCarId(int id);
        IDataResult<List<Rental>> GetRentalByCustomerId(int id);
        IDataResult<List<Rental>> GetRentDate(DateTime rentDate);
        IDataResult<List<Rental>> GetReturnDate(DateTime? returnDate);

    }
}
