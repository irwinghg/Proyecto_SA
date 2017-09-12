using System;
using System.Collections.Generic;
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
            string strResultado = "";
            if (marca == "")
                marca = null;
            if (linea == "")
                marca = null;
            if (modelo == "")
                marca = null;

            if (marca != null && linea != null && modelo != null)
                strResultado = generateJson("costo_Aduana,135.57,2");
            else
                strResultado = generateJson("costo_Aduana,-1,2");
            return strResultado;
        }

        [WebMethod]
        public string guardar_Id_Transferencia(int id_Transferencia, double monto_Compra)
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
