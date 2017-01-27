using System;
using Boilerplate.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boilerplate.Test.Unit.Common
{
    [TestClass]
    public class Extensions
    {
        [TestMethod]
        public void StringIsNullOrWhiteSpaceExtension()
        {
            string nothing1 = null;
            string nothing2 = string.Empty;
            string nothing3 = "   ";
            string something = "A string";

            Assert.IsTrue(nothing1.IsNullOrWhiteSpace());
            Assert.IsTrue(nothing2.IsNullOrWhiteSpace());
            Assert.IsTrue(nothing3.IsNullOrWhiteSpace());

            Assert.IsFalse(something.IsNullOrWhiteSpace());
        }
    }
}