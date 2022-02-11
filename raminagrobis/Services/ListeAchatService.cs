using Raminagrobis.DAL;
using Raminagrobis.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Services
{
    public class ListeAchatService : IListeAchatService
    {
        private ListeAchatDepot_DAL depot = new ListeAchatDepot_DAL();

        public List<ListeAchat> GetAll()
        {
            var l = depot.GetAll() //retourne tous les fournisseurs (Fournisseur_DAL) de la BDD
                    .Select(l => new ListeAchat(l.ID, l.IDAdherent_DAL, l.Semaine))
                    .ToList();

            return l;
        }

        public ListeAchat GetByID(int ID)
        {
            var l = depot.GetByID(ID);

            return new ListeAchat(l.ID, l.IDAdherent_DAL, l.Semaine);
        }

        public int GetMaxWeek()
        {
            var l = depot.GetByName("");

            return l.Semaine;
        }

        public List<ListeAchat> GetAllWhereWeek(int semaine)
        {
            var l = depot.GetByID1(semaine) //retourne tous les fournisseurs (Fournisseur_DAL) de la BDD
                    .Select(l => new ListeAchat(l.ID, l.IDAdherent_DAL, l.Semaine))
                    .ToList();

            return l;
        }

        public ListeAchat Insert(ListeAchat l)
        {
            var la = new ListeAchat_DAL(l.IDAdherent, l.Semaine);
            la = depot.Insert(la);

            l.ID = la.ID;

            return l;
        }

        public ListeAchat Update(ListeAchat l)
        {
            var la = new ListeAchat_DAL(l.IDAdherent, l.Semaine);
            depot.Update(la);

            return l;
        }
    }
}
