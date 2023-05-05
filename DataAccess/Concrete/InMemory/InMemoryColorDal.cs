using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        // Deneme veri tabanı 
        public InMemoryColorDal()
        {
            _colors = new List<Color>()
            {
                new Color{ ColorId = 1, ColorName = "Beyaz"},
                new Color{ ColorId = 2, ColorName = "Siyah"},
                new Color{ ColorId = 3, ColorName = "Gri"},
                new Color{ ColorId = 4, ColorName = "Mavi"},
            };
        }

        // Ekleme kısmı 
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        // Silme Kısmı
        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
        }

        // Renklerin alt yöntemle çekildiği yer.
        public List<Color> GetAll()
        {
            return _colors;
        }

        // Sorgulama
        public List<Color> GetById(int colorId)
        {
            return _colors.Where(c => c.ColorId == colorId).ToList();
        }

        // Renk Güncelleme
        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
