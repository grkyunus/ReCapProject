using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.validation;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }

        public IResult Delete(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Process);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id == customerId),Messages.Process);
        }

        public IResult Update(Customer customer)
        {
            if (customer != null)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }
    }
}
