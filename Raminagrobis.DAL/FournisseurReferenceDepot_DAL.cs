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
        public override void Delete(FournisseurReference_DAL item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override List<FournisseurReference_DAL> GetByID1(int fournisseurID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_fournisseur, id_reference from fournisseurs_references where id_fournisseur=@id_fournisseur";
            commande.Parameters.Add(new SqlParameter("@id_fournisseur", fournisseurID));
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

        public override List<FournisseurReference_DAL> GetByID2(int referenceID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_fournisseur, id_reference from fournisseurs_references where id_reference=@id_reference";
            commande.Parameters.Add(new SqlParameter("@id_reference", referenceID));
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

        public override FournisseurReference_DAL GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public override FournisseurReference_DAL GetLinkByID(int ID1, int ID2)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_fournisseur, id_reference from fournisseurs_references where id_fournisseur=@id_fournisseur and id_reference=@id_reference";
            commande.Parameters.Add(new SqlParameter("@id_fournisseur", ID1));
            commande.Parameters.Add(new SqlParameter("@id_reference", ID2));
            var reader = commande.ExecuteReader();

            FournisseurReference_DAL f;
            if (reader.Read())
            {
                f = new FournisseurReference_DAL(
                    reader.GetInt32(0),
                    reader.GetInt32(1)
                    );
            }
            else
                throw new Exception($"Pas de FournisseurReference dans la BDD avec l'ID_fournisseur {ID1} et  l'ID_reference {ID2}");

            DetruireConnexionEtCommande();

            return f;
        }

        public override FournisseurReference_DAL Insert(FournisseurReference_DAL f)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into fournisseurs_references(id_fournisseur, id_reference)"
                                    + " values (@id_fournisseur, @id_reference);";
            commande.Parameters.Add(new SqlParameter("@id_fournisseur", f.IDFournisseur_DAL));
            commande.Parameters.Add(new SqlParameter("@id_reference", f.IDReference_DAL));

            commande.ExecuteScalar();

            DetruireConnexionEtCommande();

            return f;
        }

        public override FournisseurReference_DAL Update(FournisseurReference_DAL item)
        {
            throw new NotImplementedException();
        }
    }
}
