using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geld_Calculator;
using System.Windows.Forms;

namespace GeldCalculatorUnitTest
{
    [TestClass]
    public class MoneyCalculatorTest
    {
        MoneyCalculator calc = new MoneyCalculator();
        [TestMethod]
        public void totalTest()
        {
            calc.calculate(new string[15] { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" });
            Assert.AreEqual(888.88, calc.getTotal(), "Wrong total");
        }

        [TestMethod]
        [ExpectedException(typeof(System.FormatException))]
        public void illigalInputTest()
        {
            calc.calculate(new string[15] { "1", "h", "1", "1", "1", "1", "l", "1", "1", "1", "1", "1", "1", "1", "1" });
        }

        [TestMethod]
        public void formatMoneyTest()
        {
            double[] input = new double[] { 2.111, 3.999, 8.899999997999, 0.0000000001 };
            string[] expected = new string[] { "€2,11", "€4,00", "€8,90", "€0,00" };
            for (int i = 0; i < input.Length; i++)
            {
                Assert.AreEqual(expected[i], calc.formatMoney(input[i]), "Wrong fromat at: " + i);
            }
        }

        [TestMethod]
        public void parsingTest()
        {
            Assert.AreEqual((uint)4, calc.parseNumberPerType("  4   "));
            Assert.AreEqual((uint)0, calc.parseNumberPerType("     "));
            Assert.AreEqual((uint)0, calc.parseNumberPerType("\t\t\t"));
            Assert.AreEqual((uint)0, calc.parseNumberPerType("\n\n\n"));
            Assert.AreEqual((uint)0, calc.parseNumberPerType("  \t\n  "));
            Assert.AreEqual((uint)4294967295, calc.parseNumberPerType("123456789012345678901234567890"));
        }
    }
}
