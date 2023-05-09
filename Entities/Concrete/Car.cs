using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    // Araç İçin istenilen sistme özellikleri.
    public class Car : IEntity
    {
        public int CarId { get; set; } // Araç Kimliği
        public int BrandId { get; set; }  // Marka kimliği
        public int ColorId { get; set; } // Renk Kimliği
        public int ModelYear { get; set; }  // Model Yılı 
        public decimal DailyPrice  { get; set; }  // Günlük Fiyat
        public string Description { get; set; }  // Açıklama
    }
}
