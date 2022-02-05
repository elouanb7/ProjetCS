using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    public class ListeAchat_DTO
    {
        public int ID { get; set; }
        public int IDAdherent { get; set; }
        public string Semaine { get; set; }
        public ListeAchatDetails_DTO[] details { get; set; }
    }
}
