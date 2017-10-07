using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Xml;

namespace Aduana_app
{
    public class ConexionDB
    {

        public int modificarDB(string sqlCommand) {
            
            //string MyString = "update cliente set nombre =  'prueba2' where id_cliente = 'A583229' ;";
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            int resultado = 0;
            connetionString = generarConnectionstring();
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sqlCommand, connection);
                resultado = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet selectDB(string sqlCommand) {
            
            try
            {
                string conexionstr = generarConnectionstring();
                SqlConnection conn = new SqlConnection(conexionstr);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlCommand;
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();

                conn.Open();
                da.Fill(ds);
                conn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                return null;                
            }
        }

        public string generarConnectionstring() {

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\DatosSA\\acceso.xml");
            
            XmlNodeList sources = doc.GetElementsByTagName("server");
            XmlNodeList databases = doc.GetElementsByTagName("database");
            string connetionString = "";
            string source = "";
            string database = "";
            if (sources.Count == 1 && databases.Count == 1)
            {
                source = sources[0].InnerText;
                database = databases[0].InnerText;
                connetionString = "Data Source=" + source + ";Initial Catalog=" + database + ";Integrated Security=True";
            }
            return connetionString;
        }

    }


}