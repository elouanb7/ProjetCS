using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.IService
{
    public interface IListeAchatDetailsService
    {
        public List<ListeAchatDetails> GetAll();
        public ListeAchatDetails GetLinkByID(int ListeAchatID, int referenceID);
        public List<ListeAchatDetails> GetByListeAchatID(int ListeAchatID);
        public ListeAchatDetails Insert(ListeAchatDetails l);
        public ListeAchatDetails Update(ListeAchatDetails l);

    }
}
