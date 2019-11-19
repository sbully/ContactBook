using BookContactInterface;
using BookContactStructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactLibraryPersistence
{
    public class PersistenceProf : IPersistance<PROFESSIONS>
    {
        private SqlCommand Sqlcde;
        private SqlDataReader SqlRdr;
        private SqlConnection SqlConnection;

        public PersistenceProf(SqlConnection _sqlConnection)
        {
            SqlConnection = _sqlConnection;
        }
        public bool Create(PROFESSIONS instance)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(PROFESSIONS instance)
        {
            throw new NotImplementedException();
        }

        public List<PROFESSIONS> Select(int id)
        {
            throw new NotImplementedException();
        }

        public List<PROFESSIONS> SelectAll()
        {
            Sqlcde = new SqlCommand();
            Sqlcde.Connection = SqlConnection;
            Sqlcde.CommandText = "SelectAllProf";
            Sqlcde.CommandType = System.Data.CommandType.StoredProcedure;
            SqlConnection.Open();
            SqlRdr = Sqlcde.ExecuteReader();

            var properties = typeof(PROFESSIONS).GetProperties();
            List<PROFESSIONS> listF = new List<PROFESSIONS>();
            while (SqlRdr.Read())
            {
                PROFESSIONS p = new PROFESSIONS();
                object obj = (object)p;
                foreach(var property in properties)
                {
                    if (!SqlRdr.IsDBNull(SqlRdr.GetOrdinal(property.Name)))
                    {
                        Type converTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        property.SetValue(obj, Convert.ChangeType(SqlRdr[property.Name], converTo));
                    }
                }
                p = (PROFESSIONS)obj;
                listF.Add(p);
            }
            SqlRdr.Close();
            SqlConnection.Close();
            return listF;
        }

        public PROFESSIONS SelectById(int _id)
        {
            throw new NotImplementedException();
        }

        public void SetSqlConnection(SqlConnection _sqlCon)
        {
            throw new NotImplementedException();
        }

        public bool Update(PROFESSIONS instance)
        {
            throw new NotImplementedException();
        }
    }
}
