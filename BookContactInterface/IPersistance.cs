using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookContactInterface
{
    public interface IPersistance<T>
    {
        void SetSqlConnection(SqlConnection _sqlCon);

        List<T> SelectAll();

        T SelectById(int _id);

        bool Create(T instance);

        bool Update(T instance);

        bool Delete(int id);

        bool Delete(T instance);

        List<T> Select(int id);

    }
}
