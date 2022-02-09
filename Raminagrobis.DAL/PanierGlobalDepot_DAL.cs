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

            commande.CommandText = "select id, semaine from panier_global";
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

            commande.CommandText = "select id, semaine from panier_global where ID=@ID";
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

        public override List<PanierGlobal_DAL> GetByID1(int ID)
        {
            throw new NotImplementedException();
        }

        public override List<PanierGlobal_DAL> GetByID2(int ID)
        {
            throw new NotImplementedException();
        }

        public override PanierGlobal_DAL GetByName(string name)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, semaine from panier_global where semaine=@semaine";
            commande.Parameters.Add(new SqlParameter("@semaine", name));
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
                throw new Exception($"Pas de panier global dans la BDD avec la semaine {name}");

            DetruireConnexionEtCommande();

            return o;
        }

        public override PanierGlobal_DAL GetLinkByID(int ID1, int ID2)
        {
            throw new NotImplementedException();
        }

        public override PanierGlobal_DAL Insert(PanierGlobal_DAL p)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into panier_global(semaine)"
                                    + " values (@semaine); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@semaine", p.Semaine));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            p.ID = ID;

            DetruireConnexionEtCommande();

            return p;
        }

        public override PanierGlobal_DAL Update(PanierGlobal_DAL p)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update panier_global set semaine=@semaine)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", p.ID));
            commande.Parameters.Add(new SqlParameter("@semaine", p.Semaine));
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
