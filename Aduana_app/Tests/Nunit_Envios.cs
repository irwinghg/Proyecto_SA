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
        public void solicitar_catalogo_Vehiculos()
        {
            ws_Envios envios = new ws_Envios();
            string salida = "{\"vehiculos\":[ {\"id_Vehiculo\": 300 , \"marca\": \"Toyota\", \"linea\": \"Yaris\", \"modelo\": \"2010\"}, {\"id_Vehiculo\": 310 , \"marca\": \"Nissan\", \"linea\": \"Navara\", \"modelo\": \"2016\"}, {\"id_Vehiculo\": 320 , \"marca\": \"Subaru\", \"linea\": \"WRX\", \"modelo\": \"2015\"}]}";
            Assert.AreEqual(salida, envios.cargar_Vehiculos());
        }

        [TestCase]
        public void calcular_Costo_viaje()
        {
            ws_Envios envios = new ws_Envios();
            string salida = "{\"costo_Viaje\": 600}";
            Assert.AreEqual(salida, envios.calcular_Costo_Viaje(55, "MX"));
        }

        [TestCase]
        public void guardar_transferencia()
        {
            ws_Envios envios = new ws_Envios();
            string salida = "{\"respuesta\": \"true\"}";
            Assert.AreEqual(salida, envios.guardar_Transferencia(55, 55));
        }


    }
}