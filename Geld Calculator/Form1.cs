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
        MoneyCalculator calc = new MoneyCalculator();
        TextBox[] textBoxes = new TextBox[15];
        Label[] labels = new Label[15];
        string[] stringOutputs = new string[15];

        public Form1()
        {
            InitializeComponent();
            textBoxes = new TextBox[] { textBox2, textBox3, textBox4, textBox5, textBox6,
                            textBox7, textBox8, textBox9, textBox10, textBox11,
                            textBox12, textBox13, textBox14, textBox15, textBox16 };
            labels = new Label[] { label7, label9, label11, label13, label15, 
                                label17, label19, label21, label23,
                                label25,label27,label29,label31, label33,
                                label35 };
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            calc.calculate(getTextBoxTexts());
            printToForm();
        }

        private void printToForm()
        {
            stringOutputs = calc.getOutputs();
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = stringOutputs[i];
            }
            label36.Text = calc.getTotalOutput();
        }

        private string[] getTextBoxTexts()
        {
            string[] textBoxTexts = new string[15];

            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxTexts[i] = textBoxes[i].Text;
            }
            return textBoxTexts;
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
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Text = "0";
            }
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            FileOutput fileOut = new FileOutput();
            fileOut.saveFile(calc);
        }
    }
}
