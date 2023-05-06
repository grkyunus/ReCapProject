using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Brand brand)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                _brandDal.Add(brand);
            }
        }

        public void Delete(Brand brand)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                _brandDal.Delete(brand);
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetById(int brandId)
        {
            return _brandDal.GetAll(b => b.BrandId == brandId).ToList();
        }

        public void Update(Brand brand)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                _brandDal.Update(brand);
            }
        }
    }
}
