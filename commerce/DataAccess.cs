using System;
using System.Data.SqlClient;
namespace domain
{
    class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true ");
            //connection = new SqlConnection("server=localhost; database=CATALOGO_P3_DB;User Id=sa; password=fakePassw0rd"); 
            command = new SqlCommand();
        }

        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void setearParametro(string name, object valor)
        {
            command.Parameters.AddWithValue(name, valor);
        }

        public void ClearQuery()
        {
            command.CommandText = "";
        }
        public void execute()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public SqlDataReader sqlReader
        {
            get { return reader; }
        }
        public void executeAction()
        {
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int executeScalar()
        {
            command.Connection = connection;

            try
            {
                connection.Open();
                int entityId = (int)command.ExecuteScalar();
                connection.Close();
                return entityId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void close()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }

        public void StoredProcedure(string Sp)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = Sp;
        }
    }
}
