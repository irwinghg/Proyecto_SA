using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Aduana_app.Web_Services
{
    /// <summary>
    /// Summary description for ws_Banco
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_Banco : System.Web.Services.WebService
    {

        [WebMethod]
        public string transferencia_Cuenta(string cuenta_Origen, string cuenta_Destino, double monto)
        {
            string strResultado = "";
            if (cuenta_Origen != null && cuenta_Destino != null && monto >= 1000)
            {
                string strAtributos = "id_Transferencia,30004999,1;"
                                    + "respuesta,true,1;"
                                    + "detalle_Transferencia,Transferencia Exitosa,1";
                strResultado = generateJson(strAtributos);
            }
            else if(cuenta_Origen != null && cuenta_Destino != null && monto < 1000)
            {
                string strAtributos = "id_Transferencia,-1,1;"
                                    + "respuesta,false,1;"
                                    + "detalle_Transferencia,Saldo Insuficiente,1";
                strResultado = generateJson(strAtributos);
            }
            else if (cuenta_Origen != null && monto > 1000)
            {
                string strAtributos = "id_Transferencia,-1,1;"
                                    + "respuesta,false,1;"
                                    + "detalle_Transferencia,Cuenta Inexistente,1";
                strResultado = generateJson(strAtributos);
            }
            else
            {
                string strAtributos = "id_Transferencia,-1,1;"
                                    + "respuesta,false,1;"
                                    + "detalle_Transferencia,Transferencia Fallo,1";
                strResultado = generateJson(strAtributos);
            }
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

                if(i == 0)
                    strResultado += string.Format(strPlantilla, arrAtributo[0], strTipo + arrAtributo[1] + strTipo);
                else
                    strResultado += "," + string.Format(strPlantilla, arrAtributo[0], strTipo + arrAtributo[1] + strTipo);
            }
            return "{" + strResultado + "}";
        }
    }
}
