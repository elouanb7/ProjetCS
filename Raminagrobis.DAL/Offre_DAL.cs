using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Offre_DAL
    {
        public int ID { get; set; }
        public int IDFournisseur_DAL { get; set; }
        public int IDPanierGlobalDetail_DAL { get; set; }
        public float? PUHT { get; set; }

        public Offre_DAL(int id_fournisseur, int id_panierGlobalDetail, float? puht = null)
            => (IDFournisseur_DAL, IDPanierGlobalDetail_DAL, PUHT) = (id_fournisseur, id_panierGlobalDetail, puht);
        public Offre_DAL(int id, int id_fournisseur, int id_panierGlobalDetail, float? puht = null)
                => (ID, IDFournisseur_DAL, IDPanierGlobalDetail_DAL, PUHT) = (id, id_fournisseur, id_panierGlobalDetail, puht);
    }
}
