using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Fournisseur_DAL
    {
        public int ID { get; set; }
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public bool Desactive { get; set; }

        public Fournisseur_DAL(string societe, bool civilite, string nom, string prenom, string mail, string adresse, bool desactive)
            => (Societe, Civilite, Nom, Prenom, Email, Adresse, Desactive) = (societe, civilite, nom, prenom, mail, adresse, desactive);

        public Fournisseur_DAL(int id, string societe, bool civilite, string nom, string prenom, string mail, string adresse, bool desactive)
            => (ID, Societe, Civilite, Nom, Prenom, Email, Adresse, Desactive) = (id, societe, civilite, nom, prenom, mail, adresse, desactive);

    }
}
