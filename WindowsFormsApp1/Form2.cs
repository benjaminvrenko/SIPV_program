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
        string Ime = null;
        string Priimek = null;

        public Form2(string ID, string ime,string priimek)
        {
            InitializeComponent();
            cobissListView.View = View.Details;
            cobissListView.FullRowSelect = true;
            cobissListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            stRezultatovCBox.SelectedIndex = 0;
            evidencnaSt = ID;
            Ime = ime;
            Priimek = priimek;


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
            string cobissURL = "https://plus.cobiss.si/opac7/bib/search?q=" + evidencnaSt + "&db=cobib&mat=allmaterials&max="+ stRezultatovZaPrikaz;

            string celotnaHTMLvsebina = null;

            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            celotnaHTMLvsebina = client.DownloadString(cobissURL);

            string podatkiOdelu;
            List<string> seznamKnjig = new List<string>();
            MatchCollection zadetki = Regex.Matches(celotnaHTMLvsebina, @"title\svalue"">[\W\s\d\D]*?e-dostop");
            foreach(Match zadetek in zadetki)
            {
                podatkiOdelu = zadetek.Value;
                seznamKnjig.Add(podatkiOdelu);
            }
            for(int x=0;x<seznamKnjig.Count;x++)
            {
                Match naslov = Regex.Match(seznamKnjig[x], @"title\svalue"">(.*)</a>");
                ListViewItem knjiga = new ListViewItem(naslov.Groups[1].Value);
                Match avtor = Regex.Match(seznamKnjig[x], @"author\svalue"">(.*)</span>");
                if (avtor.Success)
                {
                    knjiga.SubItems.Add(avtor.Groups[1].Value);
                }
                else
                {
                    knjiga.SubItems.Add(Ime+Priimek);
                }
                Match tip = Regex.Match(seznamKnjig[x], @"<span>(.*)</span>");
                if (tip.Success)
                {
                    knjiga.SubItems.Add(tip.Groups[1].Value);
                }
                else
                {
                    knjiga.SubItems.Add(" ");
                }
                Match jezik = Regex.Match(seznamKnjig[x], @"language-data""><span\sclass=""value"">(.*)</span></span>");
                if (jezik.Success)
                {
                    knjiga.SubItems.Add(jezik.Groups[1].Value);
                }
                else
                {
                    knjiga.SubItems.Add(" ");
                }
                Match leto = Regex.Match(seznamKnjig[x], @"publishDate-data""><span\sclass=""value"">(.*)</span></span>");
                if (leto.Success)
                {
                    knjiga.SubItems.Add(leto.Groups[1].Value);
                }
                else
                {
                    knjiga.SubItems.Add(" ");
                }
                cobissListView.Items.Add(knjiga);
                
            }
            
                


        }
    }
}
