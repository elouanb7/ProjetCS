using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Offre
    {
        public int ID { get; set; }
        public int IDFournisseur { get; set; }
        public int IDPanierGlobalDetail { get; set; }
        public float? PUHT { get; set; }

        public Offre(int id_fournisseur, int id_panierGlobalDetail, float? puht = null)
            => (IDFournisseur, IDPanierGlobalDetail, PUHT) = (id_fournisseur, id_panierGlobalDetail, puht);
        public Offre(int id, int id_fournisseur, int id_panierGlobalDetail, float? puht = null)
                => (ID, IDFournisseur, IDPanierGlobalDetail, PUHT) = (id, id_fournisseur, id_panierGlobalDetail, puht);
    }
}
