using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    public class Reference_DTO
    {
        public int ID { get; set; }
        public string ReferenceName { get; set; }
        public string Libelle { get; set; }
        public string Marque { get; set; }
        public bool Desactive { get; set; }
        public int[] FournisseurID { get; set; }
    }
}
