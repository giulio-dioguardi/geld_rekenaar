using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geld_Calculator
{
    public partial class Form1 : Form
    {
        uint[] aantal = new uint[15];
        double[] subtotaal = new double[15];
        double[] multiplier = { 500, 200, 100, 50, 20, 10, 5, 2, 1,
                                   0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };
        double totaal;
        public Form1()
        {
            InitializeComponent();
        }

        private string FormattingTotal(double value)
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

        private double Calculation(uint aantal, double multiplier)
        {
            double subtotaal = aantal * multiplier;
            return subtotaal;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] box = { textBox2, textBox3, textBox4, textBox5, textBox6,
                            textBox7, textBox8, textBox9, textBox10, textBox11,
                            textBox12, textBox13, textBox14, textBox15, textBox16 };

            for (int i = 0; i < multiplier.Length; i++)
            {
                if (box[i].Text.Trim() == "")
                {
                    aantal[i] = 0;
                    box[i].Text = "0";
                }
                else
                {
                    try
                    {
                        aantal[i] = UInt32.Parse(box[i].Text);
                    }
                    catch (OverflowException)
                    {
                        aantal[i] = 4294967295;
                        box[i].Text = aantal.ToString();
                    }
                }
                subtotaal[i] = Calculation(aantal[i], multiplier[i]);
            }

            totaal = 0;
            for (int i = 0; i < subtotaal.Length; i++)
            {
                totaal += subtotaal[i];
            }

            Label[] labels = { label7, label9, label11, label13, label15, 
                                label17, label19, label21, label23,
                                label25,label27,label29,label31, label33,
                                label35 };
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = FormattingTotal(subtotaal[i]);
            }
            label36.Text = FormattingTotal(totaal);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            string tString = box.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    MessageBox.Show("Voer alstublieft een geldig getal in.");
                    box.Text = "0";
                    return;
                }
            }
            //If it get's here it's a valid number
            button1.PerformClick();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            TextBox[] box = { textBox2, textBox3, textBox4, textBox5, textBox6,
                            textBox7, textBox8, textBox9, textBox10, textBox11,
                            textBox12, textBox13, textBox14, textBox15, textBox16 };
            for (int i = 0; i < box.Length; i++)
            {
                box[i].Text = "0";
            }
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            FileNameMaker fileName = new FileNameMaker();
            try
            {
                string name = "GeldRekenaarOutput.csv";
                name = fileName.MakeUnique(name);
                System.IO.StreamWriter file = new System.IO.StreamWriter(name);
                file.WriteLine("Datum/tijd van opslag;" + System.DateTime.Now);
                file.WriteLine("Geldsoort;Aantal;Subtotaal");
                for (int i = 0; i < multiplier.Length; i++)
                {
                    file.WriteLine(multiplier[i].ToString() + ";" +
                        aantal[i] + ";" + subtotaal[i].ToString());
                }
                file.WriteLine("Totaal:;;" + totaal.ToString());
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
