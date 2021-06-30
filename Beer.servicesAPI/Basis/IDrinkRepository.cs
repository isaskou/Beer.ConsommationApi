using Bier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.servicesAPI.Basis
{
    public interface IDrinkRepository
    {
        public IEnumerable<Drink> GetAll();
        public Drink GetOne(int id);
        public Drink Insert(Drink entity);
        public Drink Update(int id, Drink drink);
        public Drink Delete(int id);
    }
}
