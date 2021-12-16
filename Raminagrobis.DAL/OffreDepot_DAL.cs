using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class OffreDepot_DAL : Depot_DAL<Offre_DAL>
    {
        public override void Delete(Offre_DAL item)
        {
            throw new NotImplementedException();
        }

        public override List<Offre_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_fournisseur, id_panier_global_details, puht from offres";
            var reader = commande.ExecuteReader();

            var listeOffres = new List<Offre_DAL>();

            while (reader.Read())
            {
                var o = new Offre_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetFloat(3)
                    );

                listeOffres.Add(o);
            }

            DetruireConnexionEtCommande();

            return listeOffres;
        }

        public override Offre_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_fournisseur, id_panier_global_details, puht from offres where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Offre_DAL o;
            if (reader.Read())
            {
                o = new Offre_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetFloat(3)
                    );
            }
            else
                throw new Exception($"Pas d'offre dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return o;
        }

        public override Offre_DAL Insert(Offre_DAL o)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into offres(id_fournisseur, id_panier_global_details, puht)"
                                    + " values (@id_fournisseur, @id_panier_global_details, @puht); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_fournisseur", o.IDFournisseur_DAL));
            commande.Parameters.Add(new SqlParameter("@id_panier_global_details", o.IDPanierGlobalDetail_DAL));
            commande.Parameters.Add(new SqlParameter("@puht", o.PUHT));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            o.ID = ID;

            DetruireConnexionEtCommande();

            return o;
        }

        public override Offre_DAL Update(Offre_DAL o)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update offres set id_fournisseur=@id_fournisseur, id_panier_global_details=@id_panier_global_details, puht=@puht)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", o.ID));
            commande.Parameters.Add(new SqlParameter("@id_fournisseur", o.IDFournisseur_DAL));
            commande.Parameters.Add(new SqlParameter("@id_panier_global_details", o.IDPanierGlobalDetail_DAL));
            commande.Parameters.Add(new SqlParameter("@puht", o.PUHT));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'offre  d'ID {o.ID}");
            }

            DetruireConnexionEtCommande();

            return o;
        }
    }
}
