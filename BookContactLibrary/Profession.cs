using BookContactStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactLibrary
{
    public class Profession
    {
        int id_Profession;        
        string libele_Profession;
        int posteNumber_Profession;

        public int Id_Profession { get { return id_Profession; } set { id_Profession = value; } }
        public string Libele_Profession { get { return libele_Profession; } set { libele_Profession = value; } }
        public int PosteNumber_Profession { get { return posteNumber_Profession; } set { posteNumber_Profession = value; } }

        public Profession()
        {

        }

        public static implicit operator Profession(PROFESSIONS _p)
        {
            return new Profession
            {
                Id_Profession = _p.Id_Profession,
                Libele_Profession = _p.Libele_Profession,
                PosteNumber_Profession = _p.PosteNumber_Profession
            };
        }
       
        


    }
}
