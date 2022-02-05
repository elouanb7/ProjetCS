using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public abstract class LinkDepot_DAL<Type_DAL> : ILinkDepot_DAL<Type_DAL>
    {
        public string ChaineDeConnexion { get; set; }

        protected SqlConnection connexion;
        protected SqlCommand commande;

        public LinkDepot_DAL()
        {
            var builder = new ConfigurationBuilder();
        var config = builder.AddJsonFile("appsettings.json", false, true).Build();

        ChaineDeConnexion = config.GetSection("ConnectionStrings:default").Value;
        }

    protected void CreerConnexionEtCommande()
    {
        connexion = new SqlConnection(ChaineDeConnexion);
        connexion.Open();
        commande = new SqlCommand();
        commande.Connection = connexion;
    }

    protected void DetruireConnexionEtCommande()
    {
        commande.Dispose();
        connexion.Close();
        connexion.Dispose();
    }

    public abstract List<Type_DAL> GetAll();

    public abstract Type_DAL GetLinkByID(int ID1, int ID2);

    public abstract Type_DAL Insert(Type_DAL item);

    public abstract List<Type_DAL> GetByID1(int ID);

    public abstract List<Type_DAL> GetByID2(int ID);

    public abstract Type_DAL Update(Type_DAL item);
    }
}
