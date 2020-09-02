using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadanie6c.Properties;

namespace Zadanie6c
{
    public class Gra : Form1
    {
        int[] randomNumber = new int[6];
        Random r = new Random();

        
        //public void LosowanieLiczb()
        //{
        //    for (int i = 0; i < randomNumber.Length; i++)
        //    {
        //        randomNumber[i] = r.Next(Convert.ToInt32(Settings.Default["minNum"]), Convert.ToInt32(Settings.Default["maxNum"]));
        //    }
        //    foreach (var item in randomNumber)
        //    {
        //        label10.Text = item.ToString();
               
        //    }
        //}

        

    //public void checkWin()
    //{
    //    int number1 = int.Parse(textBox5.Text);
    //    int number2 = int.Parse(textBox6.Text);
    //    int number3 = int.Parse(textBox7.Text);
    //    int kwotaGracza = int.Parse(textBox4.Text);
    //    double wygrana;

    //    for (int i = 0; i < randomNumber.Length; i++)
    //    {
    //        if(number1.Equals(randomNumber[i]) && number2.Equals(randomNumber[i]) && number3.Equals(randomNumber[i]))
    //        {
    //            wygrana = kwotaGracza * 2;
    //            Console.WriteLine(wygrana);
    //        }
    //        else if((number1.Equals(randomNumber[i]) && number2.Equals(randomNumber[i])) || (number1.Equals(randomNumber[i]) && number3.Equals(randomNumber[i])) || (number2.Equals(randomNumber[i]) && number3.Equals(randomNumber[i])))
    //        {
    //            wygrana = kwotaGracza * 1.3;
    //        }
    //        else if(number1.Equals(randomNumber[i]) || number2.Equals(randomNumber[i]) || number3.Equals(randomNumber[i]))
    //        {
    //            wygrana = 0;
    //        }
    //    }
    //}

    //kwotaGracza = int.Parse(Console.ReadLine());
}
}
