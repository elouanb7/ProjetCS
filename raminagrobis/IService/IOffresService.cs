using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.IService
{
    public interface IOffresService
    {
        public List<Offre> GetAll();
        public Offre GetByID(int ID);
        public List<Offre> GetBySemaine(int semaine);
        public Offre Insert(Offre o);
        public Offre Update(Offre o);
    }
}
