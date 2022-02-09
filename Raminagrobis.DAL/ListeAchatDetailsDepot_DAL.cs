using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class ListeAchatDetailsDepot_DAL : Depot_DAL<ListeAchatDetails_DAL>
    {
        public override void Delete(ListeAchatDetails_DAL item)
        {
            throw new NotImplementedException();
        }

        public override List<ListeAchatDetails_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from liste_achats_details";
            var reader = commande.ExecuteReader();

            var listeLAD = new List<ListeAchatDetails_DAL>();

            while (reader.Read())
            {
                var l = new ListeAchatDetails_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2)
                    );

                listeLAD.Add(l);
            }

            DetruireConnexionEtCommande();

            return listeLAD;
        }

        public override ListeAchatDetails_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public override List<ListeAchatDetails_DAL> GetByID1(int listeAchatID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from liste_achats_details where id_liste_achats=@id_liste_achats";
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", listeAchatID));
            var reader = commande.ExecuteReader();

            var listeLAD = new List<ListeAchatDetails_DAL>();
            while (reader.Read())
            {
                var l = new ListeAchatDetails_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2)
                    );

                listeLAD.Add(l);
            }
            DetruireConnexionEtCommande();

            return listeLAD;
        }

        public override List<ListeAchatDetails_DAL> GetByID2(int referenceID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from liste_achats_details where id_reference=@id_reference";
            commande.Parameters.Add(new SqlParameter("@id_reference", referenceID));
            var reader = commande.ExecuteReader();

            var listeLAD = new List<ListeAchatDetails_DAL>();
            while (reader.Read())
            {
                var l = new ListeAchatDetails_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2)
                    );

                listeLAD.Add(l);
            }
            DetruireConnexionEtCommande();

            return listeLAD;
        }

        public override ListeAchatDetails_DAL GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override ListeAchatDetails_DAL GetLinkByID(int ID1, int ID2)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select * from liste_achats_details where id_liste_achats=@id_liste_achats and id_reference=@id_reference";
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", ID1));
            commande.Parameters.Add(new SqlParameter("@id_reference", ID2));
            var reader = commande.ExecuteReader();

            ListeAchatDetails_DAL f;
            if (reader.Read())
            {
                f = new ListeAchatDetails_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2)
                    );
            }
            else
                throw new Exception($"Pas de ListeAchatDetails dans la BDD avec l'ID_liste_achats {ID1} et  l'ID_reference {ID2}");

            DetruireConnexionEtCommande();

            return f;
        }

        public override ListeAchatDetails_DAL Insert(ListeAchatDetails_DAL l)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into liste_achats_details(id_liste_achats, id_reference, quantite)"
                                    + " values (@id_liste_achats, @id_reference, @quantite)";
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", l.IDListeAchat_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", l.IDReference_DAL));
            commande.Parameters.Add(new SqlParameter("@quantite", l.Quantite));

            commande.ExecuteScalar();

            DetruireConnexionEtCommande();

            return l;
        }

        public override ListeAchatDetails_DAL Update(ListeAchatDetails_DAL l)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update liste_achats_details set id_liste_achats=@id_liste_achats, id_reference=@id_reference, quantite=@quantite)"
                                    + "  id_liste_achats=@id_liste_achats and id_reference=@id_reference";
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", l.IDListeAchat_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", l.IDReference_DAL));
            commande.Parameters.Add(new SqlParameter("@quantite", l.Quantite));
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", l.IDListeAchat_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", l.IDReference_DAL));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour les details de la liste d'achat avec l'ID_liste_achats {l.IDListeAchat_DAL} et  l'ID_reference {l.IDReference_DAL}");
            }

            DetruireConnexionEtCommande();

            return l;
        }
    }
}
