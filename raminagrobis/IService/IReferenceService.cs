using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public interface IReferenceService
    {
        public List<Reference> GetAll();
        public List<Reference> GetAllActif();
        public Reference GetByID(int ID);
        public Reference Insert(Reference r);
        public Reference Update(Reference r);
    }
}
