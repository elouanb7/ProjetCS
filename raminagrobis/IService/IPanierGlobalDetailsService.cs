using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.IService
{
    public interface IPanierGlobalDetailsService
    {
        public List<PanierGlobalDetails> GetAll();
        public PanierGlobalDetails GetByID(int ID);
        public List<PanierGlobalDetails> GetByPanierGlobalID(int ID);
        public PanierGlobalDetails Insert(PanierGlobalDetails pg);
    }
}
