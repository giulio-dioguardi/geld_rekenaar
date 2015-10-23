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
        string[] textBoxTexts;
        string[] outputs;
        double totaal;

        public string[] calculate(string[] textBoxTexts)
        {
            //this.textBoxTexts = textBoxTexts;
            readTextBoxes(textBoxTexts);
            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i] = subTotals[i].ToString();
            }
            return outputs;
        }



        public void calculateTotal()
        {
            totaal = 0;
            for (int i = 0; i < subTotals.Length; i++)
            {
                totaal += subTotals[i];
            }
        }

        public uint parseNumberPerType(string text)
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

        public void readTextBoxes(string[] textBoxTexts)
        {
            for (int i = 0; i < textBoxTexts.Length; i++)
            {
                uint parsedNumber = parseNumberPerType(textBoxTexts[i]);
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
            return outputs;
        }

        public string getTotalOutput()
        {
            return formatMoney(totaal);
        }

        public uint[] getNumberPerMoneyType()
        {
            return this.numberPerMoneyType;
        }

        public double[] getSubTotals()
        {
            return this.subTotals;
        }

        public double[] getMultipliers()
        {
            return this.multiplier;
        }
    }
}
