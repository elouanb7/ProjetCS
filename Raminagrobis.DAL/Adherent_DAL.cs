using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Adherent_DAL
    {
        public int ID { get; set; }
        public string Societe { get; set; }
        public int Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public DateTime DateAdhesion { get; set; }
        public int Desactive { get; set; }

        public Adherent_DAL(string societe, int civilite, string nom, string prenom, string mail, string adresse, DateTime dateAdhesion, int desactive)
            => (Societe, Civilite, Nom, Prenom, Email, Adresse, DateAdhesion, Desactive) = (societe, civilite, nom, prenom, mail, adresse, dateAdhesion, desactive);

        public Adherent_DAL(int id, string societe, int civilite, string nom, string prenom, string mail, string adresse, DateTime dateAdhesion, int desactive)
            => (ID, Societe, Civilite, Nom, Prenom, Email, Adresse, DateAdhesion, Desactive) = (id, societe, civilite, nom, prenom, mail, adresse, dateAdhesion, desactive);

    }
}
