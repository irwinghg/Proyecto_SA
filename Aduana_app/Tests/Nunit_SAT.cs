using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Aduana_app.Web_Services;

namespace Aduana_app.Tests
{
    [TestFixture]
    public class Nunit_SAT
    {
        [TestCase]
        public void calcular_Impuesto_Sat()
        {
            ws_Sat objSAT = new ws_Sat();
            string strResultado = objSAT.calcular_Impuesto_Sat("Honda","Civic","2010");
            Assert.AreEqual("{\"valor\": 483,\"status\": 0,\"descripcion\": \"Exitoso\"}", strResultado);
        }

        [TestCase]
        public void registro_Id_Compra()
        {
            ws_Sat objSAT = new ws_Sat();
            string strResultado = objSAT.registro_Id_Compra(1209990, 80000);
            Assert.AreEqual("{\"status\": 0,\"descripcion\": \"Exitoso\"}", strResultado);
        }
    }
}