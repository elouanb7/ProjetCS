using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class ReferenceDepot_DAL : Depot_DAL<Reference_DAL>
    {
        public override void Delete(Reference_DAL item)
        {
            throw new NotImplementedException();
        }

        public override List<Reference_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, reference, libelle, marque, desactive from references";
            var reader = commande.ExecuteReader();

            var listeRef = new List<Reference_DAL>();

            while (reader.Read())
            {
                var f = new Reference_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetBoolean(4)
                    );

                listeRef.Add(f);
            }

            DetruireConnexionEtCommande();

            return listeRef;
        }

        public override Reference_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, reference, libelle, marque, desactive from references where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Reference_DAL r;
            if (reader.Read())
            {
                r = new Reference_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetBoolean(4)
                    );
            }
            else
                throw new Exception($"Pas de reference dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return r;
        }

        public override Reference_DAL Insert(Reference_DAL r)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into references(reference, libelle, marque)"
                                    + " values (@reference, @libelle, @marque); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@reference", r.ReferenceName));
            commande.Parameters.Add(new SqlParameter("@libelle", r.Libelle));
            commande.Parameters.Add(new SqlParameter("@marque", r.Marque));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            r.ID = ID;

            DetruireConnexionEtCommande();

            return r;
        }

        public override Reference_DAL Update(Reference_DAL r)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update references set reference=@reference, libelle=@libelle, marque=@marque)"
                                    + " where ID=@id";
            commande.Parameters.Add(new SqlParameter("@id", r.ID));
            commande.Parameters.Add(new SqlParameter("@reference", r.ReferenceName));
            commande.Parameters.Add(new SqlParameter("@libelle", r.Libelle));
            commande.Parameters.Add(new SqlParameter("@marque", r.Marque));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la référence d'ID {r.ID}");
            }

            DetruireConnexionEtCommande();

            return r;
        }
    }
}
