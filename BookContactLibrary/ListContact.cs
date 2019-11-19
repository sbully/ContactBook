using BookContactInterface;
using BookContactStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactLibrary
{
    public class ListContact
    {
        private List<Contact> listdeContact;
        public List<Contact> ListdeContact
        {
            get { return listdeContact; }
            set { listdeContact = value; }
        }

        public List<Contact> GetListContacts(IPersistance<CONTACTS> _p)
        {
            List<Contact> listContact = new List<Contact>();
            List<CONTACTS> listC = _p.SelectAll();
            foreach(CONTACTS c in listC)
            {
                listContact.Add(c);
            }
            return listContact;
        }

    }
}
