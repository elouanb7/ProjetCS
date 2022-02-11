using Microsoft.AspNetCore.Mvc;
using Raminagrobis.DTO;
using Raminagrobis.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raminagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PanierGlobalController : Controller
    {
        private IPanierGlobalService service;
        private IPanierGlobalDetailsService detailsService;

        public PanierGlobalController(IPanierGlobalService srv, IPanierGlobalDetailsService dsrv)
        {
            service = srv;
            detailsService = dsrv;
        }

        [HttpGet("allPanierGlobal")]
        public IEnumerable<PanierGlobal_DTO> GetAllPanierGlobal()
        {
            var ldetails = detailsService.GetAll();

            return service.GetAll().Select(pg =>
                new PanierGlobal_DTO()
                {
                    ID = pg.ID,
                    Semaine= pg.Semaine,
                    Details = ldetails
                    .Where(pd => pd.IDPanierGlobal == pg.ID)
                    .Select(pd => new PanierGlobalDetails_DTO()
                    {
                        ID = pd.ID,
                        IDPanierGlobal= pd.IDPanierGlobal,
                        IDReference = pd.IDReference,
                        Quantite = pd.Quantite
                    })
                    .ToArray()
                }
            );
        }

        [HttpGet("{idPanierGlobal}")]
        public PanierGlobal_DTO GetPanierGlobalByID([FromRoute] int id)
        {
            var pg = service.GetByID(id);

            var ldetails = detailsService.GetByPanierGlobalID(id);

            return new PanierGlobal_DTO()
            {
                ID = pg.ID,
                Semaine = pg.Semaine,
                Details = ldetails
                    .Where(pd => pd.IDPanierGlobal == pg.ID)
                    .Select(pd => new PanierGlobalDetails_DTO()
                    {
                        ID = pd.ID,
                        IDPanierGlobal = pd.IDPanierGlobal,
                        IDReference = pd.IDReference,
                        Quantite = pd.Quantite
                    })
                    .ToArray()
            };
        }

        [HttpGet("semainePanier")]
        public PanierGlobal_DTO GetPanierGlobalBySemaine([FromBody] int semaine) // get panier by semaine
        {
            var pg = service.GetBySemaine(semaine);

            var ldetails = detailsService.GetByPanierGlobalID(pg.ID);

            return new PanierGlobal_DTO()
            {
                ID = pg.ID,
                Semaine = pg.Semaine,
                Details = ldetails
                    .Where(pd => pd.IDPanierGlobal == pg.ID)
                    .Select(pd => new PanierGlobalDetails_DTO()
                    {
                        ID = pd.ID,
                        IDPanierGlobal = pd.IDPanierGlobal,
                        IDReference = pd.IDReference,
                        Quantite = pd.Quantite
                    })
                    .ToArray()
            };
        }

        [HttpPost]
        public PanierGlobal_DTO InsertPanierGlobal(PanierGlobal_DTO p)
        {
            var p_metier = service.Insert(new PanierGlobal(p.Semaine));
            p.ID = p_metier.ID;
            for (int i = 0; i < p.Details.Length; i++)
            {
                var pd_metier = detailsService.Insert(new PanierGlobalDetails(p_metier.ID, p.Details[i].IDReference, p.Details[i].Quantite));
                p.Details[i].IDPanierGlobal = p_metier.ID;
                p.Details[i].ID = pd_metier.ID;
            }

            return p;
        }
    }
}
