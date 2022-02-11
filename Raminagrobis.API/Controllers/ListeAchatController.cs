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

        [HttpGet("allListeAchat")]
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
                    .Where(ld => ld.IDListeAchat == l.ID)
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
        public ListeAchat_DTO GetListeAchatByID([FromRoute] int idListeAchat)
        {
            var l = service.GetByID(idListeAchat);

            var ldetails = detailsService.GetByListeAchatID(idListeAchat);

            return new ListeAchat_DTO()
            {
                ID = l.ID,
                IDAdherent = l.IDAdherent,
                Semaine = l.Semaine,
                details = ldetails
                    .Where(ld => ld.IDListeAchat == l.ID)
                    .Select(ld => new ListeAchatDetails_DTO()
                    {
                        IDListeAchat = ld.IDListeAchat,
                        IDReference = ld.IDReference,
                        Quantite = ld.Quantite
                    })
                    .ToArray()
            };
        }
        
        [HttpGet("listeMaxSemaine")]
        public int GetMaxSemaine()
        {
            return service.GetMaxWeek();
        }

        [HttpGet("listeSemaine")]
        public IEnumerable<ListeAchat_DTO> GetMaxSemaineListeAchat()
        {
            var listeDTO = new List<ListeAchat_DTO>();

            int week = service.GetMaxWeek();

            var listes = service.GetAllWhereWeek(week);

            foreach (var l in listes)
            {
                var ldetails = detailsService.GetByListeAchatID(l.ID);
                listeDTO.Add(new ListeAchat_DTO()
                {
                    ID = l.ID,
                    IDAdherent = l.IDAdherent,
                    Semaine = l.Semaine,
                    details = ldetails
                    .Select(ld => new ListeAchatDetails_DTO()
                    {
                        IDListeAchat = ld.IDListeAchat,
                        IDReference = ld.IDReference,
                        Quantite = ld.Quantite
                    })
                    .ToArray()
                });
            }

            return listeDTO;
        }

        [HttpPost]
        public ListeAchat_DTO InsertListeAchat(ListeAchat_DTO l)
        {
            var l_metier = service.Insert(new ListeAchat(l.IDAdherent, l.Semaine));
            l.ID = l_metier.ID;
            for (int i = 0; i < l.details.Length; i++)
            {
                detailsService.Insert(new ListeAchatDetails(l_metier.ID, l.details[i].IDReference, l.details[i].Quantite));
                l.details[i].IDListeAchat = l_metier.ID;
            }

            return l;
        }

        [HttpPut]
        public ListeAchat_DTO UpdateListeAchat(ListeAchat_DTO l)
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
