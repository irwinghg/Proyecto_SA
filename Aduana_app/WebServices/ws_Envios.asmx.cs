using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
        public string cargar_Vehiculos()
        {

            try
            {
                ConexionDB_Envios conn = new ConexionDB_Envios();
                string sqlCommand = "select ln.ID_linea, mc.nombre as marca, ln.nombre as linea, '2017' as modelo, mc.pais as pais_origen, (ln.factor* 1000) as precio_vehiculo " +
                        " from linea ln " +
                        " join marca mc on mc.ID_marca = ln.marca;";
                DataSet resultado = conn.selectDB(sqlCommand);
                List<vehiculo> listadoVehiculos = new List<vehiculo>();

                if (resultado != null && resultado.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in resultado.Tables[0].Rows)
                    {
                        Random rn = new Random();
                        vehiculo objVehiculo = new vehiculo();
                        objVehiculo.id_vehiculo = Convert.ToInt32(dr["ID_linea"].ToString());
                        objVehiculo.marca = dr["marca"].ToString();
                        objVehiculo.linea = dr["linea"].ToString();
                        objVehiculo.modelo = Convert.ToInt32(rn.Next(1980, 2018));
                        objVehiculo.pais_Origen = dr["pais_origen"].ToString();
                        objVehiculo.precio_vehiculo = Convert.ToInt64(dr["precio_vehiculo"].ToString());
                        listadoVehiculos.Add(objVehiculo);

                    }
                }

                var json = JsonConvert.SerializeObject(new
                {
                    vehiculos = listadoVehiculos,
                    status = 0,
                    descripcion = "Exitoso"
                    
                });

                return json;
            }
            catch (Exception e) {
                var json = JsonConvert.SerializeObject(new
                {
                    vehiculos = "",
                    status = 1,
                    descripcion = "Error con la conexión a la BD de Envios"

                });

                return json;
            }
        }

        [WebMethod]
        public string calcular_Costo_Viaje(int id_vehiculo, string pais_destino) {
            long costoViaje = 0;
           
            
            try
            {
                ConexionDB_Envios conn = new ConexionDB_Envios();
                string sqlCommand = "select '2017' as modelo, mc.pais as pais_origen, CAST((ln.factor* 1000)*0.04 AS DECIMAL(18,0)) as precio_vehiculo " +
                     " from linea ln " +
                     " join marca mc on mc.ID_marca = ln.marca where ln.ID_linea = "+Convert.ToString(id_vehiculo)+ " ; ";
                DataSet resultado = conn.selectDB(sqlCommand);
                
                if (resultado != null && resultado.Tables[0].Rows.Count > 0)
                {
                    string valorstr = Convert.ToString(resultado.Tables[0].Rows[0]["precio_vehiculo"]);
                    Int64.TryParse(valorstr, out costoViaje);
                }

                var json = JsonConvert.SerializeObject(new
                {
                    costo_viaje = costoViaje,
                    status = 0,
                    descripcion = "Exitoso"

                });

                return json;
            }
            catch (Exception e)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    costo_viaje = 0,
                    status = 1,
                    descripcion = "Error"

                });

                return json;
            }
        }

        [WebMethod]
        public string obtener_Datos_Vehiculo(int id_vehiculo) {
            try
            {
                ConexionDB_Envios conn = new ConexionDB_Envios();
                string sqlCommand = "select ln.ID_linea, mc.nombre as marca, ln.nombre as linea, '2017' as modelo, mc.pais as pais_origen, (ln.factor* 1000) as precio_vehiculo " +
                        " from linea ln " +
                        " join marca mc on mc.ID_marca = ln.marca "+
                        " where ln.ID_linea ="+Convert.ToString(id_vehiculo)+";";
                DataSet resultado = conn.selectDB(sqlCommand);
                List<vehiculo> listadoVehiculos = new List<vehiculo>();
                vehiculo objVehiculo = new vehiculo();
                if (resultado != null && resultado.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in resultado.Tables[0].Rows)
                    {
                        Random rn = new Random();
                        
                        objVehiculo.id_vehiculo = Convert.ToInt32(dr["ID_linea"].ToString());
                        objVehiculo.marca = dr["marca"].ToString();
                        objVehiculo.linea = dr["linea"].ToString();
                        objVehiculo.modelo = Convert.ToInt32(rn.Next(1980, 2018));
                        objVehiculo.pais_Origen = dr["pais_origen"].ToString();
                        objVehiculo.precio_vehiculo = Convert.ToInt64(dr["precio_vehiculo"].ToString());
                        
                        break;
                    }
                }

                var json = JsonConvert.SerializeObject(new
                {
                    marca = objVehiculo.marca,
                    linea = objVehiculo.linea,
                    modelo = objVehiculo.modelo,
                    pais_Origen = objVehiculo.pais_Origen,
                    precio_Vehiculos = objVehiculo.precio_vehiculo,
                    status = 0,
                    descripcion = "Exitoso"

                });

                return json;
            }
            catch (Exception e)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    marca = "",
                    linea ="",
                    modelo =0,
                    pais_Origen ="",
                    precio_Vehiculos = 0,
                    status = 1,
                    descripcion = "Error con la conexión a la BD de Envios"

                });

                return json;
            }
        }

        [WebMethod]
        public string guardar_Transferencia(int id_transferencia, long monto)
        {
            try
            {
                ConexionDB_Envios conn = new ConexionDB_Envios();
                string sqlCommand = "insert into transferencia (ID_transferencia, monto, fecha_hora) values ('" + id_transferencia + "', " + Convert.ToString(monto) + " , SYSDATETIME());";
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
                else {
                    var json = JsonConvert.SerializeObject(new
                    {
                        status = 1,
                        descripcion = "Tipo de dato incorrecto"
                    });

                    return json;
                }

                
            }
            catch (Exception e)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    status = 1,
                    descripcion = "Tipo de dato incorrecto"
                });

                return json;
            }
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

        public class vehiculo {
            public int id_vehiculo { get; set; }
            public string marca { get; set; }
            public string linea { get; set; }
            public int modelo { get; set; }
            public string pais_Origen { get; set; }
            public double precio_vehiculo { get; set; }
        }

    }
}
