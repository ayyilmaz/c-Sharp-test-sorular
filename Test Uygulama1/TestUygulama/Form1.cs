using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ilk_sayi, ikinci_sayi, ucuncu_sayi, sonuc;
            ilk_sayi = Convert.ToInt32(textBox1.Text);
            ikinci_sayi = Convert.ToInt32(textBox2.Text);
            ucuncu_sayi = Convert.ToInt32(textBox3.Text);

            sonuc = ((ilk_sayi + ikinci_sayi) * ucuncu_sayi);
            textBox4.Enabled = true;
            textBox4.Text = Convert.ToString(sonuc);
        }
    }
}
