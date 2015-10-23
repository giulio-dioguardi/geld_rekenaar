using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geld_Calculator
{  
    public class MoneyCalculator
    {
        uint[] numberPerMoneyType = new uint[15];
        double[] subTotals = new double[15];
        double[] multiplier = { 500, 200, 100, 50, 20, 10, 5, 2, 1,
                                   0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };
        string[] inputTexts = new string[15];
        string[] outputTexts = new string[15];
        double total;

        public void calculate(string[] textBoxTexts)
        {
            readTextBoxes(textBoxTexts);
            for (int i = 0; i < outputTexts.Length; i++)
            {
                outputTexts[i] = formatMoney(subTotals[i]);
            }
            calculateTotal();
        }

        private void calculateTotal()
        {
            total = 0;
            for (int i = 0; i < subTotals.Length; i++)
            {
                total += subTotals[i];
            }
        }

        private uint parseNumberPerType(string text)
        {
            uint number;
            if (text.Trim() == "")
            {
                number = 0;
                text = "0";
            }
            else
            {
                try
                {
                    number = UInt32.Parse(text);
                }
                catch (OverflowException)
                {
                    number = 4294967295;
                }
            }
            return number;
        }

        private void readTextBoxes(string[] textBoxTexts)
        {
            for (int i = 0; i < textBoxTexts.Length; i++)
            {
                uint parsedNumber = parseNumberPerType(textBoxTexts[i]);
                numberPerMoneyType[i] = parsedNumber;
                subTotals[i] = calculateSubTotal(numberPerMoneyType[i], multiplier[i]);
            }
        }

        private double calculateSubTotal(uint aantal, double multiplier)
        {
            return aantal * multiplier;
        }

        private string formatMoney(double value)
        {
            value *= 100;
            value = Math.Round(value);
            if (value % 100 == 0)
            {
                value /= 100;
                return "€" + value + ",00";
            }
            else if (value % 10 == 0)
            {
                value /= 100;
                return "€" + value + "0";
            }
            else
            {
                value /= 100;
                return "€" + value;
            }
        }

        public string[] getOutputs()
        {
            return outputTexts;
        }

        public string getTotalOutput()
        {
            return formatMoney(total);
        }

        public uint[] getNumberPerMoneyType()
        {
            return this.numberPerMoneyType;
        }

        public double[] getSubTotals()
        {
            return this.subTotals;
        }

        public double getTotal()
        {
            return this.total;
        }

        public double[] getMultipliers()
        {
            return this.multiplier;
        }
    }
}
