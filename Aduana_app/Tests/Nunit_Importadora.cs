using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Aduana_app.Web_Services;
namespace Aduana_app.Tests
{
    [TestFixture]
    public class Nunit_Importadora
    {
        [TestCase]
        public void validar_Sesion_true() {
            ws_Importadora importadora = new ws_Importadora();
            Assert.AreEqual("{\"respuesta\": \"true\"}", importadora.validar_Sesion("admin", "12345"));
        }
        [TestCase]
        public void crear_cuenta()
        {
            ws_Importadora importadora = new ws_Importadora();
            Assert.AreEqual("{\"respuesta\": \"true\"}", importadora.crear_Cuenta("carlos","admin", "12345", "35677"));
        }

        [TestCase]
        public void solicitar_catalogo_Vehiculos()
        {
            ws_Importadora importadora = new ws_Importadora();
            string salida = "{\"vehiculos\":[ {\"id_Vehiculo\": 300 , \"marca\": \"Toyota\", \"linea\": \"Yaris\", \"modelo\": \"2010\"}, {\"id_Vehiculo\": 310 , \"marca\": \"Nissan\", \"linea\": \"Navara\", \"modelo\": \"2016\"}, {\"id_Vehiculo\": 320 , \"marca\": \"Subaru\", \"linea\": \"WRX\", \"modelo\": \"2015\"}]}";
            Assert.AreEqual(salida, importadora.solicitar_Catalogo_Vehiculos());
        }

        [TestCase]
        public void cotizar_Vehiculo()
        {
            ws_Importadora importadora = new ws_Importadora();
            string salida = "{\"precio_Vehiculo\": 25000,\"precio_Envio\": 3000,\"impuesto_Sat\": 200,\"iva\": 100,\"isr\": 300}";
            Assert.AreEqual(salida, importadora.cotizar_Vehiculo(33,"asd", "asdf", "asdf"));
        }

        [TestCase]
        public void comprar_Vehiculo()
        {
            ws_Importadora importadora = new ws_Importadora();
            string salida = "{\"serie\": \"A\" , \"numero_Factura\": \"8735\"}";
            Assert.AreEqual(salida, importadora.comprar_Vehiculo(33, "hola123",333, 50.3, 50.3, 50.3, 50.3, 50.3, 50.3));
        }

    }
}