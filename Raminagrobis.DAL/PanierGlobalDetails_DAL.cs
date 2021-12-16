using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PanierGlobalDetails_DAL
    {
        public int ID { get; set; }
        public int IDPanierGlobal_DAL { get; set; }
        public int IDReference_DAL { get; set; }
        public int Quantite { get; set; }

        public PanierGlobalDetails_DAL(int idPanierGlobal, int idReference, int quantite)
            => (IDPanierGlobal_DAL, IDReference_DAL, Quantite) = (idPanierGlobal, idReference, quantite);

        public PanierGlobalDetails_DAL(int id, int idPanierGlobal, int idReference, int quantite)
            => (ID, IDPanierGlobal_DAL, IDReference_DAL, Quantite) = (id, idPanierGlobal, idReference, quantite);
    }
}
