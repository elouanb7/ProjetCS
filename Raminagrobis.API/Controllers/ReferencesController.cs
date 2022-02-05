using Microsoft.AspNetCore.Mvc;
using Raminagrobis.DTO;
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

        public ReferencesController(IReferenceService srv)
        {
            service = srv;
        }

        [HttpGet("all")]
        public IEnumerable<Reference_DTO> GetAllReferences()
        {
            return service.GetAll().Select(r => new Reference_DTO()
            {
                ID = r.ID,
                ReferenceName = r.ReferenceName,
                Libelle = r.Libelle,
                Marque = r.Marque,
                Desactive = r.Desactive
            });
        }

        [HttpGet("{id}")]
        public Reference_DTO GeReferenceByID([FromRoute] int id)
        {
            var r = service.GetByID(id);

            return new Reference_DTO()
            {
                ID = r.ID,
                ReferenceName = r.ReferenceName,
                Libelle = r.Libelle,
                Marque = r.Marque,
                Desactive = r.Desactive
            };
        }

        [HttpGet("actif")]
        public IEnumerable<Reference_DTO> GetAllReferencesActif()
        {
            return service.GetAllActif().Select(r => new Reference_DTO()
            {
                ID = r.ID,
                ReferenceName = r.ReferenceName,
                Libelle = r.Libelle,
                Marque = r.Marque,
                Desactive = r.Desactive
            });
        }

        [HttpPost]
        public Reference_DTO Insert(Reference_DTO r)
        {
            var r_metier = service.Insert(new Reference(r.ReferenceName, r.Libelle, r.Marque, r.Desactive));

            r.ID = r_metier.ID;

            return r;
        }

        [HttpPut]
        public Reference_DTO Update(Reference_DTO r)
        {
            var r_metier = service.Update(new Reference(r.ID, r.ReferenceName, r.Libelle, r.Marque, r.Desactive));

            r.ID = r_metier.ID;
            r.ReferenceName = r_metier.ReferenceName;
            r.Libelle = r_metier.Libelle;
            r.Marque = r_metier.Marque;
            r.Desactive = r_metier.Desactive;

            return r;
        }
    }
}
