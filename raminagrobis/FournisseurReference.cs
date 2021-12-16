using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis
{
    public class FournisseurReference
    {
        /// <summary>
        /// Clé étrangère "ID" d'un fournisseur
        /// </summary>
        public int IDFournisseur { get; set; }

        /// <summary>
        /// Clé étrangère "ID" d'une référence
        /// </summary>
        public int IDReference { get; set; }

        /// <summary>
        /// Construit un FournisseurRéférence
        /// </summary>
        /// <param name="id_fournisseur">Clé étrangère "ID" d'un fournisseur</param>
        /// <param name="id_reference">Clé étrangère "ID" d'une référence</param>
        public FournisseurReference(int id_fournisseur, int id_reference)
            => (IDFournisseur, IDReference) = (id_fournisseur, id_reference);
    }
}
