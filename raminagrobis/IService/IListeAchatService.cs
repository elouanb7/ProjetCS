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
        public int GetMaxWeek();
        public List<ListeAchat> GetAllWhereWeek(int semaine);
        public ListeAchat Insert(ListeAchat a);
        public ListeAchat Update(ListeAchat a);
    }
}
