using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geld_Calculator;
using System.Windows.Forms;

namespace GeldCalculatorUnitTest
{
    [TestClass]
    public class MoneyCalculatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MoneyCalculator calc = new MoneyCalculator();
            calc.calculate(new string[15] { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" });
            Assert.AreEqual(calc.getTotal(), 888.88, "Wrong total");
        }
    }
}
