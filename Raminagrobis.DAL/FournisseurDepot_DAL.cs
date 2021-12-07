using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class FournisseurDepot_DAL : Depot_DAL<Fournisseur_DAL>
    {
        public override void Delete(Fournisseur_DAL f)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from fournisseurs where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", f.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le fournisseur d'ID {f.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Fournisseur_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, societe, civilite, nom, prenom, email, adresse, desactive from fournisseurs";
            var reader = commande.ExecuteReader();

            var listeFournisseurs = new List<Fournisseur_DAL>();

            while (reader.Read())
            {
                var f = new Fournisseur_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetInt32(7)
                    );

                listeFournisseurs.Add(f);
            }

            DetruireConnexionEtCommande();

            return listeFournisseurs;
        }

        public override Fournisseur_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, societe, civilite, nom, prenom, email, adresse, desactive from fournisseurs where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeDePoints = new List<Adherent_DAL>();

            Fournisseur_DAL f;
            if (reader.Read())
            {
                f = new Fournisseur_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetInt32(7)
                    );
            }
            else
                throw new Exception($"Pas de fournisseur dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return f;
        }

        public override Fournisseur_DAL Insert(Fournisseur_DAL f)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into fournisseurs(societe, civilite, nom, prenom, email, adresse)"
                                    + " values (@societe, @civilite, @nom, @prenom, @email, @adresse); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@societe", f.Societe));
            commande.Parameters.Add(new SqlParameter("@civilite", f.Civilite));
            commande.Parameters.Add(new SqlParameter("@nom", f.Nom));
            commande.Parameters.Add(new SqlParameter("@prenom", f.Prenom));
            commande.Parameters.Add(new SqlParameter("@email", f.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", f.Adresse));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            f.ID = ID;

            DetruireConnexionEtCommande();

            return f;
        }

        public override Fournisseur_DAL Update(Fournisseur_DAL f)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update fournisseurs set societe=@societe, civilite=@civilite, nom=@nom, prenom=@prenom, email=@email, adresse=@adresse)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", f.ID));
            commande.Parameters.Add(new SqlParameter("@societe", f.Societe));
            commande.Parameters.Add(new SqlParameter("@civilite", f.Civilite));
            commande.Parameters.Add(new SqlParameter("@nom", f.Nom));
            commande.Parameters.Add(new SqlParameter("@prenom", f.Prenom));
            commande.Parameters.Add(new SqlParameter("@email", f.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", f.Adresse));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur d'ID {f.ID}");
            }

            DetruireConnexionEtCommande();

            return f;
        }
    }
}
