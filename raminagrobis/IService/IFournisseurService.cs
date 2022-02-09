using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.IService
{
    public interface IFournisseurService
    {
        public List<Fournisseur> GetAll();
        public List<Fournisseur> GetAllActif();
        public Fournisseur GetByID(int ID);
        public Fournisseur GetBySociete(string societe);
        public Fournisseur Insert(Fournisseur f);
        public Fournisseur Update(Fournisseur f);
        public void Delete(Fournisseur f);
    }
}
