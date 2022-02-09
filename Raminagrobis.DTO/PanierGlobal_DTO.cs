using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    public class PanierGlobal_DTO
    {
        public int ID { get; set; }
        public int Semaine { get; set; }
        public PanierGlobalDetails_DTO[] Details { get; set; }
    }
}
