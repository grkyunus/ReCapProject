using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Color{ Id = 1, ColorName = "Beyaz"},
                new Color{ Id = 2, ColorName = "Siyah"},
                new Color{ Id = 3, ColorName = "Gri"},
                new Color{ Id = 4, ColorName = "Mavi"},
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
            Color colorToDelete = _colors.SingleOrDefault(c => c.Id == color.Id);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        // Renklerin alt yöntemle çekildiği yer.
        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        // Sorgulama
        public List<Color> GetById(int colorId)
        {
            return _colors.Where(c => c.Id == colorId).ToList();
        }

        // Renk Güncelleme
        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.Id == color.Id);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
