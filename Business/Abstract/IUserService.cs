using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        //getusersbyid, getusersbyfirstname, getusersbylastname, getusersbyemail
        IResult Add(User user); 
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetUserById(int id);
        IDataResult<List<User>> GetUserByName(string firstname, string lastname);
        IDataResult<List<User>> GetUserByEmail(string email);
    }
}
