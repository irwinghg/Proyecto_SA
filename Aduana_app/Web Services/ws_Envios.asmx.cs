using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Aduana_app.Web_Services
{
    /// <summary>
    /// Summary description for ws_Envios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_Envios : System.Web.Services.WebService
    {

        /*[WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }*/

        [WebMethod]
        public string cargar_Vehiculos(int solicitud_Catalogo)
        {
            string respuesta = "";
            string auto1 = "{" + getJson("id_Vehiculo", 300) + " , " + getJson("marca", "Toyota") + ", " + getJson("linea", "Yaris") + ", " + getJson("modelo", "2010") + "}";
            string auto2 = "{" + getJson("id_Vehiculo", 310) + " , " + getJson("marca", "Nissan") + ", " + getJson("linea", "Navara") + ", " + getJson("modelo", "2016") + "}";
            string auto3 = "{" + getJson("id_Vehiculo", 320) + " , " + getJson("marca", "Subaru") + ", " + getJson("linea", "WRX") + ", " + getJson("modelo", "2015") + "}";
            respuesta = "{\"vehiculos\":[ " + auto1 + ", " + auto2 + ", " + auto3 + "]}";
            return respuesta;
        }

        [WebMethod]
        public string calcular_Costo_Viaje(int viaje, Double Costo) {

            string costo = getJson("costo_Viaje", 600);
            return "{"+costo+"}";
        }


        [WebMethod]
        public string guardar_Transferencia(int id_transferencia, int monto)
        {
            string respuesta = "false";
            if (id_transferencia == monto) {
                respuesta = "true";
            }
            string resultado = getJson("respuesta",respuesta);
            return "{" + resultado + "}";
        }


        /// <summary>
        /// Formatea expesiona json string:string
        /// </summary>
        /// <param name="atributo"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public string getJson(string atributo, string valor)
        {
            return string.Format("\"{0}\": \"{1}\"", atributo, valor);
        }
        /// <summary>
        /// Formatea expresiones a json string:int
        /// </summary>
        /// <param name="atributo"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public string getJson(string atributo, int valor)
        {
            return string.Format("\"{0}\": {1}", atributo, valor);
        }
    }
}
