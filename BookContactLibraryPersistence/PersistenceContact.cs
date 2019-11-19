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
    public class PersistenceContact : IPersistance<CONTACTS>
    {
        private SqlCommand Sqlcde;
        private SqlDataReader SqlRdr;
        private SqlConnection SqlConnection;

        public PersistenceContact(SqlConnection _sqlConnection)
        {
            SqlConnection = _sqlConnection;
        }

        public bool Create(CONTACTS instance)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(CONTACTS instance)
        {
            throw new NotImplementedException();
        }

        public List<CONTACTS> Select(int id)
        {
            throw new NotImplementedException();
        }

        public List<CONTACTS> SelectAll()
        {
            Sqlcde = new SqlCommand();
            Sqlcde.Connection = SqlConnection;
            Sqlcde.CommandText = "SelectAllContactWithProf";
            Sqlcde.CommandType = System.Data.CommandType.StoredProcedure;

            SqlConnection.Open();
            SqlRdr = Sqlcde.ExecuteReader();


            var properties = typeof(CONTACTS).GetProperties();
            List <CONTACTS> listContact = new List<CONTACTS>();
            while (SqlRdr.Read())
            {

                //CONTACTS contact = new CONTACTS();
                CONTACTS contact = new CONTACTS();
                PROFESSIONS prof = new PROFESSIONS();
                contact.Id_Contact = (int)SqlRdr["Id_Contact"];
                contact.Nom_Contact = (string)SqlRdr["Nom_Contact"];
                contact.Prenom_Contact = (string)SqlRdr["Prenom_Contact"];
                contact.Rue_Contact = (string)SqlRdr["Rue_Contact"];
                contact.CodePostal_Contact = (string)SqlRdr["CodePostal_Contact"];
                contact.Ville_Contact = (string)SqlRdr["Ville_Contact"];
                prof.Id_Profession = (int)SqlRdr["Id_Contact"];
                prof.Libele_Profession = (string)SqlRdr["Libele_Profession"];
                prof.PosteNumber_Profession = (int)SqlRdr["PosteNumber_Profession"];
                contact.Profession = prof;
                //object contact2 = contact;
                //foreach (var property in properties)
                //{

                //    if (property.Name != "Profession" && !SqlRdr.IsDBNull(SqlRdr.GetOrdinal(property.Name)))
                //    {
                //        Type converTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                //        property.SetValue(contact2, Convert.ChangeType(SqlRdr[property.Name], converTo));
                //    }
                //}
                //contact = (CONTACTS)contact2;
                listContact.Add(contact);
            }
            SqlConnection.Close();
            
            return listContact;
        }

        public CONTACTS SelectById(int _id)
        {
            throw new NotImplementedException();
        }

        public void SetSqlConnection(SqlConnection _sqlCon)
        {
            throw new NotImplementedException();
        }

        public bool Update(CONTACTS instance)
        {
            throw new NotImplementedException();
        }
    }
}
