using System;
using System.Collections.Generic;
using System.Data;
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
        public string transferencia_Cuenta(string no_Tarjeta, string cuenta_Destino, double monto)
        {
            string strResultado;
            try
            {
                strResultado = "";
                long lngCuentaOrigen = -1;
                long lngCuentaDestino = -1;
                if (!String.IsNullOrEmpty(no_Tarjeta)) { lngCuentaOrigen = long.Parse(no_Tarjeta); }
                if (!String.IsNullOrEmpty(cuenta_Destino)) { lngCuentaDestino = long.Parse(cuenta_Destino); }
                if (monto == 0) { monto = -1; }

                if (lngCuentaOrigen != -1 && lngCuentaDestino != -1 && monto != -1)
                    strResultado = ConsultarDatos(lngCuentaOrigen, lngCuentaDestino, monto);
                else
                    strResultado = generateJson("id_Transferecia,-1,2;status,1,2;descripcion,Parametros de Entrada Invalidos,1");

                return strResultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return generateJson("id_Transferecia,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1");
            }
        }


        private string InsertarTransferencia(int intCuentaOrigen, int intCuentaDestino, double decMonto)
        {
            ConexionDB_Banco objAccesoDatos;
            string strResultado = null;
            string strIdTransferencia = null;
            string strQuery = null;
            string strQueryActualizarOrigen = null;
            string strQueryActualizarDestino = null;
            try
            {
                strIdTransferencia = GenerarIdentificador();
                objAccesoDatos = new ConexionDB_Banco();
                strQuery = "INSERT Transferencia(No_Transferencia, ID_CuentaOrigen, ID_CuentaDestino, Monto) "
                         + "VALUES ('"+ strIdTransferencia + "','" + intCuentaOrigen + "','" + intCuentaDestino + "','" + decMonto + "'); ";

                strQueryActualizarOrigen = "UPDATE Cuenta "
                                   + "SET Saldo = Saldo - " + decMonto + " "
                                   + "WHERE ID_Cuenta = '" + intCuentaOrigen + "'";

                strQueryActualizarDestino = "UPDATE Cuenta "
                                   + "SET Saldo = Saldo + " + decMonto + " " 
                                   + "WHERE ID_Cuenta = '" + intCuentaDestino + "'";

                if (objAccesoDatos.modificarDB(strQuery) == 1 && objAccesoDatos.modificarDB(strQueryActualizarOrigen) == 1 && objAccesoDatos.modificarDB(strQueryActualizarDestino) == 1)
                    strResultado = generateJson("id_Transferecia," + strIdTransferencia + ",2;status,0,2;descripcion,Transferencia Exitosa,1");
                else
                    strResultado = generateJson("id_Transferecia," + "-1" + ",2;status,1,2;descripcion,Transferencia Fallida, Insersion Fallida en la BD,1");
                return strResultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return generateJson("id_Transferecia,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema 2,1");
            }
            finally
            {
                objAccesoDatos = null;
            }
        }

        private string ConsultarDatos(long lngNoTarjetaOrigen, long lngNoTarjetaDestino, double decMonto)
        {
            ConexionDB_Banco objAccesoDatos;
            DataSet datDatosCuenta;
            string strResultado = null;
            string strQuery = null;
            int intCuentaOrigen = -1;
            int intCuentaDestino = -1;
            try
            {
                objAccesoDatos = new ConexionDB_Banco();
                //VERIFICAR SI EXISTEN LAS CUENTAS
                strQuery = "SELECT C.ID_Cuenta, CT.Nombre "
                         + "FROM Cuenta_Tarjeta CT "
                         + "JOIN Cuenta C ON C.ID_Cuenta = CT.ID_Cuenta "
                         + "WHERE CT.No_Tarjeta IN ('" + lngNoTarjetaOrigen + "', '" + lngNoTarjetaDestino + "');";

                datDatosCuenta = objAccesoDatos.selectDB(strQuery);
                int intCantidadDatos = datDatosCuenta.Tables[0].Rows.Count;
                if (datDatosCuenta != null && intCantidadDatos > 0)
                {
                    string strNombreCuentaEncontrada = datDatosCuenta.Tables[0].Rows[0]["Nombre"].ToString();
                    intCuentaOrigen = int.Parse(datDatosCuenta.Tables[0].Rows[0]["ID_Cuenta"].ToString());
                    if (intCantidadDatos > 1)
                    { intCuentaDestino = int.Parse(datDatosCuenta.Tables[0].Rows[1]["ID_Cuenta"].ToString()); }
                    else
                    { strResultado = generateJson("id_Transferecia,-1,2;status,1,2;descripcion,Solo se encontro registro de la Cuenta de la Tarjeta de: " + strNombreCuentaEncontrada + ". La otra cuenta es Inexistente.,1"); }    
                }
                else
                {
                    strResultado = generateJson("id_Transferecia,-1,2;status,1,2;descripcion,Las 2 Cuentas son Inexistentes,1");
                }

                if (strResultado == null)
                {
                    //VERIFICAR SI LA CUENTA ORIGEN POSEE SALDO SUFICIENTE
                    strQuery = "SELECT No_Cuenta "
                             + "FROM Cuenta "
                             + "WHERE ID_Cuenta = '"+ intCuentaOrigen +"' "
                             + "AND Saldo > " + decMonto ;

                    datDatosCuenta = objAccesoDatos.selectDB(strQuery);
                    intCantidadDatos = datDatosCuenta.Tables[0].Rows.Count;
                    if (datDatosCuenta == null || intCantidadDatos == 0)
                    {
                        strResultado = generateJson("id_Transferecia,-1,2;status,1,2;descripcion,La Cuenta Origen no posee Saldo Suficiente para realizar la Transaccion,1");
                    }
                    else
                    {
                        //INSERTAR TRANSACCION CON LAS CUENTAS ORIGEN Y DESTINO
                        strResultado = InsertarTransferencia(intCuentaOrigen, intCuentaDestino, decMonto);
                    }
                }
                
                return strResultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return generateJson("id_Transferecia,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema 3,1");
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
            strIdentificador = fecFechaActual.Month.ToString() + fecFechaActual.Day.ToString();
            strIdentificador += fecFechaActual.Hour.ToString() + fecFechaActual.Minute.ToString();
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

                if(i == 0)
                    strResultado += string.Format(strPlantilla, arrAtributo[0], strTipo + arrAtributo[1] + strTipo);
                else
                    strResultado += "," + string.Format(strPlantilla, arrAtributo[0], strTipo + arrAtributo[1] + strTipo);
            }
            return "{" + strResultado + "}";
        }
    }
}
