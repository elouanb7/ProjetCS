using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Reference_DAL
    {
        public int ID { get; set; }
        public string ReferenceName { get; set; }
        public string Libelle { get; set; }
        public string Marque { get; set; }
        public bool Desactive { get; set; }

        public Reference_DAL(string referenceName, string libelle, string marque, bool desactive)
            => (ReferenceName, Libelle, Marque, Desactive) = (ReferenceName, libelle, marque, desactive);
        public Reference_DAL(int id, string referenceName, string libelle, string marque, bool desactive)
            => (ID, ReferenceName, Libelle, Marque, Desactive) = (id, ReferenceName, libelle, marque, desactive);
    }
}
