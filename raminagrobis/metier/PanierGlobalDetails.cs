using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class PanierGlobalDetails
    {
        public int ID { get; set; }
        public int IDPanierGlobal { get; set; }
        public int IDReference { get; set; }
        public int Quantite { get; set; }

        public PanierGlobalDetails(int idPanierGlobal, int idReference, int quantite)
            => (IDPanierGlobal, IDReference, Quantite) = (idPanierGlobal, idReference, quantite);

        public PanierGlobalDetails(int id, int idPanierGlobal, int idReference, int quantite)
            => (ID, IDPanierGlobal, IDReference, Quantite) = (id, idPanierGlobal, idReference, quantite);
    }
}
