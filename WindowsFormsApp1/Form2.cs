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
    public partial class Form2 : Form
    {
        string evidencnaSt = null;

        public Form2(string ID)
        {
            InitializeComponent();
            stRezultatovCBox.SelectedIndex = 0;
            evidencnaSt = ID;

            if (ID == null)
            {
                MessageBox.Show("Napaka, evidenčna številka ni bila pridobljena.");
            }
            else
            {
                napolniSeznamGradiv();
            }


        }


        private void napolniSeznamGradiv()
        {
            int stRezultatovZaPrikaz = Convert.ToInt32(stRezultatovCBox.SelectedItem);
            string cobissURL = "https://plus.si.cobiss.net/opac7/bib/search/expert?c=as%3D0" + evidencnaSt + "&db=cobib&mat=allmaterials&max=" + stRezultatovZaPrikaz + "&sort=pyd";

            string celotnaHTMLvsebina = null;

            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            celotnaHTMLvsebina = client.DownloadString(cobissURL);

            MatchCollection naslovi = Regex.Matches(celotnaHTMLvsebina, @"odd biblioentry");


        }
    }
}
