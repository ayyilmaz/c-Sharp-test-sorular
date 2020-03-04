using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace TestUygulamasi8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Enabled = false;
            listBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) // Dosya Seçme Butonu
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //metin dosyalarını seçmemizi sağlıyor
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null) // seçilen dosyadan gelen veri boş değilse myStream değişkenini uyguluyor
                    {
                        using (myStream)
                        {
                            textBox1.Text = File.ReadAllText(openFileDialog1.FileName); // file'dan gelen veriyi textbox! e aktardık
                            textBox3.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: Dosya okunamadı. Hata: " + ex.Message);
                }
            }
        }
// -------------------------------------------
        private void button2_Click(object sender, EventArgs e) //Büyükten küçüğe textboxa sıralama butonu
        {
            //Linq çözümü

            try
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox3.Enabled = false;
                    MessageBox.Show("Sıralama yapmak için lütfen sadece sayı içeren metin dosyası seçiniz veya kutuya sayı giriniz ");
                }
                else
                {
                    textBox3.Enabled = true;
                }

                var str = textBox1.Text; // str variable ını textbox taki verilere eşleştirdik
                var currentCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                //decimal karakterler arasındaki virgülü uygulamak için System.Globalization kütüphanesi içerisindeki Culture özelliğini kullandık
                currentCulture.NumberFormat.NumberDecimalSeparator = ","; // decimal karakterler arasında virgülle ayrım yap
                currentCulture.NumberFormat.NumberGroupSeparator = "."; // basamak ayracı olarak nokta kullanıyor

                //str içerisindeki yani texbox içeirisindeki dosyadan gelen sayıları split ile aralarındaki boşlukları temizleyerek
                //string array içeirsine atıyoruz. StringSplitOptions.RemoveEmptyEntries ile aralardaki boşluklar siliniyor ve
                // " ", Environment.NewLine ile her bir sayıdan sonra yeni satıra geçmesi sağlanıyor öncesindeki " "ile bu yeni satıra geçme belirleniyor.
                var numbers = str.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(num => decimal.Parse(num, currentCulture))
                                     //decimal sayıları currentCulture da belirtilen özelliklere göre dönüştürür. ondalıklı sayıları nokta yerine virgülle ayırmak için
                                     .OrderByDescending(num => num); //sayıları büyüğe küçüğe sıralama
                textBox3.Text = string.Join(Environment.NewLine, numbers);// textbox içeirine her bir satırdaki sıralanmış sayıyı alıp koyar

            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen Yalnızca Sayı Giriniz");
            }


        }
// -------------------------------------------
        private void button4_Click(object sender, EventArgs e) //küçükten büyüğe sıralama textbox butonu
        {
            try
            {
                if (textBox1.Text.Length == 0) //kutu boşsa 2. sıradaki textbox disabled olacak
                {
                    textBox3.Enabled = false;
                    MessageBox.Show("Sıralama yapmak için lütfen sadece sayı içeren metin dosyası seçiniz veya kutuya sayı giriniz ");
                }
                else
                {
                    textBox3.Enabled = true;
                }

                var str = textBox1.Text;
                var currentCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                currentCulture.NumberFormat.NumberDecimalSeparator = ",";
                currentCulture.NumberFormat.NumberGroupSeparator = ".";

                var numbers = str.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(num => decimal.Parse(num, currentCulture))
                                     .OrderBy(num => num); // Küçükten büyüğe sırala
                textBox3.Text = string.Join(Environment.NewLine, numbers);
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen Yalnızca Sayı Giriniz");
            }

        }
// -------------------------------------------
        private void button3_Click(object sender, EventArgs e)  // büyükten küçüğe sıralama listbox butonu
        {
            try
            {
                if (textBox1.Text.Length == 0) //kutu boşsa 2. sıradaki textbox disabled olacak
                {
                    listBox1.Enabled = false; 
                    MessageBox.Show("Sıralama yapmak için lütfen sadece sayı içeren metin dosyası seçiniz veya kutuya sayı giriniz ");
                }
                else
                {
                    listBox1.Enabled = true; //textbox doluysa listBox1 enable görünecek
                }

                listBox1.Items.Clear(); //butona he basıldığında önceki verileri temizliyor
                List<decimal> nums = new List<decimal>(); // list decimal olarak bir nevi array tanımlanıyor
                for (int i = 0; i < textBox1.Lines.Count(); ++i) //textbox1 deki satır sayısı kadar döngüye sokar
                {
                    /* string[] line array değişkenine textbox1 içeirindeki her satırda 
                      StringSplitOptions.RemoveEmptyEntries ile gereksiz boşlukları silme işlemi yapıyor
                      ardından new char[] { ' ' } ile her birini char dizisi içerisine atıyor
                     */
                    string[] line = textBox1.Lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    /*line içerisindeki her bir değeri s değişkenine atıyor ve ardından
                    bunu yaparken currentCulture içeirinde belirttiğimiz decimal sayıları ayracı kuralını
                    uyguluyor ve daha önce tanımladığımız nums array içerisine kural uygulanmış sayıları ekliyor                        
                    */
                    foreach (string s in line)
                    {
                        nums.Add(decimal.Parse(s, NumberStyles.Number, new CultureInfo("tr-TR")));
                        var currentCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                        currentCulture.NumberFormat.NumberDecimalSeparator = ",";
                        currentCulture.NumberFormat.NumberGroupSeparator = ".";
                    }
                }

                foreach (decimal d in nums.OrderByDescending(x => x)) //nums arrayi içerisindekileri artan şekilde sıralıyor
                {
                    listBox1.Items.Add(d.ToString()); // num array içeirndeki sıralanmış sayıları listbox'a yazdırıyor
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen Yalnızca Sayı Giriniz");
            }

        }
// -------------------------------------------
        private void button5_Click(object sender, EventArgs e) //küçükten büyüğe sıralama listbox
        {

            try
            {
                if (textBox1.Text.Length == 0) //kutu boşsa 2. sıradaki textbox disabled olacak
                {
                    listBox1.Enabled = false;
                    MessageBox.Show("Sıralama yapmak için lütfen sadece sayı içeren metin dosyası seçiniz veya kutuya sayı giriniz ");
                }
                else
                {
                    listBox1.Enabled = true; //doluysa enable görünecek
                }
                listBox1.Items.Clear();
                List<decimal> nums = new List<decimal>();
                for (int i = 0; i < textBox1.Lines.Count(); ++i)
                {
                    string[] line = textBox1.Lines[i].Split(new char[] { ' ' },
                                                            StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in line)
                    {
                        nums.Add(decimal.Parse(s, NumberStyles.Number, new CultureInfo("tr-TR")));
                        var currentCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                        currentCulture.NumberFormat.NumberDecimalSeparator = ",";
                        currentCulture.NumberFormat.NumberGroupSeparator = ".";
                    }
                }

                foreach (decimal d in nums.OrderBy(x => x))
                {
                    listBox1.Items.Add(d.ToString());
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen Yalnızca Sayı Giriniz");
            }
        }
// -------------------------------------------

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
