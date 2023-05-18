using Business.Abstract;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(Image image)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Image image)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Image>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Image> GetById(int imageId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
