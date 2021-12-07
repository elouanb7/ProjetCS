using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class FournisseurReferenceDepot_DAL : Depot_DAL<FournisseurReference_DAL>
    {
        public override void Delete(FournisseurReference_DAL f)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from adherents where id_fournisseur=@IDFournisseur_DAL and id_reference=@IDReference_DAL";
            commande.Parameters.Add(new SqlParameter("@IDFournisseur_DAL", f.IDFournisseur_DAL));
            commande.Parameters.Add(new SqlParameter("@IDReference_DAL", f.IDReference_DAL));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le FournisseurReference d'ID_fournisseur {f.IDFournisseur_DAL} et d'ID_reference {f.IDReference_DAL}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<FournisseurReference_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_fournisseur, id_reference from fournisseurs_references";
            var reader = commande.ExecuteReader();

            var listeFR = new List<FournisseurReference_DAL>();

            while (reader.Read())
            {
                var f = new FournisseurReference_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1)
                    );

                listeFR.Add(f);
            }

            DetruireConnexionEtCommande();

            return listeFR;
        }

        public override FournisseurReference_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, societe, civilite, nom, prenom, email, adresse, dateAdhesion, desactive from adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listeDePoints = new List<Adherent_DAL>();

            FournisseurReference_DAL f;
            if (reader.Read())
            {
                f = new FournisseurReference_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1)
                    );
            }
            else
                throw new Exception($"Pas de FournisseurReference dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return f;
        }

        public override FournisseurReference_DAL Insert(FournisseurReference_DAL f)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into fournisseurs_references(id_fournisseur, id_reference)"
                                    + " values (@id_fournisseur, @id_reference); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_fournisseur", f.IDFournisseur_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", f.IDReference_DAL));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            DetruireConnexionEtCommande();

            return f;
        }

        public override FournisseurReference_DAL Update(FournisseurReference_DAL item)
        {
            throw new NotImplementedException();
        }
    }
}
