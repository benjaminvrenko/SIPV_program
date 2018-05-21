using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string naslov, avtor, opis, kljucnebesede, cistobesedilo, letoizida, val1, val2, val3, val4;

        int stevecVnosov = 0;
        

        private void searchButton_Click(object sender, EventArgs e)
        {
            string naslovSearch, avtorSearch, kljucnebesedeSearch, letoizidaSearch = null;
            
            naslov = naslovBox.Text;
            avtor = avtorBox.Text;
            kljucnebesede = kljucnebesedeBox.Text;
            letoizida = letoizidaBox.Text;

            System.Net.WebClient client = new System.Net.WebClient();


            if(naslovBox.Text!= "")
            {
                stevecVnosov++;

                string op = null;
                string naslovBesede = naslov.Replace(" ", "+");


                if (comboBox1.SelectedIndex == 0)
                {
                    op = "and";
                }
                else
                {
                    op = "or";
                }


                string zlepljenString = "op" + stevecVnosov + "=" + op + "&val" + stevecVnosov + "=" + naslovBesede + "&col" + stevecVnosov + "=naslov&";

                //op1=and&val1=nekaj&col1=naslov

                naslovSearch = client.DownloadString("https://dk.um.si/ajax.php?cmd=getAdvancedSearch&source=dk&workType=0&language=0&" + zlepljenString +  "page=1");

            }
            if (avtorBox.Text != "")
            {
                stevecVnosov++;

                string op = null;
                string avtorBesede = avtor.Replace(" ", "+");


                if (comboBox2.SelectedIndex == 0)
                {
                    op = "and";
                }
                else
                {
                    op = "or";
                }


                string zlepljenString = "op" + stevecVnosov + "=" + op + "&val" + stevecVnosov + "=" + avtorBesede + "&col" + stevecVnosov + "=avtor&";

                //op1=and&val1=nekaj&col1=naslov

                avtorSearch = client.DownloadString("https://dk.um.si/ajax.php?cmd=getAdvancedSearch&source=dk&workType=0&language=0&" + zlepljenString + "page=1");
            }
            if (kljucnebesedeBox.Text != "")
            {
                stevecVnosov++;

                string op = null;
                string kljucnebesedeBesede = kljucnebesede.Replace(" ", "+");


                if (comboBox3.SelectedIndex == 0)
                {
                    op = "and";
                }
                else
                {
                    op = "or";
                }


                string zlepljenString = "op" + stevecVnosov + "=" + op + "&val" + stevecVnosov + "=" + kljucnebesedeBesede + "&col" + stevecVnosov + "=kljucneBesede&";

                //op1=and&val1=nekaj&col1=naslov

                kljucnebesedeSearch = client.DownloadString("https://dk.um.si/ajax.php?cmd=getAdvancedSearch&source=dk&workType=0&language=0&" + zlepljenString + "page=1");
            }
            if (letoizidaBox.Text != "")
            {
                stevecVnosov++;

                string op = null;
                string letoizidaBesede = letoizida.Replace(" ", "+");


                if (comboBox4.SelectedIndex == 0)
                {
                    op = "and";
                }
                else
                {
                    op = "or";
                }


                string zlepljenString = "op" + stevecVnosov + "=" + op + "&val" + stevecVnosov + "=" + letoizidaBesede + "&col" + stevecVnosov + "=letoIzida&";

                //op1=and&val1=nekaj&col1=naslov

                letoizidaSearch = client.DownloadString("https://dk.um.si/ajax.php?cmd=getAdvancedSearch&source=dk&workType=0&language=0&" + zlepljenString + "page=1");
            }



            if (naslovBox.Text != "")
            {

                string[] naslovBesede = naslov.Split(null);
                string zlepljenString = null;

                for (int i = 1; i <= naslovBesede.Length; i++)
                {
                    zlepljenString += "val" + i + "=" + naslovBesede[i - 1] + "&";
                }

                naslovSearch = client.DownloadString("https://dk.um.si/ajax.php?cmd=getAdvancedSearch&source=dk&workType=0&language=0&op1=and&" + zlepljenString + "col1=naslov&page=1");
            }



        }

        private void opisBox_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("bla");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
    }
}
