using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user != null)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }

        public IResult Delete(User user)
        {
            if (user != null)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Process);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.Process);
        }

        public IResult Update(User user)
        {
            if (user != null)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }
    }
}
