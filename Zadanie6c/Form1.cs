using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadanie6c.Properties;

namespace Zadanie6c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stan twojego konta wynosi: " + Settings.Default["StanKonta"].ToString() + " zl");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double userValue = double.Parse(textBox1.Text);
            double baseValue = Convert.ToDouble(Settings.Default["StanKonta"]);
            Settings.Default["StanKonta"] = baseValue + userValue;
            Settings.Default.Save();
            MessageBox.Show("Konto zostalo doladowane.");
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
            groupBox2.BackColor = Color.Transparent;
            groupBox3.BackColor = Color.Gainsboro;
            groupBox4.BackColor = Color.Gainsboro;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.BackColor = Color.Transparent;
            groupBox2.BackColor = Color.Gainsboro;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double userCash = double.Parse(textBox4.Text);
            double baseValue = Convert.ToDouble(Settings.Default["StanKonta"]);

            if (userCash > baseValue)
            {
                MessageBox.Show("Nie mozesz grac za wiecej niz masz na koncie.");
                textBox4.Clear();
            }
            else
            {
                groupBox4.BackColor = Color.Transparent;
                groupBox3.BackColor = Color.Gainsboro;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Visible = false;
            button14.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        List<int> randomNumberList = new List<int>();
        int number;
        Random r = new Random();

        private void button8_Click(object sender, EventArgs e)
        {
            randomNumberList.Clear();
            MessageBox.Show("Losujemy 6 liczb..." + "\r\n" + "Nacisnij 'ok'");
            groupBox5.Visible = true;

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    number = r.Next(Convert.ToInt32(Settings.Default["minNum"]), Convert.ToInt32(Settings.Default["maxNum"]));
                } while (randomNumberList.Contains(number));
                randomNumberList.Add(number);
            }

            for (int i = 0; i < 6; i++)
            {
                textBox8.Text = String.Join(", ", randomNumberList);
            }

            textBox9.Text = textBox5.Text + ", " + textBox6.Text + ", " + textBox7.Text;
        }

        int lostGames = 0;

        private void button13_Click(object sender, EventArgs e)
        {
            int number1 = int.Parse(textBox5.Text);
            int number2 = int.Parse(textBox6.Text);
            int number3 = int.Parse(textBox7.Text);
            double kwotaGracza = double.Parse(textBox4.Text);
            double wygrana;
            double baseValue = Convert.ToDouble(Settings.Default["StanKonta"]);

            if (randomNumberList.Contains(number1) && randomNumberList.Contains(number2) && randomNumberList.Contains(number3))
            {
                lostGames = 0;
                wygrana = kwotaGracza * 2;
                Settings.Default["StanKonta"] = baseValue + wygrana;
                Settings.Default.Save();
                MessageBox.Show("Trafiles 3 liczby!!! Wygrales: " + wygrana);   
            }
            else if ((randomNumberList.Contains(number1) && randomNumberList.Contains(number2)) || (randomNumberList.Contains(number1) && randomNumberList.Contains(number3)) || (randomNumberList.Contains(number2) && randomNumberList.Contains(number3)))
            {
                lostGames = 0;
                wygrana = kwotaGracza * 1.3;
                Settings.Default["StanKonta"] = baseValue + wygrana;
                Settings.Default.Save();
                MessageBox.Show("Trafiles 2 liczby!!! Wygrales: " + wygrana);
            }
            else
            {
                lostGames += 1;
                wygrana = 0;
                double liczba = 0;
                Settings.Default["StanKonta"] = baseValue - kwotaGracza;
                Settings.Default.Save();
                MessageBox.Show("Trafiles 1 lub zadna liczbe. Wygrales: " + wygrana);
                if (Settings.Default["StanKonta"].Equals(liczba))
                {
                    if (MessageBox.Show("Masz 0 zlotych na koncie" + "\r\n" + "Chcesz doladowac konto?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.SelectTab(tabPage1);
                        groupBox1.Visible = true;
                        textBox1.Clear();
                    }
                    else
                    {
                        button9.Visible = true;
                        button14.Visible = true;
                    }
                }
            }

            if(lostGames == 3)
            {
                MessageBox.Show("Przegrales trzeci razy z rzedu. Zamykanie gry...");
                Application.Exit();
            }

            using (StreamWriter sw = new StreamWriter(@"E:\temp\Gra.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine("Gracz: " + textBox2.Text + " " + textBox3.Text);
                sw.WriteLine("Wygrana: " + wygrana);
                sw.Dispose();
            }

            

            button9.Visible = true;
            button14.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
            button9.Visible = false;
            button14.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            textBox6.Visible = true;
            button11.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label9.Visible = true;
            textBox7.Visible = true;
            button12.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Czy na pewno chcesz wyjsc?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                tabControl1.SelectTab(tabPage1);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stan twojego konta wynosi: " + Settings.Default["StanKonta"].ToString() + " zl");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            textBox10.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            double userValue = double.Parse(textBox10.Text);
            double baseValue = Convert.ToDouble(Settings.Default["StanKonta"]);
            Settings.Default["StanKonta"] = baseValue + userValue;
            Settings.Default.Save();
            MessageBox.Show("Konto zostalo doladowane.");
            groupBox6.Visible = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            groupBox7.Visible = true;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            //
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int userValueMin = int.Parse(textBox11.Text);
            int userValueMax = int.Parse(textBox12.Text);

            if((userValueMax - userValueMin) >= 24)
            {
                Settings.Default["minNum"] = userValueMin;
                Settings.Default["maxNum"] = userValueMax;
                Settings.Default.Save();
                MessageBox.Show("Zakres losowanych liczb zostal zmieniony.");
                groupBox7.Visible = false;
            }
            else
            {
                MessageBox.Show("Program moze losowac z zakresu conajmniej 25 liczb. Zmien zakres liczb.");
            }

            
        }
    }
}
