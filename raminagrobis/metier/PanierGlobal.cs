using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class PanierGlobal
    {
        public int ID { get; set; }
        public int Semaine { get; set; }

        public PanierGlobal(int semaine) => (Semaine) = (semaine);
        public PanierGlobal(int id, int semaine) => (ID, Semaine) = (id, semaine);
    }
}
