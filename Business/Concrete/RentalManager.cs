using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Process);
        }

        public IResult Delete(Rental rental)
        {
            if (rental != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Process);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId), Messages.Process);
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result =_rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }

        public IResult Update(Rental rental)
        {
            if (rental != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }
    }
}
