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
                .Select(o => new PanierGlobal(o.ID, o.Semaine))
                .ToList();

            return pg;
        }

        public PanierGlobal GetByID(int ID)
        {
            var pg = depot.GetByID(ID);

            return new PanierGlobal(pg.ID, pg.Semaine);
        }

        public PanierGlobal GetBySemaine(int semaine)
        {
            var pg = depot.GetByName(semaine.ToString());

            return new PanierGlobal(pg.ID, pg.Semaine);
        }

        public PanierGlobal Insert(PanierGlobal pg)
        {
            var panierg = new PanierGlobal_DAL(pg.Semaine);
            panierg = depot.Insert(panierg);
            pg.ID = panierg.ID;

            return pg;
        }
    }
}
