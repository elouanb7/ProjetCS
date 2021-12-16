using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class FournisseurReference_DAL
    {
        public int IDFournisseur_DAL { get; set; }
        public int IDReference_DAL { get; set; }

        public FournisseurReference_DAL(int id_fournisseur, int id_reference) 
            => (IDFournisseur_DAL, IDReference_DAL) = (id_fournisseur, id_reference);
    }
}
