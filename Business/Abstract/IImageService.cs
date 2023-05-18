using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<List<Image>> GetAll();
        IDataResult<Image> GetById(int imageId);
        IDataResult<List<Image>> GetByCarId(int carId);
        IResult Add(IFormFile file,Image image);
        IResult Update(IFormFile file,Image image);
        IResult Delete(Image image);
    }
}
