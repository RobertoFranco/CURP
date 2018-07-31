namespace CalculadorCurp.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CurpTest
    {
        [TestMethod]
        public void LetraInicialÑTest()
        {
            var curp = new Curp("Alberto", "Ñando", "Rodriguez", Sexo.Hombre, new DateTime(2000, 01, 01), Estado.Aguascalientes);
            Assert.AreEqual("XARA", curp.CURP.Substring(0, 4));
        }

        [TestMethod]
        public void NombreCompuestoTest()
        {
            var curp = new Curp("Ma. de los angeles", "Moreno", "Sanchez", Sexo.Mujer, new DateTime(1998, 01, 01), Estado.San_Luis_Potosi);
            Assert.AreEqual("RNN", curp.CURP.Substring(13, 3));
        }

        [TestMethod]
        public void ApellidoCompuestoTest()
        {
            var curp = new Curp("Carlos", "Mc Gregor", "Lopez", Sexo.Hombre, new DateTime(1963, 01, 01), Estado.Sonora);
            Assert.AreEqual("GELC", curp.CURP.Substring(0, 4));
        }

        [TestMethod]
        public void UnApellidoTest()
        {
            var curp = new Curp("Luis", "Perez", null, Sexo.Hombre, new DateTime(1979, 01, 01), Estado.Zacatecas);
            Assert.AreEqual("PEXL", curp.CURP.Substring(0, 4));
        }

        [TestMethod]
        public void PalabraAltisonanteTest()
        {
            var curp = new Curp("Ofelia", "Pedrero", "Dominguez", Sexo.Mujer, new DateTime(1995, 03, 12), Estado.Campeche);
            Assert.AreEqual("PXDO", curp.CURP.Substring(0, 4));
        }

        [TestMethod]
        public void NoVocalInternaTest()
        {
            var curp = new Curp("Andres", "Ich", "Rodriguez", Sexo.Hombre, new DateTime(1984, 12, 06), Estado.Campeche);
            Assert.AreEqual("IXRA", curp.CURP.Substring(0, 4));
        }
    }
}