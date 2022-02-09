using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.IService
{
    public interface IFournisseurReferenceService
    {
        public List<FournisseurReference> GetAll();
        public FournisseurReference GetLinkByID(int fournisseurID, int referenceID);
        public FournisseurReference Insert(FournisseurReference f);
        public List<FournisseurReference> GetByFournisseurID(int fournisseurID);
        public List<FournisseurReference> GetByReferenceID(int referenceID);
    }
}
