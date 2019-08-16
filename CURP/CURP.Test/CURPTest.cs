//-----------------------------------------------------------------------
// <copyright file="CURPTest.cs" company="">
//     Copyright (c). All rights reserved.
// </copyright>
// <author>Roberto Franco</author>
//-----------------------------------------------------------------------

namespace CURP.Test
{
    using System;

    using CURP;
    using CURP.Enums;

    using NUnit.Framework;

    [TestFixture]
    public class CURPTest
    {
        [Test]
        public void LetraInicial—Test()
        {
            var curp = Curp.Generar("Alberto", "—ando", "Rodriguez", Sexo.Hombre, new DateTime(2000, 01, 01), Estado.Aguascalientes);
            Assert.AreEqual("XARA", curp.Substring(0, 4));
        }

        [Test]
        public void NombreCompuestoTest()
        {
            var curp = Curp.Generar("Ma. de los angeles", "Moreno", "Sanchez", Sexo.Mujer, new DateTime(1998, 01, 01), Estado.San_Luis_Potosi);
            Assert.AreEqual("RNN", curp.Substring(13, 3));
        }

        [Test]
        public void ApellidoCompuestoTest()
        {
            var curp = Curp.Generar("Carlos", "Mc Gregor", "Lopez", Sexo.Hombre, new DateTime(1963, 01, 01), Estado.Sonora);
            Assert.AreEqual("GELC", curp.Substring(0, 4));
        }

        [Test]
        public void UnApellidoTest()
        {
            var curp = Curp.Generar("Luis", "Perez", null, Sexo.Hombre, new DateTime(1979, 01, 01), Estado.Zacatecas);
            Assert.AreEqual("PEXL", curp.Substring(0, 4));
        }

        [Test]
        public void PalabraAltisonanteTest()
        {
            var curp = Curp.Generar("Ofelia", "Pedrero", "Dominguez", Sexo.Mujer, new DateTime(1995, 03, 12), Estado.Campeche);
            Assert.AreEqual("PXDO", curp.Substring(0, 4));
        }

        [Test]
        public void NoVocalInternaTest()
        {
            var curp = Curp.Generar("Andres", "Ich", "Rodriguez", Sexo.Hombre, new DateTime(1984, 12, 06), Estado.Campeche);
            Assert.AreEqual("IXRA", curp.Substring(0, 4));
        }
    }
}