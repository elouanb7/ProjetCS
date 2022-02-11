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
    public class ReferencesController : Controller
    {
        private IReferenceService service;
        private IFournisseurReferenceService linkService;

        public ReferencesController(IReferenceService srv, IFournisseurReferenceService lsrv)
        {
            service = srv;
            linkService = lsrv;
        }

        [HttpGet("allReferences")]
        public IEnumerable<Reference_DTO> GetAllReferences()
        {
            var liste = new List<Reference_DTO>();
            var references = service.GetAll();
            foreach (var r in references)
            {
                liste.Add(new Reference_DTO()
                {
                    ID = r.ID,
                    ReferenceName = r.ReferenceName,
                    Libelle = r.Libelle,
                    Marque = r.Marque,
                    Desactive = r.Desactive,
                    FournisseurID = linkService.GetByReferenceID(r.ID).Select(l => l.IDFournisseur).ToArray()
                });
            }
            
            return liste;
        }

        [HttpGet("{idReference}")]
        public Reference_DTO GeReferenceByID([FromRoute] int idReference)
        {
            var r = service.GetByID(idReference);

            return new Reference_DTO()
            {
                ID = r.ID,
                ReferenceName = r.ReferenceName,
                Libelle = r.Libelle,
                Marque = r.Marque,
                Desactive = r.Desactive,
                FournisseurID = linkService.GetByReferenceID(r.ID).Select(l => l.IDFournisseur).ToArray()
            };
        }

        [HttpGet("reference")]
        public Reference_DTO GeReferenceByReference([FromBody] string reference)
        {
            var r = service.GetByReference(reference);

            return new Reference_DTO()
            {
                ID = r.ID,
                ReferenceName = r.ReferenceName,
                Libelle = r.Libelle,
                Marque = r.Marque,
                Desactive = r.Desactive,
                FournisseurID = linkService.GetByReferenceID(r.ID).Select(l => l.IDFournisseur).ToArray()
            };
        }

        [HttpGet("referencesActif")]
        public IEnumerable<Reference_DTO> GetAllReferencesActif()
        {
            var liste = new List<Reference_DTO>();
            var references = service.GetAllActif();
            foreach (var r in references)
            {
                liste.Add(new Reference_DTO()
                {
                    ID = r.ID,
                    ReferenceName = r.ReferenceName,
                    Libelle = r.Libelle,
                    Marque = r.Marque,
                    Desactive = r.Desactive,
                    FournisseurID = linkService.GetByReferenceID(r.ID).Select(l => l.IDFournisseur).ToArray()
                });
            }

            return liste;
        }

        [HttpPost]
        public Reference_DTO InsertReference(Reference_DTO r)
        {
            Reference r_metier = service.Insert(new Reference(r.ReferenceName, r.Libelle, r.Marque, r.Desactive));

            r.ID = r_metier.ID;

            foreach (var id in r.FournisseurID)
            {
                linkService.Insert(new FournisseurReference(id, r.ID));
            }

            return r;
        }

        [HttpPut]
        public Reference_DTO UpdateReference(Reference_DTO r)
        {
            var r_metier = service.Update(new Reference(r.ID, r.ReferenceName, r.Libelle, r.Marque, r.Desactive));

            foreach (var item in r.FournisseurID)
            {
                try 
                {
                    linkService.GetLinkByID(item, r_metier.ID);
                }
                catch (Exception)
                {
                    linkService.Insert(new FournisseurReference(item, r_metier.ID));
                }
            }

            r.ID = r_metier.ID;
            r.ReferenceName = r_metier.ReferenceName;
            r.Libelle = r_metier.Libelle;
            r.Marque = r_metier.Marque;
            r.Desactive = r_metier.Desactive;

            return r;
        }
    }
}
