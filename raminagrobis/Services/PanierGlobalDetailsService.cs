using Raminagrobis.DAL;
using Raminagrobis.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Services
{
    public class PanierGlobalDetailsService : IPanierGlobalDetailsService
    {
        private PanierGlobalDetailsDepot_DAL depot = new PanierGlobalDetailsDepot_DAL();

        public List<PanierGlobalDetails> GetAll()
        {
            var pg = depot.GetAll()
                .Select(p => new PanierGlobalDetails(p.ID, p.IDPanierGlobal_DAL, p.IDReference_DAL, p.Quantite))
                .ToList();

            return pg;
        }

        public PanierGlobalDetails GetByID(int ID)
        {
            var pg = depot.GetByID(ID);

            return new PanierGlobalDetails(pg.ID, pg.IDPanierGlobal_DAL, pg.IDReference_DAL, pg.Quantite);
        }

        public PanierGlobalDetails GetByPanierGlobalID(int ID)
        {
            var pg = depot.GetByID(ID);

            return new PanierGlobalDetails(pg.ID, pg.IDPanierGlobal_DAL, pg.IDReference_DAL, pg.Quantite);
        }

        public PanierGlobalDetails Insert(PanierGlobalDetails pg)
        {
            var panierg = new PanierGlobalDetails_DAL(pg.IDPanierGlobal, pg.IDReference, pg.Quantite);
            depot.Insert(panierg);
            panierg.ID = pg.ID;

            return pg;
        }
    }
}
