using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Aduana_app.Web_Services;

namespace Aduana_app.Tests
{
    [TestFixture]
    public class Nunit_Banco
    {
        [TestCase]
        public void transferencia_Cuenta()
        {
            ws_Banco objBanco = new ws_Banco();
            string strResultado = objBanco.transferencia_Cuenta("909090", "919191", 2000);
            Assert.AreEqual("{\"id_Transferencia\": \"30004999\",\"respuesta\": \"true\",\"detalle_Transferencia\": \"Transferencia Exitosa\"}", strResultado);
        }
    }
}