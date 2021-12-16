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
        public override void Delete(ListeAchatDetails_DAL l)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from liste_achats_details where id_liste_achats=@id_liste_achats and id_reference=@id_reference";
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", l.IDListeAchat_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", l.IDReference_DAL));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer les details de la liste d'achat d'IDListeAchat {l.IDListeAchat_DAL} et d'IDReference {l.IDReference_DAL}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<ListeAchatDetails_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_liste_achats from, id_reference, quantite liste_achats_details";
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

        public override ListeAchatDetails_DAL Insert(ListeAchatDetails_DAL l)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into liste_achats_details(id_liste_achats, id_reference, quantite)"
                                    + " values (@id_liste_achats, @id_reference, @quantite);";
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", l.IDListeAchat_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", l.IDReference_DAL));
            commande.Parameters.Add(new SqlParameter("@quantite", l.Quantite));

            DetruireConnexionEtCommande();

            return l;
        }

        public override ListeAchatDetails_DAL Update(ListeAchatDetails_DAL l)
        {

            CreerConnexionEtCommande();

            commande.CommandText = "update liste_achats_details set id_liste_achats=@id_liste_achats, id_reference=@id_reference, quantite=@quantite)"
                                    + " where id_liste_achats=@id_liste_achats and id_reference=@id_reference";
            commande.Parameters.Add(new SqlParameter("@id_liste_achats", l.IDListeAchat_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", l.IDReference_DAL));
            commande.Parameters.Add(new SqlParameter("@quantite", l.Quantite));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour les details de la liste d'achat d'IDListeAchat {l.IDListeAchat_DAL} et d'IDReference {l.IDReference_DAL}");
            }

            DetruireConnexionEtCommande();

            return l;
        }
    }
}
