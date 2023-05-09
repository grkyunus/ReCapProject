using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        // Alt kod IEntityRepository sayesinde gerek yoktur.

        //List<Color> GetAll();
        //List<Color> GetById(int colorId);

        //void Add(Color color);
        //void Update(Color color);
        //void Delete(Color color);
    }
}
