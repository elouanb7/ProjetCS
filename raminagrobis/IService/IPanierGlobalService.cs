using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.IService
{
    public interface IPanierGlobalService
    {
        public List<PanierGlobal> GetAll();
        public PanierGlobal GetByID(int ID);
        public PanierGlobal GetBySemaine(int semaine);
        public PanierGlobal Insert(PanierGlobal pg);
    }
}
