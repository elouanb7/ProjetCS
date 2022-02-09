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
    public class OffresController : Controller
    {
        private IOffresService service;

        public OffresController(IOffresService srv)
        {
            service = srv;
        }

        [HttpGet("allOffres")]
        public IEnumerable<Offre_DTO> GetAllOffres()
        {
            return service.GetAll().Select(o => new Offre_DTO()
            {
                ID = o.ID,
                IDFournisseur = o.IDFournisseur,
                IDPanierGlobalDetail = o.IDPanierGlobalDetail,
                PUHT = o.PUHT
            });
        }

        [HttpGet("{idOffre}")]
        public Offre_DTO GetOffreByID([FromRoute] int id)
        {
            var o = service.GetByID(id);

            return new Offre_DTO()
            {
                ID = o.ID,
                IDFournisseur = o.IDFournisseur,
                IDPanierGlobalDetail = o.IDPanierGlobalDetail,
                PUHT = o.PUHT
            };
        }

        [HttpGet("semaineOffre")]
        public IEnumerable<Offre_DTO> GetOffreBySemaine()
        {
            return service.GetBySemaine(0).Select(o => new Offre_DTO()
            {
                ID = o.ID,
                IDFournisseur = o.IDFournisseur,
                IDPanierGlobalDetail = o.IDPanierGlobalDetail,
                PUHT = o.PUHT
            });
        }

        [HttpPost]
        public Offre_DTO InsertOffre(Offre_DTO o)
        {
            var o_metier = service.Insert(new Offre(o.IDFournisseur, o.IDPanierGlobalDetail, o.PUHT != null ? o.PUHT : null));

            o.ID = o_metier.ID;

            return o;
        }

        [HttpPut]
        public Offre_DTO UpdateOffre(Offre_DTO o)
        {
            var o_metier = service.Update(new Offre(o.ID, o.IDFournisseur, o.IDPanierGlobalDetail, o.PUHT));


            o.ID = o_metier.ID;
            o.IDFournisseur = o_metier.IDFournisseur;
            o.IDPanierGlobalDetail = o_metier.IDPanierGlobalDetail;
            o.PUHT = o_metier.PUHT;

            return o;
        }
    }
}
