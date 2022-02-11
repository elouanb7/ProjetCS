using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class ListeAchat_DAL
    {
        public int ID { get; set; }
        public int IDAdherent_DAL { get; set; }
        public int Semaine { get; set; }

        public ListeAchat_DAL(int idAdherent, int semaine) => (IDAdherent_DAL, Semaine) = (idAdherent, semaine);
        public ListeAchat_DAL(int id, int idAdherent, int semaine) => (ID, IDAdherent_DAL, Semaine) = (id, idAdherent, semaine);
    }
}
