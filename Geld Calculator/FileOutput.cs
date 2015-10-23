using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geld_Calculator
{
    class FileOutput
    {
        public void saveFile(MoneyCalculator calc)
        {
            FileNameMaker fileName = new FileNameMaker();
            try
            {
                string name = "GeldRekenaarOutput.csv";
                name = fileName.MakeUnique(name);
                System.IO.StreamWriter file = new System.IO.StreamWriter(name);
                file.WriteLine("Datum/tijd van opslag;" + System.DateTime.Now);
                file.WriteLine("Geldsoort;Aantal;Subtotaal");
                for (int i = 0; i < calc.getMultipliers().Length; i++)
                {
                    file.WriteLine(calc.getMultipliers()[i].ToString() + ";" +
                        calc.getNumberPerMoneyType()[i] +
                        ";" + calc.getSubTotals()[i].ToString());
                }
                file.WriteLine("Totaal:;;" + calc.getTotalOutput());
                file.Close();
                MessageBox.Show("Het bestand is succesvol opgeslagen als: " + name, "Opslag bestand");
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Er is een fout opgetreden", "Fout");
            }
            catch (System.IO.InternalBufferOverflowException)
            {
                MessageBox.Show("Interne buffer is vol", "Fout");
            }
        }
    }
}
