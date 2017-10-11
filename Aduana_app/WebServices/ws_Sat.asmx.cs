using System;
using System.Collections.Generic;
using System.Data;
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
            string strResultado;
            try
            {
                strResultado = "";
                if (String.IsNullOrEmpty(marca)) { marca = null; }
                if (String.IsNullOrEmpty(linea)) { linea = null; }
                if (String.IsNullOrEmpty(modelo)) { modelo = null; }

                if (marca != null && linea != null && modelo != null)
                    strResultado = ConsultarImpuesto(marca, linea, modelo);
                else
                    strResultado = generateJson("valor,-1,2;status,1,2;descripcion,Parametros de Ingreso Invalidos,1");

                return strResultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return generateJson("valor,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1");
            }
        }

        [WebMethod]
        public string registro_Id_Compra(int id_Transferencia, double monto_Compra)
        {
            string strResultado;
            try
            {
                strResultado = "";
                if (id_Transferencia == 0) { id_Transferencia = -1; }
                if (monto_Compra == 0) { monto_Compra = -1; }

                if (id_Transferencia != -1 && monto_Compra != -1)
                    strResultado = RegistrarCompra(id_Transferencia, monto_Compra);
                else
                    strResultado = generateJson("status,1,2;descripcion,Tipo de Parametros Incorrecto,1");
                return strResultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return generateJson("status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1");
            }
        }

        [WebMethod]
        public string guardar_Manifiesto(string marca, string linea, string modelo, string fecha_Entrada, string pais_Origen)
        {
            string strResultado;
            DateTime fecFechaEntrega = DateTime.MinValue;
            try
            {
                strResultado = "";
                if (String.IsNullOrEmpty(marca)) { marca = null; }
                if (String.IsNullOrEmpty(linea)) { linea = null; }
                if (String.IsNullOrEmpty(modelo)) { modelo = null; }
                if (!String.IsNullOrEmpty(fecha_Entrada)) { fecFechaEntrega = DateTime.Parse(fecha_Entrada); }
                if (String.IsNullOrEmpty(pais_Origen)) { pais_Origen = null; }

                if (marca != null && linea != null && modelo != null && fecha_Entrada != null && pais_Origen != null)
                    strResultado = InsertarManifiesto(marca, linea, modelo, fecFechaEntrega, pais_Origen);
                else
                    strResultado = generateJson("num_Manifiesto,-1,2;status,1,2;descripcion,Tipo de Parametros Incorrecto,1");
                return strResultado;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return generateJson("num_Manifiesto,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1"); ;
            }
        }

        [WebMethod]
        public string guardar_Declaracion(string marca, string linea, string modelo, double precio, string fecha_Declaracion)
        {
            string strResultado;
            DateTime fecFechaDeclaracion = DateTime.MinValue;
            try
            {
                strResultado = "";
                if (String.IsNullOrEmpty(marca)) { marca = null; }
                if (String.IsNullOrEmpty(linea)) { linea = null; }
                if (String.IsNullOrEmpty(modelo)) { modelo = null; }
                if (!String.IsNullOrEmpty(fecha_Declaracion)) { fecFechaDeclaracion = DateTime.Parse(fecha_Declaracion); }
                if (precio == 0) { precio = -1; }

                if (marca != null && linea != null && modelo != null && fecha_Declaracion != null && precio != -1)
                    strResultado = InsertarDeclaracion(marca, linea, modelo, fecFechaDeclaracion, precio);
                else
                    strResultado = generateJson("num_Declaracion,-1,2;status,1,2;descripcion,Tipo de Parametros Incorrecto,1");
                return strResultado;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return generateJson("num_Declaracion,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1"); ;
            }
        }

        private string ConsultarImpuesto(string strMarca, string strLinea, string strModelo)
        {
            ConexionDB objAccesoDatos;
            DataSet datDatos;
            string strQuery = null;
            string strAtributos = null;
            try
            {
                objAccesoDatos = new ConexionDB();
                strQuery = " SELECT Factor "
                         + " FROM Linea LI "
                         + " JOIN Marca MA ON LI.Marca = MA.ID_Marca "
                         + " WHERE LI.Nombre LIKE '%" + strLinea + "%' "
                         + " AND MA.Nombre LIKE '%" + strMarca + "%' ";

                Console.Write(strQuery);

                datDatos = objAccesoDatos.selectDB(strQuery);
                strAtributos = "valor,-1,2;status,1,2;descripcion,No Existe Ningun Factor para los Parametros dados,1";
                if (datDatos != null && datDatos.Tables[0].Rows.Count > 0)
                {
                    double decFactor = double.Parse(datDatos.Tables[0].Rows[0]["Factor"].ToString());
                    int intAñoActual = DateTime.Now.Year;
                    int intModelo = int.Parse(strModelo);
                    double decValor = decFactor + (1000 / (intAñoActual - intModelo + 1)) + 200;
                    strAtributos = "valor,"+ decValor + ",2;status,0,2;descripcion,Exitoso,1";
                }
                return generateJson(strAtributos);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return generateJson("valor,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1");
            }
            finally
            {
                objAccesoDatos = null;
            }
        }

        private string RegistrarCompra(int intIDTransferencia, double decMonto)
        {
            ConexionDB objAccesoDatos;
            string strResultado = null;
            string strQuery = null;
            string strIdentificador = null;
            try
            {
                objAccesoDatos = new ConexionDB();
                strIdentificador = GenerarIdentificador();

                strQuery = "INSERT Compra(ID_Transferencia, Monto) ";
                strQuery += "VALUES ('" + strIdentificador + "','" + decMonto + "'); ";
                if (objAccesoDatos.modificarDB(strQuery) == 1)
                    strResultado = generateJson("status,0,2;descripcion,Exitoso,1");
                else
                    strResultado = generateJson("status,1,2;descripcion,No se pudo Insertar el Registro de Compra en la BD,1");
                return strResultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return generateJson("status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1");
            }
            finally
            {
                objAccesoDatos = null;
            }
        }

        private string InsertarManifiesto(string strMarca, string strLinea, string strModelo, DateTime fecFechaEntrega, string strPaisOrigen)
        {
            ConexionDB objAccesoDatos;
            string strResultado = null;
            string strQuery = null;
            string strIdentificador = null;
            try
            {
                objAccesoDatos = new ConexionDB();
                strIdentificador = GenerarIdentificador();

                strQuery =  "INSERT Manifiesto(Identificador, Marca, Linea, Modelo, Fecha_Entrega, Pais_Origen) ";
                strQuery += "VALUES ('" + strIdentificador + "','" + strMarca + "','" + strLinea + "','" + strModelo + "','" + fecFechaEntrega.ToString("yyyy/MM/dd") + "','" + strPaisOrigen + "') ";
                if (objAccesoDatos.modificarDB(strQuery) == 1)
                    strResultado = generateJson("num_Manifiesto," + strIdentificador + ",2;status,0,2;descripcion,Exitoso,1");
                else
                    strResultado = generateJson("num_Manifiesto," + "-1" + ",2;status,1,2;descripcion,No se pudo Insertar el Manifiesto en la BD,1");
                return strResultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return generateJson("num_Manifiesto,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1");
            }
            finally
            {
                objAccesoDatos = null;
            }
        }

        private string InsertarDeclaracion(string strMarca, string strLinea, string strModelo, DateTime fecFechaDeclaracion, double decPrecio)
        {
            ConexionDB objAccesoDatos;
            string strResultado = null;
            string strQuery = null;
            string strIdentificador = null;
            try
            {
                objAccesoDatos = new ConexionDB();
                strIdentificador = GenerarIdentificador();
                strQuery = "INSERT Declaracion(Identificador, Marca, Linea, Modelo, Fecha_Declaracion, Precio) ";
                strQuery += "VALUES ('" + strIdentificador + "','" + strMarca + "','" + strLinea + "','" + strModelo + "','" + fecFechaDeclaracion.ToString("yyyy/MM/dd") + "','" + decPrecio + "') ";
                if (objAccesoDatos.modificarDB(strQuery) == 1)
                    strResultado = generateJson("num_Declaracion," + strIdentificador + ",2;status,0,2;descripcion,Exitoso,1");
                else
                    strResultado = generateJson("num_Declaracion," + "-1" + ",2;status,1,2;descripcion,No se pudo Insertar la Declaracion en la BD,1");
                return strResultado;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return generateJson("num_Declaracion,-1,2;status,1,2;descripcion,Ocurrio un Error Inesperado en el Sistema,1");
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
