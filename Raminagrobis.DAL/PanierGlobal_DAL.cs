using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PanierGlobal_DAL
    {
        public int ID { get; set; }
        public int IDListAchat_DAL { get; set; }

        public PanierGlobal_DAL(int idListeAchat) => (IDListAchat_DAL) = (idListeAchat);
        public PanierGlobal_DAL(int id, int idListeAchat) => (ID, IDListAchat_DAL) = (id, idListeAchat);
    }
}
