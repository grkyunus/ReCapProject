using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _imageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarid")]
        public IActionResult GetByCarId(int carid)
        {
            var result = _imageService.GetByCarId(carid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = _imageService.Add(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = _imageService.Update(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Image image)
        {
            var carImage = _imageService.GetById(image.Id).Data;
            var result = _imageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
