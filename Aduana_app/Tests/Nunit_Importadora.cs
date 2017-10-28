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
            Assert.AreEqual("{\"nombre\":\"Jonatan Gonzalez\",\"no_Tarjeta\":\"1234123422223333\",\"status\":0,\"descripcion\":\"Validación correcta\"}", importadora.validar_Sesion("Yonkis", "pro"));
        }
    }
}