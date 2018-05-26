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
                Match avtor = Regex.Match(seznamKnjig[x],@"author\svalue");
                if (avtor.Success)
                {
                    Match podatki = Regex.Match(seznamKnjig[x], @"title\svalue"">([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)?<[\W\D\S]*?value"">([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)[\W\D\S]*?<span>([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)[\W\D\S]*?value"">([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)[\W\D\S]*?value"">([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)");
                    ListViewItem knjiga = new ListViewItem(podatki.Groups[1].Value);  //naslov
                    knjiga.SubItems.Add(podatki.Groups[2].Value);       //avtor
                    knjiga.SubItems.Add(podatki.Groups[3].Value);       //tip
                    knjiga.SubItems.Add(podatki.Groups[4].Value);       //jezik
                    knjiga.SubItems.Add(podatki.Groups[5].Value);       //leto izdaje
                    cobissListView.Items.Add(knjiga);
                }
                else
                {
                    Match podatki2 = Regex.Match(seznamKnjig[x], @"title\svalue"">([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)[\S\W\D]*?span>([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)[\S\W\D]*?value"">([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)[\S\W\D]*?value"">([\w\s\d\,\.\:\;\=\?\(\)\[\]\{\}\-\""]*)");
                    ListViewItem knjiga = new ListViewItem(podatki2.Groups[1].Value);  //naslov 
                    knjiga.SubItems.Add(Ime+" "+ Priimek);                            //avtor
                    knjiga.SubItems.Add(podatki2.Groups[2].Value);       //tip
                    knjiga.SubItems.Add(podatki2.Groups[3].Value);       //jezik
                    knjiga.SubItems.Add(podatki2.Groups[4].Value);       //leto izdaje
                    cobissListView.Items.Add(knjiga);
                }
            }
            
                


        }
    }
}
