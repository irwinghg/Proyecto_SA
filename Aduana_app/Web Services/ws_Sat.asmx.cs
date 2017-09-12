using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Aduana_app.Web_Services
{
    /// <summary>
    /// Summary description for ws_Sat
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_Sat : System.Web.Services.WebService
    {

        [WebMethod]
        public string calcular_Impuesto_Sat(string marca, string linea, string modelo)
        {
            //consultar impuesto
            return generateJson("valor,400,2");
        }

        [WebMethod]
        public string registro_Id_Compra(int id_Transferencia, double monto_Compra)
        {
            string strResultado = "";
            if (id_Transferencia == 0)
                id_Transferencia = -1;
            if (monto_Compra == 0)
                monto_Compra = -1;

            if (id_Transferencia != -1 && monto_Compra != -1)
                strResultado = generateJson("respuesta,true,1");
            else
                strResultado = generateJson("respuesta,false,1");
            return strResultado;
        }

        [WebMethod]
        public string guardar_Manifiesto(string marca, string linea, string modelo, string fecha_Entrada, string pais_Origen)
        {
            string strResultado = "";
            if (marca == "")
                marca = null;
            if (linea == "")
                linea = null;
            if (modelo == "")
                modelo = null;
            if (fecha_Entrada == "")
                fecha_Entrada = null;
            if (pais_Origen == "")
                pais_Origen = null;

            if (marca != null && linea != null && modelo != null && fecha_Entrada != null && pais_Origen != null)
                strResultado = generateJson("num_Manifiesto,0155,2");
            else
                strResultado = generateJson("num_Manifiesto,-1,2");
            return strResultado;
        }

        [WebMethod]
        public string guardar_Declaracion(string marca, string linea, string modelo, double precio, string fecha_Declaracion)
        {
            string strResultado = "";
            if (marca == "")
                marca = null;
            if (linea == "")
                linea = null;
            if (modelo == "")
                modelo = null;
            if (fecha_Declaracion == "")
                fecha_Declaracion = null;
            if (precio == 0)
                precio = -1;

            if (marca != null && linea != null && modelo != null && fecha_Declaracion != null && precio != -1)
                strResultado = generateJson("num_Declaracion,0123,2");
            else
                strResultado = generateJson("num_Declaracion,-1,2");
            return strResultado;
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
