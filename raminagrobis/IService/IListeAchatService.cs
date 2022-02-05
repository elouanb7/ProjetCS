using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.IService
{
    public interface IListeAchatService
    {
        public List<ListeAchat> GetAll();
        public ListeAchat GetByID(int ID);
        public ListeAchat Insert(ListeAchat a);
        public ListeAchat Update(ListeAchat a);
    }
}
