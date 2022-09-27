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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if(customer.CompanyName.Length < 2)
            {
                return new ErrorDataResult<Customer>("Müşteri adı 2 karakterden kısa olamaz");
            }
            _customerDal.Add(customer);
            return new Result(true, "Müşteri eklendi.");
        }

        public IResult Update(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
                return new Result(true, "Müşteri güncellendi.");
            }
            catch
            {
                return new ErrorDataResult<Customer>("Bir hata meydana geldi. Müşteri güncellenemedi.");
            }
        }
        public IResult Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
                return new Result(true, "Müşteri silindi.");
            }
            catch
            {
                return new ErrorDataResult<Customer>("Bir hata meydana geldi. Müşteri silinemedi.");
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), "Müşteriler listelendi..");  
        }

        public IDataResult<List<Customer>> GetCustomerById(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.Id == id), "Müşteriler id bilgisine göre listelendi.");
        }
    }
}
