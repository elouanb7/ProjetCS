using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class AdherentService : IAdherentService
    {
        private AdherentDepot_DAL depot = new AdherentDepot_DAL();

        public void Delete(Adherent a)
        {
            var adherent = new Adherent_DAL(a.ID, a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.DateAdhesion, a.Desactive);
            depot.Delete(adherent);
        }

        public List<Adherent> GetAll()
        {
            var adherents = depot.GetAll()
                .Select(a => new Adherent(a.ID, a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.Desactive, a.DateAdhesion))
                .ToList();

            return adherents;
        }

        public List<Adherent> GetAllActif()
        {
            var adherents = depot.GetAll() //retourne tous les fournisseurs actifs (Fournisseur_DAL) de la BDD
                    .Where(a => a.Desactive == false) //je ne garde que ceux actifs
                    .Select(a => new Adherent(a.ID, a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.Desactive, a.DateAdhesion))
                    .ToList();

            return adherents;
        }

        public Adherent GetByID(int ID)
        {
            var a = depot.GetByID(ID);

            return new Adherent(a.ID, a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.Desactive, a.DateAdhesion);
        }

        public Adherent Insert(Adherent a)
        {
            var adherent = new Adherent_DAL(a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.DateAdhesion, a.Desactive);
            depot.Insert(adherent);
            adherent.ID = a.ID;

            return a;
        }

        public Adherent Update(Adherent a)
        {
            var adherent = new Adherent_DAL(a.ID, a.Societe, a.Civilite, a.Nom, a.Prenom, a.Email, a.Adresse, a.DateAdhesion, a.Desactive);
            depot.Update(adherent);

            return a;
        }
    }
}
