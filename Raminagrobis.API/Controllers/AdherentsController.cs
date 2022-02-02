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
    public class AdherentsController : Controller
    {
        private IAdherentService service;
                
        public AdherentsController(IAdherentService srv)
        {
            service = srv;
        }

        [HttpGet("all")]
        public IEnumerable<Adherent_DTO> GetAllAdherents()
        {
            return service.GetAll().Select(a => new Adherent_DTO()
            {
                ID = a.ID,
                Societe = a.Societe,
                Civilite = a.Civilite,
                Nom = a.Nom,
                Prenom = a.Prenom,
                Email = a.Email,
                Adresse = a.Adresse,
                DateAdhesion = a.DateAdhesion,
                Desactive = a.Desactive
            });
        }

        [HttpGet("{id}")]
        public Adherent_DTO GetAdherentsByID([FromRoute] int id)
        {
            var a = service.GetByID(id);

            return new Adherent_DTO()
            {
                ID = a.ID,
                Societe = a.Societe,
                Civilite = a.Civilite,
                Nom = a.Nom,
                Prenom = a.Prenom,
                Email = a.Email,
                Adresse = a.Adresse,
                DateAdhesion = a.DateAdhesion,
                Desactive = a.Desactive
            };
        }

        [HttpGet("actif")]
        public IEnumerable<Adherent_DTO> GetAllAdherentsActif()
        {
            return service.GetAllActif().Select(a => new Adherent_DTO()
            {
                ID = a.ID,
                Societe = a.Societe,
                Civilite = a.Civilite,
                Nom = a.Nom,
                Prenom = a.Prenom,
                Email = a.Email,
                Adresse = a.Adresse,
                DateAdhesion = a.DateAdhesion,
                Desactive = a.Desactive
            });
        }

        [HttpPost]
        public Adherent_DTO Insert(Adherent_DTO a)
        {
            var a_metier = service.Insert(new Adherent(a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.Desactive, a.DateAdhesion));
            
            a.ID = a_metier.ID;

            return a;
        }

        [HttpPut]
        public Adherent_DTO Update(Adherent_DTO a)
        {
            var a_metier = service.Update(new Adherent(a.ID, a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.Desactive, a.DateAdhesion));

            a.ID = a_metier.ID;
            a.Societe = a_metier.Societe;
            a.Civilite = a_metier.Civilite;
            a.Nom = a_metier.Nom;
            a.Prenom = a_metier.Prenom;
            a.Email = a_metier.Email;
            a.Adresse = a_metier.Adresse;
            a.Desactive = a_metier.Desactive;
            a.DateAdhesion = a_metier.DateAdhesion;

            return a;
        }
    }
}
