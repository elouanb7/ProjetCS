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
    public class FournisseursController : Controller
    {
        private IFournisseurService service;
        
        public FournisseursController(IFournisseurService srv)
        {
            service = srv;
        }

        [HttpGet("allFournisseurs")]
        public IEnumerable<Fournisseur_DTO> GetAllFournisseurs()
        {
            return service.GetAll().Select(f => new Fournisseur_DTO()
            {
                ID = f.ID,
                Societe = f.Societe,
                Civilite = f.Civilite,
                Nom = f.Nom,
                Prenom = f.Prenom,
                Email = f.Email,
                Adresse = f.Adresse,
                Desactive = f.Desactive
            });
        }

        [HttpGet("{idFournisseur}")]
        public Fournisseur_DTO GetFournisseurByID([FromRoute] int idFournisseur)
        {
            var f = service.GetByID(idFournisseur);

            return new Fournisseur_DTO()
            {
                ID = f.ID,
                Societe = f.Societe,
                Civilite = f.Civilite,
                Nom = f.Nom,
                Prenom = f.Prenom,
                Email = f.Email,
                Adresse = f.Adresse,
                Desactive = f.Desactive
            };
        }

        [HttpGet("societeFournisseur")]
        public Fournisseur_DTO GetFournisseurBySociete([FromBody] string societeFournisseur)
        {
            var f = service.GetBySociete(societeFournisseur);

            return new Fournisseur_DTO()
            {
                ID = f.ID,
                Societe = f.Societe,
                Civilite = f.Civilite,
                Nom = f.Nom,
                Prenom = f.Prenom,
                Email = f.Email,
                Adresse = f.Adresse,
                Desactive = f.Desactive
            };
        }

        [HttpGet("fournisseurActif")]
        public IEnumerable<Fournisseur_DTO> GetAllFournisseursActif()
        {
            return service.GetAllActif().Select(f => new Fournisseur_DTO()
            {
                ID = f.ID,
                Societe = f.Societe,
                Civilite = f.Civilite,
                Nom = f.Nom,
                Prenom = f.Prenom,
                Email = f.Email,
                Adresse = f.Adresse,
                Desactive = f.Desactive
            });
        }

        [HttpPost]
        public Fournisseur_DTO InsertFournisseur(Fournisseur_DTO f)
        {
            var f_metier = service.Insert(new Fournisseur(f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive));

            f.ID = f_metier.ID;

            return f;
        }

        [HttpPut]
        public Fournisseur_DTO UpdateFournisseur(Fournisseur_DTO f)
        {
            var f_metier = service.Update(new Fournisseur(f.ID, f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive));

            f.ID = f_metier.ID;
            f.Societe = f_metier.Societe;
            f.Civilite = f_metier.Civilite;
            f.Nom = f_metier.Nom;
            f.Prenom = f_metier.Prenom;
            f.Email = f_metier.Email;
            f.Adresse = f_metier.Adresse;
            f.Desactive = f_metier.Desactive;

            return f;
        }
    }
}
