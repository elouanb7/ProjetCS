using Raminagrobis.DAL;
using Raminagrobis.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Services
{
    public class ListeAchatDetailsService : IListeAchatDetailsService
    {
        private ListeAchatDetailsDepot_DAL depot = new ListeAchatDetailsDepot_DAL();

        public List<ListeAchatDetails> GetAll()
        {

            var l = depot.GetAll() //retourne tous les fournisseurs (Fournisseur_DAL) de la BDD
                    .Select(ld => new ListeAchatDetails(ld.IDListeAchat_DAL, ld.IDReference_DAL, ld.Quantite))
                    .ToList();

            return l;
        }

        public List<ListeAchatDetails> GetByListeAchatID(int ListeAchatID)
        {
            var l = depot.GetByID1(ListeAchatID)
                .Select(ld => new ListeAchatDetails(ld.IDListeAchat_DAL, ld.IDReference_DAL, ld.Quantite))
                    .ToList();

            return l;
        }

        public ListeAchatDetails GetLinkByID(int ListeAchatID, int referenceID)
        {
            var ld = depot.GetLinkByID(ListeAchatID, referenceID);

            return new ListeAchatDetails(ld.IDListeAchat_DAL, ld.IDReference_DAL, ld.Quantite);
        }

        public ListeAchatDetails Insert(ListeAchatDetails l)
        {
            var ld = new ListeAchatDetails_DAL(l.IDListeAchat, l.IDReference, l.Quantite);
            depot.Insert(ld);

            return l;
        }

        public ListeAchatDetails Update(ListeAchatDetails l)
        {
            var ld = new ListeAchatDetails_DAL(l.IDListeAchat, l.IDReference, l.Quantite);
            depot.Update(ld);

            return l;
        }
    }
}
