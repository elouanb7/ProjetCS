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
        private FournisseurReferenceDepot_DAL depot = new();

        public List<FournisseurReference> GetAll()
        {

            var frs = depot.GetAll() //retourne tous les fournisseurs (Fournisseur_DAL) de la BDD
                    .Select(fr => new FournisseurReference(fr.IDFournisseur_DAL, fr.IDReference_DAL))
                    .ToList();

            return frs;
        }

        public List<FournisseurReference> GetByFournisseurID(int fournisseurID)
        {
            var f = depot.GetByID1(fournisseurID)
                .Select(ld => new FournisseurReference(ld.IDFournisseur_DAL, ld.IDReference_DAL))
                    .ToList();

            return f;
        }

        public List<FournisseurReference> GetByReferenceID(int referenceID)
        {
            var f = depot.GetByID2(referenceID)
                .Select(ld => new FournisseurReference(ld.IDFournisseur_DAL, ld.IDReference_DAL))
                    .ToList();

            return f;
        }

        public FournisseurReference GetLinkByID(int fournisseurID, int referenceID)
        {
            var fr = depot.GetLinkByID(fournisseurID, referenceID);

            return new FournisseurReference(fr.IDFournisseur_DAL, fr.IDReference_DAL);
        }

        public FournisseurReference Insert(FournisseurReference f)
        {
            var fr = new FournisseurReference_DAL(f.IDFournisseur, f.IDReference);
            fr = depot.Insert(fr);

            return f;
        }
    }
}
