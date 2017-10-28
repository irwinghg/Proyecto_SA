using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Aduana_app.Web_Services;
namespace Aduana_app.Tests
{
    [TestFixture]
    public class Nunit_Envios
    {
        [TestCase]
        public void calcular_Costo_viaje()
        {
            ws_Envios envios = new ws_Envios();
            //RANDOM
            //string salida = "{\"costo_viaje\":5742,\"status\":0,\"descripcion\":\"Exitoso\"}";
            //Assert.AreEqual(salida, envios.calcular_Costo_Viaje(1, "Colombia"));
        }

        [TestCase]
        public void obtener_Datos_Vehiculo()
        {
            //ws_Envios envios = new ws_Envios();
            //string salida = "{\"marca\":\"ABARTH\",\"linea\":\"500C\",\"modelo\":1996,\"pais_Origen\":\"China\",\"precio_Vehiculo\":143560.0,\"status\":0,\"descripcion\":\"Exitoso\"}";
            //Assert.AreEqual(salida, envios.obtener_Datos_Vehiculo(1));
        }

    }
}