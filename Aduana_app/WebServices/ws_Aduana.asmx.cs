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
    /// Summary description for ws_Aduana
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_Aduana : System.Web.Services.WebService
    {
        [WebMethod]
        public string calcular_Costo_Aduana(string marca, string linea, string modelo)
        {
            long costoAduana = 0;
            int modeloAduana = 0;
            long costoAuto = 0;
            try
            {
                ConexionDB_Aduana conn = new ConexionDB_Aduana();
                string sqlCommand = "select '2017' as modelo, (ln.factor* 1000) as precio_vehiculo "+
                                         " from linea ln " +
                                         " join marca mc on mc.ID_marca = ln.marca "+
                                         " where mc.nombre = 'ABARTH' and "+
                                         " ln.nombre = '500' ;"; //falta where modelo
                DataSet resultado = conn.selectDB(sqlCommand);

                if (resultado != null && resultado.Tables[0].Rows.Count > 0)
                {
                    string valorstr = Convert.ToString(resultado.Tables[0].Rows[0]["precio_vehiculo"]);
                    string modelostr = Convert.ToString(resultado.Tables[0].Rows[0]["modelo"]);
                    Int64.TryParse(valorstr, out costoAuto);
                    Int32.TryParse(modelostr, out modeloAduana);
                    String sDate = DateTime.Now.ToString();
                    DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                    String yearstr = datevalue.Year.ToString();
                    costoAduana = costoAuto + (2000 / (Convert.ToInt32(yearstr) * modeloAduana))+1000;
                }

                var json = JsonConvert.SerializeObject(new
                {
                    costo_Aduana = costoAduana,
                    status = 0,
                    descripcion = "Exitoso"

                });

                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var json = JsonConvert.SerializeObject(new
                {
                    costo_Aduana = 0,
                    status = 1,
                    descripcion = "Error"

                });

                return json;
            }
        }

        [WebMethod]
        public string guardar_Id_Transferencia(int id_Transferencia, double monto_Compra)
        {
            try
            {
                ConexionDB_Aduana conn = new ConexionDB_Aduana();
                string sqlCommand = "use aduana_sa; insert into transferencia (ID_transferencia, monto, fecha_hora) values ('" + id_Transferencia + "', " + Convert.ToString(monto_Compra) + " , SYSDATETIME());";
                int resultado = conn.modificarDB(sqlCommand);

                if (resultado == 1)
                {
                    var json = JsonConvert.SerializeObject(new
                    {
                        status = 1,
                        descripcion = "Exitoso"
                    });

                    return json;
                }
                else
                {
                    var json = JsonConvert.SerializeObject(new
                    {
                        status = 1,
                        descripcion = "Tipo de dato incorrecto"
                    });

                    return json;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var json = JsonConvert.SerializeObject(new
                {
                    status = 1,
                    descripcion = "Tipo de dato incorrecto"
                });

                return json;
            }
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
            return "{"+ strResultado + "}";
        }
    }
}
