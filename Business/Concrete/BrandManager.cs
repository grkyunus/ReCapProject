using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand != null)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);

        }

        public IResult Delete(Brand brand)
        {
            if (brand != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Process);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId), Messages.Process);
        }

        public IResult Update(Brand brand)
        {
            if (brand != null)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.Process);
            }
            return new ErrorResult(Messages.ProcessError);
        }
    }
}
