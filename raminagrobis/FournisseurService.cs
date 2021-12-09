using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class FournisseurService : IFournisseurService
    {
        private FournisseurDepot_DAL depot = new FournisseurDepot_DAL();

        public List<Fournisseur> GetAll()
        {
            var fournisseurs = depot.GetAll() //retourne tous les fournisseurs (Fournisseur_DAL) de la BDD
                    .Select(f => new Fournisseur(f.ID, f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive))
                    .ToList();

            return fournisseurs;
        }

        public List<Fournisseur> GetAllActif()
        {
            var fournisseurs = depot.GetAll() //retourne tous les fournisseurs actifs (Fournisseur_DAL) de la BDD
                    .Where(f => f.Desactive == false) //je ne garde que ceux actifs
                    .Select(f => new Fournisseur(f.ID, f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive))
                    .ToList();

            return fournisseurs;
        }

        public Fournisseur GetByID(int ID)
        {
            var f = depot.GetByID(ID);

            return new Fournisseur(f.ID, f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive);
        }

        public Fournisseur Insert(Fournisseur f)
        {
            var fournisseur = new Fournisseur_DAL(f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive);
            depot.Insert(fournisseur);

            fournisseur.ID = f.ID;

            return f;
        }

        public Fournisseur Update(Fournisseur f)
        {
            var fournisseur = new Fournisseur_DAL(f.ID, f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive);
            depot.Update(fournisseur);

            return f;
        }

        public void Delete(Fournisseur f)
        {
            var fournisseur = new Fournisseur_DAL(f.ID, f.Societe, f.Civilite, f.Nom, f.Prenom, f.Email, f.Adresse, f.Desactive);
            depot.Delete(fournisseur);
        }
    }
}
