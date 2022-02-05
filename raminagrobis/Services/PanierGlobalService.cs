using Raminagrobis.DAL;
using Raminagrobis.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Services
{
    public class PanierGlobalService : IPanierGlobalService
    {
        private PanierGlobalDepot_DAL depot = new PanierGlobalDepot_DAL();

        public List<PanierGlobal> GetAll()
        {
            var pg = depot.GetAll()
                .Select(o => new PanierGlobal(o.ID, o.IDListAchat_DAL))
                .ToList();

            return pg;
        }

        public PanierGlobal GetByID(int ID)
        {
            var pg = depot.GetByID(ID);

            return new PanierGlobal(pg.ID, pg.IDListAchat_DAL);
        }

        public PanierGlobal Insert(PanierGlobal pg)
        {
            var panierg = new PanierGlobal_DAL(pg.IDListAchat);
            depot.Insert(panierg);
            panierg.ID = pg.ID;

            return pg;
        }
    }
}
