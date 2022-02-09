using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PanierGlobal_DAL
    {
        public int ID { get; set; }
        public int Semaine { get; set; }

        public PanierGlobal_DAL(int semaine) => Semaine = (semaine);
        public PanierGlobal_DAL(int id, int semaine) => (ID, Semaine) = (id, semaine);
    }
}
