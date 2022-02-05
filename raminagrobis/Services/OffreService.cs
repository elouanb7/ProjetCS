using Raminagrobis.DAL;
using Raminagrobis.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Services
{
    public class OffreService : IOffresService
    {
        private OffreDepot_DAL depot = new OffreDepot_DAL();

        public List<Offre> GetAll()
        {
            var offres = depot.GetAll()
                .Select(o => new Offre(o.ID, o.IDFournisseur_DAL, o.IDPanierGlobalDetail_DAL, o.PUHT))
                .ToList();

            return offres;
        }

        public Offre GetByID(int ID)
        {
            var o = depot.GetByID(ID);

            return new Offre(o.ID, o.IDFournisseur_DAL, o.IDPanierGlobalDetail_DAL, o.PUHT);
        }

        public Offre Insert(Offre o)
        {
            var offre = new Offre_DAL(o.IDFournisseur, o.IDPanierGlobalDetail, o.PUHT);
            depot.Insert(offre);
            offre.ID = o.ID;

            return o;
        }

        public Offre Update(Offre o)
        {
            var offre = new Offre_DAL(o.ID, o.IDFournisseur, o.IDPanierGlobalDetail, o.PUHT);
            depot.Update(offre);

            return o;
        }
    }
}
