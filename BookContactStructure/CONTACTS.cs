using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactStructure
{
    public struct CONTACTS
    {
        public int Id_Contact { get; set; }
        public string Nom_Contact { get; set; }
        public string Prenom_Contact { get; set; }
        public string Rue_Contact { get; set; }
        public string CodePostal_Contact { get; set; }
        public string Ville_Contact { get; set; }
        public PROFESSIONS Profession { get; set; }
    }
}
