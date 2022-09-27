using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public IResult Add(User user)
        {

            if (user.FirstName.Length < 2)
            {
                Console.WriteLine("Kullanıcı adı minimum 2 karakter olmalıdır.");
                return new ErrorResult();
            }
            else
            {
                _userdal.Add(user);
            }
            return new Result(true, "Kullanıcı eklendi.");
        }

        public IResult Update(User user)
        {
            try
            {
                _userdal.Update(user);
                return new Result(true, "Kullanıcı güncellendi.");
            }
            catch
            {
                return new ErrorDataResult<User>("Bir hata meydana geldi.");
            }
        }
        public IResult Delete(User user)
        {
            try
            {
                _userdal.Delete(user);
                return new Result(true, "Kullanıcı silindi.");
            }
            catch
            {
                return new ErrorDataResult<User>("Bir hata meydana geldi.");
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(), "Kullanıcılar listelendi..");
        }

        public IDataResult<List<User>> GetUserByEmail(string email)
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(u => u.Email == email), "Kullanıcılar email bilgisine göre listelendi.");
        }

        public IDataResult<List<User>> GetUserById(int id)
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(u => u.Id == id), "Kullanıcılar Id'ye göre listelendi");
        }

        public IDataResult<List<User>> GetUserByName(string firstname, string lastname)
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll(u=> u.FirstName == firstname && u.LastName == lastname), "Kullanıcılar Ad-Soyad bilgisine göre listelendi");
        }
    }
}
