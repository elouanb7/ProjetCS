using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    class Adherent_DAL
    {
        public int ID { get; private set; }
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Adresse { get; set; }
        //ajouter la date
        public bool Desactive { get; set; }

        public Adherent_DAL(string societe, bool civilite, string nom, string prenom, string mail, string adresse, bool desactive)
            => (Societe, Civilite, Nom, Prenom, Mail, Adresse, Desactive) = (societe, civilite, nom, prenom, mail, adresse, desactive);

        public Adherent_DAL(int id, string societe, bool civilite, string nom, string prenom, string mail, string adresse, bool desactive)
            => (ID, Societe, Civilite, Nom, Prenom, Mail, Adresse, Desactive) = (id, societe, civilite, nom, prenom, mail, adresse, desactive);

    }
}
