using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class ListeAchatDepot_DAL : Depot_DAL<ListeAchat_DAL>
    {
        public override void Delete(ListeAchat_DAL item)
        {
            throw new NotImplementedException();
        }

        public override List<ListeAchat_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_adherent, semaine from liste_achats";
            var reader = commande.ExecuteReader();

            var liste = new List<ListeAchat_DAL>();

            while (reader.Read())
            {
                var o = new ListeAchat_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2)
                    );

                liste.Add(o);
            }

            DetruireConnexionEtCommande();

            return liste;
        }

        public override ListeAchat_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, id_adherent, semaine from liste_achats where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            ListeAchat_DAL o;
            if (reader.Read())
            {
                o = new ListeAchat_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2)
                    );
            }
            else
                throw new Exception($"Pas de lsite d'achats dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return o;
        }

        public override ListeAchat_DAL Insert(ListeAchat_DAL l)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into liste_achats(id_adherent, semaine)"
                                    + " values (@id_adherent, @semaine); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id_adherent", l.IDAdherent_DAL));
            commande.Parameters.Add(new SqlParameter("@semaine", l.Semaine));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            l.ID = ID;

            DetruireConnexionEtCommande();

            return l;
        }

        public override ListeAchat_DAL Update(ListeAchat_DAL l)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update liste_achats set id_adherent=@id_adherent, semaine=@semaine)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", l.ID));
            commande.Parameters.Add(new SqlParameter("@id_adherent", l.IDAdherent_DAL));
            commande.Parameters.Add(new SqlParameter("@semaine", l.Semaine));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la liste d'achat  d'ID {l.ID}");
            }

            DetruireConnexionEtCommande();

            return l;
        }
    }
}
