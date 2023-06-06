using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        IFileHelper _fileHelper;

        public ImageManager(IImageDal imageDal,IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }

        [SecuredOperation("car.add,admin")]
        public IResult Add(IFormFile file, Image image)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(image.CarId));
            if (result != null)
            {
                return result;
            }
            image.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult("Resim yükleme başarılı");
        }

        public IResult Delete(Image image)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<Image> GetById(int imageId)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(i=>i.Id == imageId));
        }

        public IDataResult<List<Image>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<Image>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(c => c.CarId == carId));
        }

        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + image.ImagePath, PathConstants.ImagesPath);
            _imageDal.Update(image);
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId).Count;
            if (result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<Image>> GetDefaultImage(int carId)
        {

            List<Image> image = new List<Image>();
            image.Add(new Image { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<Image>>(image);
        }
    }
}
