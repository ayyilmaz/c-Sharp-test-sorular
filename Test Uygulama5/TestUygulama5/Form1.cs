using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUygulama5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n_input;

            try //girilen ifadenin integer mı string mi olduğunu denetlemek için
            {
                
                n_input = Convert.ToInt32(textBox1.Text); //Girilen inputu integer a dönüştürüyor

                if (n_input > 0 && n_input < 50) //Sayı 1 ve 50 arasında girilmiş ise işlem 
                {
                    if (n_input == 1) //Eğer girilen sayı bir ise ilk değeri sıfır veriyor
                    {
                        textBox2.Text = Convert.ToString(n_input - 1);
                    }
                    else if (n_input > 1) //1 den yüksek bir sayı girdiğimizde alttaki fibonacci fonksiyonu devreye giriyor
                    {
                        int sayi = n_input - 1; 
                        int[] Fib = new int[sayi + 1];
                        Fib[0] = 0;
                        Fib[1] = 1;
                        for (int i = 2; i <= sayi; i++)
                        {
                            Fib[i] = Fib[i - 2] + Fib[i - 1];
                        }
                        //textBox2.Enabled = true; textbox enable yapmak istersek
                        textBox2.Text = Convert.ToString(Fib[sayi]); //outputu string olarak veriyor
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen 0 ila 50 arasında bir tam sayı giriniz!");
                }                                
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen Sayı Giriniz");
            }

        }
    }
}
