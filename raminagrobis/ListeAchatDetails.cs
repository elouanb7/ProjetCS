using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class ListeAchatDetails
    {
        public int IDListeAchat { get; private set; }
        public int IDReference { get; private set; }
        public int Quantite { get; private set; }

        ListeAchatDetails_DAL(int idListeAchat, int idReference, int quantite) => (IDListeAchat, IDReference, Quantite) = (idListeAchat, idReference, quantite);

    }
}
