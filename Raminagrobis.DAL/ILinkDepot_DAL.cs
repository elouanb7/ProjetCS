using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    interface ILinkDepot_DAL<Type_DAL>
    {
        public string ChaineDeConnexion { get; set; }

        public List<Type_DAL> GetAll();

        public Type_DAL GetLinkByID(int ID1, int ID2);

        public List<Type_DAL> GetByID1(int ID);

        public List<Type_DAL> GetByID2(int ID);

        public Type_DAL Insert(Type_DAL item);
    }
}
