using BookContactInterface;
using BookContactStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactLibrary
{

    public class ListProfession
    {
        private List<Profession> listdeProfession;
        public List<Profession> ListdeProfession
        {
            get { return listdeProfession; }
            set { listdeProfession = value; }
        }

        public List<Profession> GetListProfessions(IPersistance<PROFESSIONS> _p)
        {
            List<PROFESSIONS> listP = _p.SelectAll();
            List<Profession> listProf = new List<Profession>();
            foreach(PROFESSIONS p in listP)
            {
                listProf.Add(p);
            }
            return new List<Profession>();
        }

    }
}
