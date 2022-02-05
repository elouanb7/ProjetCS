using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class ListeAchat
    {
        public int ID { get; private set; }
        public int IDAdherent { get; set; }
        public string Semaine { get; set; }

        public ListeAchat(int idAdherent, string semaine) => (IDAdherent, Semaine) = (idAdherent, semaine);
        public ListeAchat(int id, int idAdherent, string semaine) => (ID, IDAdherent, Semaine) = (id, idAdherent, semaine);
    }
}
