using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Aduana_app.Web_Services
{
    /// <summary>
    /// Summary description for ws_Importadora
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_Importadora : System.Web.Services.WebService
    {
    
        [WebMethod]
        public string validar_Sesion(string username, string password)
        {
            DataSet datDatos;
            string strNombre = "";
            string strNoTarjeta = "";
            int intStatus = 1;
            string strDescripcion = "Usuario o contraseña incorrectos.";
            try
            {
                datDatos = ConsultarCuenta(null, username, password, null);
                if (datDatos != null && datDatos.Tables[0].Rows.Count > 0)
                {
                    strNombre = datDatos.Tables[0].Rows[0]["Nombre"].ToString();
                    strNoTarjeta = datDatos.Tables[0].Rows[0]["No_Tarjeta"].ToString();
                    intStatus = 0;
                    strDescripcion = "Validación correcta";
                }

                var json = JsonConvert.SerializeObject(new
                {
                    nombre = strNombre,
                    no_Tarjeta = strNoTarjeta,
                    status = intStatus,
                    descripcion = strDescripcion

                });

                return json;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                var json = JsonConvert.SerializeObject(new
                {
                    nombre = "",
                    no_Tarjeta = "",
                    status = 1,
                    descripcion = "Ocurrio un Error Inesperado en el Sistema."
                });

                return json;
            }
		}

        [WebMethod]
        public string crear_Cuenta(string nombre, string username, string password, string no_tarjeta)
        {
            DataSet datDatos;
            int intStatus = 1;
            string strDescripcion = "Username ya existente.";
            try
            {
                datDatos = ConsultarCuenta(null, username, null, null);
                if (datDatos == null || datDatos.Tables[0].Rows.Count == 0)
                {
                    if (InsertarCuenta(nombre, username, password, no_tarjeta) == 1)
                    {
                        intStatus = 0;
                        strDescripcion = "Exitoso";
                    }
                    else
                    {
                        intStatus = 1;
                        strDescripcion = "No se pudo Insertar la Cuenta en la BD.";
                    }
                }

                var json = JsonConvert.SerializeObject(new
                {
                    status = intStatus,
                    descripcion = strDescripcion
                });

                return json;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                var json = JsonConvert.SerializeObject(new
                {
                    status = 1,
                    descripcion = "Ocurrio un Error Inesperado en el Sistema."
                });

                return json;
            }
        }

        private int InsertarCuenta(string strNombre, string strUsername, string strPassword, string strNoTarjeta)
        {
            ConexionDB_Importadora objAccesoDatos;
            string strQuery = null;
            try
            {
                objAccesoDatos = new ConexionDB_Importadora();
                strQuery = "INSERT Usuario(Username, Nombre, Pass, No_Tarjeta) ";
                strQuery += "VALUES ('" + strUsername + "','" + strNombre + "','" + strPassword + "','" + strNoTarjeta + "') ";
                if (objAccesoDatos.modificarDB(strQuery) == 1) { return 1; }
                return -1;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return -1;
            }
            finally
            {
                objAccesoDatos = null;
            }
        }

        private DataSet ConsultarCuenta(string strNombre, string strUsername, string strPassword, string strNoTarjeta)
        {
            ConexionDB_Importadora objAccesoDatos;
            DataSet datDatosCuenta;
            string strQuery = null;
            string strWhere = null;
            try
            {
                objAccesoDatos = new ConexionDB_Importadora();
                if (strNombre != null)
                {
                    strWhere += " WHERE "; 
                    strWhere += " Nombre = '" + strNombre + "'";
                }

                if (strUsername != null) {
                    if (strWhere != null) { strWhere += " AND "; } else { strWhere += " WHERE "; }
                    strWhere += " Username = '" + strUsername + "'";
                }

                if (strPassword != null)
                {
                    if (strWhere != null) { strWhere += " AND "; } else { strWhere += " WHERE "; }
                    strWhere += " Pass = '" + strPassword + "'";
                }

                if (strNoTarjeta != null)
                {
                    if (strWhere != null) { strWhere += " AND "; } else { strWhere += " WHERE "; }
                    strWhere += " No_Tarjeta = '" + strNoTarjeta + "'";
                }
                
                strQuery = " SELECT Username, Nombre, Pass, No_Tarjeta"
                         + " FROM Usuario "
                         + strWhere;

                datDatosCuenta = objAccesoDatos.selectDB(strQuery);
                
                return datDatosCuenta;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
            finally
            {
                objAccesoDatos = null;
            }
        }

        //GENERACION DE IDENTIFICADOR UNICO
        private string GenerarIdentificador()
        {
            DateTime fecFechaActual = DateTime.Now;
            string strIdentificador = null;
            strIdentificador = fecFechaActual.Year.ToString() + fecFechaActual.Month.ToString() + fecFechaActual.Day.ToString();
            strIdentificador += fecFechaActual.Hour.ToString() + fecFechaActual.Minute.ToString() + fecFechaActual.Millisecond.ToString();
            return strIdentificador;
        }

        string strPlantilla = "\"{0}\": {1}";
        // NOMBRE_ATRIBUTO, VALOR, TIPO(1: String, Boolean & 2: Double, Integer); 
        public string generateJson(string atributos)
        {
            string strResultado = "";
            string[] arrAtributos = atributos.Split(';');
            for (int i = 0; i < arrAtributos.Length; i++)
            {
                string[] arrAtributo = arrAtributos[i].Split(',');
                string strTipo = "";
                if (int.Parse(arrAtributo[2]) == 1)
                    strTipo += '"';

                if (i == 0)
                    strResultado += string.Format(strPlantilla, arrAtributo[0], strTipo + arrAtributo[1] + strTipo);
                else
                    strResultado += "," + string.Format(strPlantilla, arrAtributo[0], strTipo + arrAtributo[1] + strTipo);
            }
            return "{" + strResultado + "}";
        }

    }
}
