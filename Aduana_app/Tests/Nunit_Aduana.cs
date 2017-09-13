using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Aduana_app.Web_Services;
namespace Aduana_app.Tests
{
    [TestFixture]
    public class Nunit_Aduana
    {
        [TestCase]
        public void calcular_Costo_Aduana()
        {
            ws_Aduana objAduana = new ws_Aduana();
            string strResultado = objAduana.calcular_Costo_Aduana("Honda", "Civic", "2010");
            Assert.AreEqual("{\"costo_Aduana\": 135.57}", strResultado);
        }

        [TestCase]
        public void guardar_Id_Transferencia()
        {
            ws_Aduana objAduana = new ws_Aduana();
            string strResultado = objAduana.guardar_Id_Transferencia(1209990, 90000);
            Assert.AreEqual("{\"respuesta\": \"true\"}", strResultado);
        }
    }
}