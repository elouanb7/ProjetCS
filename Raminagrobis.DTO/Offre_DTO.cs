using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    public class Offre_DTO
    {
        public int ID { get; set; }
        public int IDFournisseur { get; set; }
        public int IDPanierGlobalDetail { get; set; }
        public float? PUHT { get; set; }
    }
}
