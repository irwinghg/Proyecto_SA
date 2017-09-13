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
            Assert.AreEqual("{\"valor\": 400}", strResultado);
        }

        [TestCase]
        public void registro_Id_Compra()
        {
            ws_Sat objSAT = new ws_Sat();
            string strResultado = objSAT.registro_Id_Compra(1209990, 80000);
            Assert.AreEqual("{\"respuesta\": \"true\"}", strResultado);
        }

        [TestCase]
        public void guardar_Manifiesto()
        {
            ws_Sat objSAT = new ws_Sat();
            string strResultado = objSAT.guardar_Manifiesto("Honda", "Civic", "2010", "20-10-2016", "EEUU");
            Assert.AreEqual("{\"num_Manifiesto\": 0155}", strResultado);
        }

        [TestCase]
        public void guardar_Declaracion()
        {
            ws_Sat objSAT = new ws_Sat();
            string strResultado = objSAT.guardar_Declaracion("Honda", "Civic", "2010", 100000, "10-09-2017");
            Assert.AreEqual("{\"num_Declaracion\": 0123}", strResultado);
        }
    }
}