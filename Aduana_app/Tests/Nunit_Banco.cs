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
            string strResultado = objBanco.transferencia_Cuenta("201300001", "1234123412341234", 100);
            Assert.AreEqual("{\"id_Transferecia\": 1028118,\"status\": 0,\"descripcion\": \"Transferencia Exitosa\"}", strResultado);
        }
    }
}