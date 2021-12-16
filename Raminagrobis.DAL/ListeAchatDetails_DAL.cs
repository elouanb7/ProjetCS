using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class ListeAchatDetails_DAL
    {
        public int IDListeAchat_DAL { get; set; }
        public int IDReference_DAL { get; set; }
        public int Quantite { get; set; }

        public ListeAchatDetails_DAL(int idListeAchat_DAL, int idReference_DAL, int quantite) => (IDListeAchat_DAL, IDReference_DAL, Quantite) = (idListeAchat_DAL, idReference_DAL, quantite);

    }
}
