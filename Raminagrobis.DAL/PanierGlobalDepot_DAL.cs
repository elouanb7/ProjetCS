using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PanierGlobalDepot_DAL : Depot_DAL<PanierGlobal_DAL>
    {
        public override void Delete(PanierGlobal_DAL item)
        {
            throw new NotImplementedException();
        }

        public override List<PanierGlobal_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_liste_achat from panier_global";
            var reader = commande.ExecuteReader();

            var listePanier = new List<PanierGlobal_DAL>();

            while (reader.Read())
            {
                var p = new PanierGlobal_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1)
                    );

                listePanier.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePanier;
        }

        public override PanierGlobal_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_liste_achat from panier_global where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            PanierGlobal_DAL o;
            if (reader.Read())
            {
                o = new PanierGlobal_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1)
                    );
            }
            else
                throw new Exception($"Pas de panier global dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return o;
        }

        public override PanierGlobal_DAL Insert(PanierGlobal_DAL p)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_global(id_liste_achat)"
                                    + " values (@id_liste_achat); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_liste_achat", p.IDListAchat_DAL));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            p.ID = ID;

            DetruireConnexionEtCommande();

            return p;
        }

        public override PanierGlobal_DAL Update(PanierGlobal_DAL p)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_global set id_liste_achat=@id_liste_achat)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", p.ID));
            commande.Parameters.Add(new SqlParameter("@id_liste_achat", p.IDListAchat_DAL));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier global  d'ID {p.ID}");
            }

            DetruireConnexionEtCommande();

            return p;
        }
    }
}
