using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUygulaması3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;

            int sayi = 0;
            sayi = Convert.ToInt32(textBox1.Text);

            if(sayi>0 && sayi < 16)
            {
                richTextBox1.Text = String.Join("\t", Enumerable.Range(0, sayi + 1)) + new string('\n', 3);

                for (int i = 1; i <= sayi; ++i)
                {
                    richTextBox1.Text += i.ToString() + '\t';

                    for (int j = 1; j <= sayi; j++)
                    {
                        richTextBox1.Text += (i * j).ToString() + '\t';
                    }
                    richTextBox1.Text += new string('\n', 3);
                }

            }
            else
            {
                MessageBox.Show("Lütfen 1 ve 15 arasında bir Sayı giriniz!");
            }


        }

    }
}
