using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactStructure
{
    public class PROFESSIONS
    {
        int id_Profession;
        public int Id_Profession { get { return id_Profession; } set { id_Profession = value; } }

        string libele_Profession;
        public string Libele_Profession { get { return libele_Profession; } set { libele_Profession = value; } }

        int posteNumber_Profession;
        public int PosteNumber_Profession { get { return posteNumber_Profession; } set { posteNumber_Profession = value; } }
    }
}
