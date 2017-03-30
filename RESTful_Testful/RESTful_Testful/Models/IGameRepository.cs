using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTful_Testful.Models
{
   public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game Get(int id);
        Game Add(Game game);
        void Remove(int id);
        bool Update(Game game);
    }
}
