using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class Adherent
    {
        #region champs et accesseurs

        /// <summary>
        /// ID de l'adherent
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Societe de l'adherent
        /// </summary>
        public string Societe { get; set; }

        /// <summary>
        /// Civilite du contact chez l'adherent (0 = Femme / 1 = Homme)
        /// </summary>
        public bool Civilite { get; set; }

        /// <summary>
        /// Nom du contact chez l'adherent
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prenom du contact chez l'adherent
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Mail de l'adherent
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Adresse de l'adherent
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// Booléen informant de l'état de l'adherent (0 = Actif / 1 = Desactivé)
        /// </summary>
        public bool Desactive { get; set; }

        /// <summary>
        ///  Date d'adhésion
        /// </summary>
        public DateTime DateAdhesion { get; set; }

        #endregion

        #region Constructeur

        public Adherent(string societe, bool civilite, string nom, string prenom, string email, string adresse, bool desactive, DateTime dateAdhesion)
        => (Societe, Civilite, Nom, Prenom, Email, Adresse, Desactive, DateAdhesion) = (societe, civilite, nom, prenom, email, adresse, desactive, dateAdhesion);

        /// <summary>
        /// Construit un adherent
        /// </summary>
        /// <param name="id">ID de l'adherent (ID)</param>
        /// <param name="societe">Societe de l'adherent (Societe)</param>
        /// <param name="civilite">Civilite du contact chez l'adherent (Civilite)</param>
        /// <param name="nom">Nom du contact chez l'adherent (Nom)</param>
        /// <param name="prenom">Prenom du contact chez l'adherent (Prenom)</param>
        /// <param name="mail">Mail de l'adherent (Mail)</param>
        /// <param name="adresse">Adresse de l'adherent (Adresse)</param>
        /// <param name="desactive">Booléen informant de l'état de l'adherent (Desactive)</param>
        /// <param name="dateAdhesion">Date d'adhésion</param>
        public Adherent(int id, string societe, bool civilite, string nom, string prenom, string email, string adresse, bool desactive, DateTime dateAdhesion)
        => (ID, Societe, Civilite, Nom, Prenom, Email, Adresse, Desactive, DateAdhesion) = (id, societe, civilite, nom, prenom, email, adresse, desactive, dateAdhesion);

        #endregion

        #region Méthodes

        public override string ToString()
        {
            return $"({ID}; {Societe}; {Civilite}; {Nom}; {Prenom}; {Email}; {Adresse}; {Desactive}; {DateAdhesion})";
        }
        #endregion

    }
}
