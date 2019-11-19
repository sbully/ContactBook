using BookContactStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactLibrary
{
    public class Contact
    {
        int id_Contact;
        string nom_Contact;
        string prenom_Contact;
        string rue_Contact;
        string codePostal_Contact;
        string ville_Contact;
        Profession profession;


        public Contact()
        {

        }
        public static implicit operator Contact(CONTACTS _c)
        {
            return new Contact {
                Id_Contact= _c.Id_Contact,
                nom_Contact =_c.Nom_Contact,
                prenom_Contact =_c.Prenom_Contact,
                rue_Contact =_c.Rue_Contact,
                codePostal_Contact =_c.CodePostal_Contact,
                ville_Contact =_c.Ville_Contact,
                Profession = _c.Profession
            };
        }

        public int Id_Contact { get => id_Contact; set => id_Contact = value; }
        public string Nom_Contact { get => nom_Contact; set => nom_Contact = value; }
        public string Prenom_Contact { get => prenom_Contact; set => prenom_Contact = value; }
        public string Rue_Contact { get => rue_Contact; set => rue_Contact = value; }
        public string CodePostal_Contac { get => codePostal_Contact; set => codePostal_Contact = value; }
        public string Ville_Contact { get => ville_Contact; set => ville_Contact = value; }
        public Profession Profession { get => profession; set => profession = value; }
    }
}
