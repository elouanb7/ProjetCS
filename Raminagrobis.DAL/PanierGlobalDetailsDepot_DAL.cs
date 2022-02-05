using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PanierGlobalDetailsDepot_DAL : Depot_DAL<PanierGlobalDetails_DAL>
    {
        public override void Delete(PanierGlobalDetails_DAL item)
        {
            throw new NotImplementedException();
        }

        public override List<PanierGlobalDetails_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_panier_global, id_reference, quantite from panier_global_details";
            var reader = commande.ExecuteReader();

            var listePGD = new List<PanierGlobalDetails_DAL>();

            while (reader.Read())
            {
                var p = new PanierGlobalDetails_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)
                    );

                listePGD.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePGD;
        }

        public override PanierGlobalDetails_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_panier_global, id_reference, quantite from panier_global_details where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            PanierGlobalDetails_DAL p;
            if (reader.Read())
            {
                p = new PanierGlobalDetails_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)
                    );
            }
            else
                throw new Exception($"Pas de details de panier global dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return p;
        }

        public PanierGlobalDetails_DAL GetByPanierGlobalID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_panier_global, id_reference, quantite from panier_global_details where id_panier_global=@id_panier_global";
            commande.Parameters.Add(new SqlParameter("@id_panier_global", ID));
            var reader = commande.ExecuteReader();

            PanierGlobalDetails_DAL p;
            if (reader.Read())
            {
                p = new PanierGlobalDetails_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)
                    );
            }
            else
                throw new Exception($"Pas de details de panier global dans la BDD avec l'id_panier_global {ID}");

            DetruireConnexionEtCommande();

            return p;

        }

        public override PanierGlobalDetails_DAL Insert(PanierGlobalDetails_DAL p)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_global_details(id_panier_global, id_reference, quantite)"
                                    + " values (@id_panier_global, @id_reference, @quantite); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_panier_global", p.IDPanierGlobal_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", p.IDReference_DAL));
            commande.Parameters.Add(new SqlParameter("@quantite", p.Quantite));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            p.ID = ID;

            DetruireConnexionEtCommande();

            return p;
        }

        public override PanierGlobalDetails_DAL Update(PanierGlobalDetails_DAL p)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_global_details set id_panier_global=@id_panier_global, id_reference=@id_reference, quantite=@quantite)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", p.ID));
            commande.Parameters.Add(new SqlParameter("@id_panier_global", p.IDPanierGlobal_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", p.IDReference_DAL));
            commande.Parameters.Add(new SqlParameter("@quantite", p.Quantite));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour les details de panier global d'ID {p.ID}");
            }

            DetruireConnexionEtCommande();

            return p;
        }
    }
}
