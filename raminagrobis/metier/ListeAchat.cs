using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class ListeAchat
    {
        public int ID { get; set; }
        public int IDAdherent { get; set; }
        public int Semaine { get; set; }

        public ListeAchat(int idAdherent, int semaine) => (IDAdherent, Semaine) = (idAdherent, semaine);
        public ListeAchat(int id, int idAdherent, int semaine) => (ID, IDAdherent, Semaine) = (id, idAdherent, semaine);
    }
}
