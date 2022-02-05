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
    public class ListeAchatController : Controller
    {
        private IListeAchatService service;
        private IListeAchatDetailsService detailsService;

        public ListeAchatController(IListeAchatService srv, IListeAchatDetailsService dsrv)
        {
            service = srv;
            detailsService = dsrv;
        }

        [HttpGet("all")]
        public IEnumerable<ListeAchat_DTO> GetAllListeAchats()
        {
            var ldetails = detailsService.GetAll();

            return service.GetAll().Select(l => 
                new ListeAchat_DTO()
                {
                    ID = l.ID,
                    IDAdherent = l.IDAdherent,
                    Semaine = l.Semaine,
                    details = ldetails
                    .Where(ld => ld.IDListeAchat == l.IDAdherent)
                    .Select(ld => new ListeAchatDetails_DTO()
                    {
                        IDListeAchat = ld.IDListeAchat,
                        IDReference = ld.IDReference,
                        Quantite = ld.Quantite
                    })
                    .ToArray()
                }
            );
        }

        [HttpGet("{idListeAchat}")]
        public ListeAchat_DTO GetListeAchatsByID([FromRoute] int id)
        {
            var l = service.GetByID(id);

            var ldetails = detailsService.GetByListeAchatID(id);

            return new ListeAchat_DTO()
            {
                ID = l.ID,
                IDAdherent = l.IDAdherent,
                Semaine = l.Semaine,
                details = ldetails
                    .Where(ld => ld.IDListeAchat == l.IDAdherent)
                    .Select(ld => new ListeAchatDetails_DTO()
                    {
                        IDListeAchat = ld.IDListeAchat,
                        IDReference = ld.IDReference,
                        Quantite = ld.Quantite
                    })
                    .ToArray()
            };
        }

        [HttpPost]
        public ListeAchat_DTO Insert(ListeAchat_DTO l)
        {
            var l_metier = service.Insert(new ListeAchat(l.IDAdherent, l.Semaine));
            foreach (var d in l.details)
            {
                detailsService.Insert(new ListeAchatDetails(d.IDListeAchat, d.IDReference, d.Quantite));
            }

            l.ID = l_metier.ID;

            return l;
        }

        [HttpPut]
        public ListeAchat_DTO Update(ListeAchat_DTO l)
        {
            var l_metier = service.Update(new ListeAchat(l.IDAdherent, l.Semaine));
            foreach (var d in l.details)
            {
                detailsService.Update(new ListeAchatDetails(d.IDListeAchat, d.IDReference, d.Quantite));
            }

            l.ID = l_metier.ID;

            return l;
        }
    }
}
