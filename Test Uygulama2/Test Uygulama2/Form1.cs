using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Uygulama2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int i = 1;
            while (i<= 200)
            {
                if (i>100 && i % 15 == 0)
                {
                    listBox1.Items.Add("zagzig");
                }
                else if (i % 15 == 0)
                {
                    listBox1.Items.Add("zigzag");
                }
                else if (i % 5 == 0)
                {
                    listBox1.Items.Add("zag");
                }
                else if (i%3==0)
                {
                    listBox1.Items.Add("zig");
                }



                if ( (i%15 !=0) && (i%3 !=0) && (i%5 != 0)){
                    listBox1.Items.Add(i);
                }

                i++;
            }

        }
    }
}
