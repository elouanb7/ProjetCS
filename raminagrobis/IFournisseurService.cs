using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IFournisseurService
    {
        public List<Fournisseur> GetAll();
        public List<Fournisseur> GetAllActif();
        public Fournisseur GetByID(int ID);
        public Fournisseur Insert(Fournisseur f);
        public Fournisseur Update(Fournisseur f);
        public void Delete(Fournisseur f);
    }
}
