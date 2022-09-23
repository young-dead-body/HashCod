using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList M = new ArrayList();
        ArrayList RESULT = new ArrayList();

        private void button1_Click(object sender, EventArgs e)
        {
            M.Clear();
            RESULT.Clear();

            String s = textBox2.Text;
            int lenS = s.Length;
          

            string sde = textBox1.Text; 

            String Mes = textBox1.Text.Replace(" ", "");
            int lenMes = Mes.Length;

            int RSM = lenMes % lenS;
            if (RSM != 0)
            {
                int del = lenMes / lenS;
                int col = lenMes - del*lenS;
                Mes += "1";
                for (int i = 0; i < col-1; i++) {
                    Mes += "0";
                }
                textBox1.Clear();
                textBox1.Text = Mes;
            }

            comboBox1.Items.Clear();
            for (int i = 0; i < Mes.Length / lenS; i++)
            {
                string Message = "";
                for (int j = 0; j < lenS; j++)
                {
                    if (i == 0)
                    {
                        Message += Mes[i + j];
                    }
                    else {
                        Message += Mes[i* lenS + j];
                    }  
                }
                M.Add(Message);

                comboBox1.Items.Add(i + 1);
            }

            RESULT.Add(s);
            for (int i = 0; i < M.Count; i++)
            {
                string firstItem = RESULT[i].ToString();
                string secondItem = M[i].ToString();
                string firstResult = "";
                for (int j = 0; j < firstItem.Length; j++)
                {
                    if (firstItem[j] == secondItem[j])
                    {
                        firstResult += "0";
                    }
                    else
                    {
                        firstResult += "1";
                    }
                }
                string secondResult = "";

                for (int j = 0; j < firstItem.Length; j++)
                {
                    if (firstResult[j] == firstItem[j])
                    {
                        secondResult += "0";
                    }
                    else
                    {
                        secondResult += "1";
                    }
                }
                RESULT.Add(secondResult);
            }

            panel2.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cmb = comboBox1.SelectedIndex;
            textBox3.Text = M[cmb].ToString();
            textBox4.Text = RESULT[cmb].ToString();
            textBox7.Clear();
            textBox5.Clear();

            for (int j = 0; j < textBox3.Text.Length; j++)
            {
                if (textBox3.Text[j] == textBox4.Text[j])
                {
                    textBox5.Text += "0";
                }
                else
                {
                    textBox5.Text += "1";
                }
            }
            textBox6.Text = textBox4.Text;

            for (int j = 0; j < textBox3.Text.Length; j++)
            {
                if (textBox5.Text[j] == textBox6.Text[j])
                {
                    textBox7.Text += "0";
                }
                else
                {
                    textBox7.Text += "1";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = $"{textBox8.Text}.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(RESULT[0]);
                    for (int i = 0; i < M.Count; i++) {
                        sw.WriteLine(M[i]);
                        sw.WriteLine(separation("-"));
                        sw.WriteLine(RESULT[i+1]);
                        if (i % 2 > 0) 
                        {
                            sw.WriteLine(separation("="));
                        }
                    }
                    
                }
            }
        }

        private string separation(string sign) {
            string str = "";
            for (int i = 0; i < M[1].ToString().Length; i++) {
                str += sign;
            }
            return str;
        }
    }
}
