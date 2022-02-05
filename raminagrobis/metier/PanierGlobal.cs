using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class PanierGlobal
    {
        public int ID { get; private set; }
        public int IDListAchat { get; set; }

        public PanierGlobal(int idListeAchat) => (IDListAchat) = (idListeAchat);
        public PanierGlobal(int id, int idListeAchat) => (ID, IDListAchat) = (id, idListeAchat);
    }
}
