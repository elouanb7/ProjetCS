using Raminagrobis.DAL;
using Raminagrobis.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class FournisseurReferenceService : IFournisseurReferenceService
    {
        private FournisseurReferenceDepot_DAL depot = new FournisseurReferenceDepot_DAL();

        public List<FournisseurReference> GetAll()
        {

            var frs = depot.GetAll() //retourne tous les fournisseurs (Fournisseur_DAL) de la BDD
                    .Select(fr => new FournisseurReference(fr.IDFournisseur_DAL, fr.IDReference_DAL))
                    .ToList();

            return frs;
        }

        public FournisseurReference GetLinkByID(int fournisseurID, int referenceID)
        {
            var fr = depot.GetLinkByID(fournisseurID, referenceID);

            return new FournisseurReference(fr.IDFournisseur_DAL, fr.IDReference_DAL);
        }

        public FournisseurReference Insert(FournisseurReference f)
        {
            var fr = new FournisseurReference_DAL(f.IDFournisseur, f.IDReference);
            depot.Insert(fr);

            return f;
        }
    }
}
