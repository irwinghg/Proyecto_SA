using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Aduana_app
{
    public class ConexionDB_SAT
    {

        public int modificarDB(string sqlCommand)
        {
            SqlConnection connection;
            SqlCommand command;
            string connetionString = null;
            int resultado = 0;
            try
            {
                connetionString = generarConnectionstring();
                connection = new SqlConnection(connetionString);
                connection.Open();
                command = new SqlCommand(sqlCommand, connection);
                resultado = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }

        public DataSet selectDB(string sqlCommand)
        {

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
                Console.WriteLine(ex);
                return null;
            }
        }

        public string generarConnectionstring()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\DatosSA\\acceso_SAT.xml");

            XmlNodeList sources = doc.GetElementsByTagName("server");
            XmlNodeList databases = doc.GetElementsByTagName("database");
            string connetionString = "";
            string source = "";
            string database = "";
            if (sources.Count == 1 && databases.Count == 1)
            {
                source = sources[0].InnerText;
                database = databases[0].InnerText;
                connetionString = "Data Source=" + source + ";Initial Catalog=" + database + ";Persist Security Info=False;User ID=Administrador;Password=Acceso1234#";
            }
            return connetionString;
        }

    }


}