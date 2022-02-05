using Raminagrobis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class ReferenceService : IReferenceService
    {
        private ReferenceDepot_DAL depot = new ReferenceDepot_DAL();

        public List<Reference> GetAll()
        {
            var references = depot.GetAll() //retourne toutes les references de la BDD
                    .Select(r => new Reference(r.ID, r.ReferenceName, r.Libelle, r.Marque, r.Desactive))
                    .ToList();

            return references;
        }

        public List<Reference> GetAllActif()
        {
            var references = depot.GetAll() //retourne toutes les references actives
                    .Where(r => r.Desactive == false)
                    .Select(r => new Reference(r.ID, r.ReferenceName, r.Libelle, r.Marque, r.Desactive))
                    .ToList();

            return references;
        }

        public Reference GetByID(int ID)
        {
            var r = depot.GetByID(ID);

            return new Reference(r.ID, r.ReferenceName, r.Libelle, r.Marque, r.Desactive);
        }

        public Reference Insert(Reference r)
        {
            var reference = new Reference_DAL(r.ReferenceName, r.Libelle, r.Marque, r.Desactive);
            depot.Insert(reference);

            reference.ID = r.ID;

            return r;
        }

        public Reference Update(Reference r)
        {
            var reference = new Reference_DAL(r.ID, r.ReferenceName, r.Libelle, r.Marque, r.Desactive);
            depot.Insert(reference);

            return r;
        }
    }
}
