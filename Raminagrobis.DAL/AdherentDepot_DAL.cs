using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class AdherentDepot_DAL : Depot_DAL<Adherent_DAL>
    {
        public override void Delete(Adherent_DAL a)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", a.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adherent d'ID {a.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, societe, civilite, nom, prenom, email, adresse, date_adhesion, desactive from adherents";
            var reader = commande.ExecuteReader();

            var listeAdherents = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var a = new Adherent_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetBoolean(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetDateTime(7),
                    reader.GetBoolean(8)
                    );

                listeAdherents.Add(a);
            }

            DetruireConnexionEtCommande();

            return listeAdherents;
        }

        public override Adherent_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, societe, civilite, nom, prenom, email, adresse, date_adhesion, desactive from adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeDePoints = new List<Adherent_DAL>();

            Adherent_DAL a;
            if (reader.Read())
            {
                a = new Adherent_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetBoolean(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetDateTime(7),
                    reader.GetBoolean(8)
                    );
            }
            else
                throw new Exception($"Pas d'adherent dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return a;
        }

        public override Adherent_DAL Insert(Adherent_DAL a)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into adherents(societe, civilite, nom, prenom, email, adresse, date_adhesion)"
                                    + " values (@societe, @civilite, @nom, @prenom, @email, @adresse, @dateAdhesion); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@societe", a.Societe));
            commande.Parameters.Add(new SqlParameter("@civilite", a.Civilite));
            commande.Parameters.Add(new SqlParameter("@nom", a.Nom));
            commande.Parameters.Add(new SqlParameter("@prenom", a.Prenom));
            commande.Parameters.Add(new SqlParameter("@email", a.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", a.Adresse));
            commande.Parameters.Add(new SqlParameter("@dateAdhesion", a.DateAdhesion));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            a.ID = ID;

            DetruireConnexionEtCommande();

            return a;
        }

        public override Adherent_DAL Update(Adherent_DAL a)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update adherents set societe=@societe, civilite=@civilite, nom=@nom, prenom=@prenom, email=@email, adresse=@adresse, date_adhesion=@dateAdhesion)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", a.ID));
            commande.Parameters.Add(new SqlParameter("@societe", a.Societe));
            commande.Parameters.Add(new SqlParameter("@civilite", a.Civilite));
            commande.Parameters.Add(new SqlParameter("@nom", a.Nom));
            commande.Parameters.Add(new SqlParameter("@prenom", a.Prenom));
            commande.Parameters.Add(new SqlParameter("@email", a.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", a.Adresse));
            commande.Parameters.Add(new SqlParameter("@dateAdhesion", a.DateAdhesion));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'adherent d'ID {a.ID}");
            }

            DetruireConnexionEtCommande();

            return a;
        }
    }
}
