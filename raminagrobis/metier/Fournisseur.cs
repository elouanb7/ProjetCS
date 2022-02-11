using System;

namespace Raminagrobis
{

    

    public class Fournisseur
    {

        #region champs et accesseurs

        /// <summary>
        /// ID du fournisseur
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Societe du fournisseur
        /// </summary>
        public string Societe { get; set; }

        /// <summary>
        /// Civilite du contact chez le fournisseur (0 = Femme / 1 = Homme)
        /// </summary>
        public bool Civilite { get; set; }

        /// <summary>
        /// Nom du contact chez le fournisseur
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prenom du contact chez le fournisseur
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Mail du fournisseur
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Adresse du fournisseur
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// Booléen informant de l'état du fournisseur (0 = Actif / 1 = Desactivé)
        /// </summary>
        public bool Desactive { get; set; }

        #endregion

        #region Constructeur

        public Fournisseur(string societe, bool civilite, string nom, string prenom, string email, string adresse, bool desactive)
        => (Societe, Civilite, Nom, Prenom, Email, Adresse, Desactive) = (societe, civilite, nom, prenom, email, adresse, desactive);

        /// <summary>
        /// Construit un fournisseur
        /// </summary>
        /// <param name="id">ID du fournisseur (ID)</param>
        /// <param name="societe">Societe du fournisseur (Societe)</param>
        /// <param name="civilite">Civilite du contact chez le fournisseur (Civilite)</param>
        /// <param name="nom">Nom du contact chez le fournisseur (Nom)</param>
        /// <param name="prenom">Prenom du contact chez le fournisseur (Prenom)</param>
        /// <param name="mail">Mail du fournisseur (Mail)</param>
        /// <param name="adresse">Adresse du fournisseur (Adresse)</param>
        /// <param name="desactive">Booléen informant de l'état du fournisseur (Desactive)</param>
        public Fournisseur(int id, string societe, bool civilite, string nom, string prenom, string mail, string adresse, bool desactive)
        => (ID, Societe, Civilite, Nom, Prenom, Email, Adresse, Desactive) = (id, societe, civilite, nom, prenom, mail, adresse, desactive);

        #endregion

        #region Méthodes

        public override string ToString()
        {
            return $"({ID}; {Societe}; {Civilite}; {Nom}; {Prenom}; {Email}; {Adresse}; {Desactive})";
        }
        



        #endregion

    }
}
