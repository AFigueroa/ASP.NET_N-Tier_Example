using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACME.Common;

namespace ACME.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTestValid()
        {
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";


            var actual = source.InsertSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}
