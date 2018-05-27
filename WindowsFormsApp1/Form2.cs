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
        List<List<string>> tmpseznam = new List<List<string>>();



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
               
                
                foreach (ListViewItem item in cobissListView.Items)
                {
                    List<string> tmpvgnezden = new List<string>();
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    {
                        tmpvgnezden.Add(subitem.Text);                      
                    }
                    tmpseznam.Add(tmpvgnezden);
                }

                
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

        private void CobissButton_Click(object sender, EventArgs e)
        {
            cobissListView.Items.Clear();
            int stRezultatovZaPrikaz = Convert.ToInt32(stRezultatovCBox.SelectedItem);
            string cobissURL = "https://plus.cobiss.si/opac7/bib/search?q=" + CobissSearchtextbox.Text + "&db=cobib&mat=allmaterials&max=" + stRezultatovZaPrikaz;

            string celotnaHTMLvsebina = null;

            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            celotnaHTMLvsebina = client.DownloadString(cobissURL);

            string podatkiOdelu;
            List<string> seznamKnjig = new List<string>();
            MatchCollection zadetki = Regex.Matches(celotnaHTMLvsebina, @"title\svalue"">[\W\s\d\D]*?e-dostop");
            foreach (Match zadetek in zadetki)
            {
                podatkiOdelu = zadetek.Value;
                seznamKnjig.Add(podatkiOdelu);
            }
            for (int x = 0; x < seznamKnjig.Count; x++)
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
                    knjiga.SubItems.Add(" ");
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

            tmpseznam.Clear();
            foreach (ListViewItem item in cobissListView.Items)
            {
                List<string> tmpvgnezden = new List<string>();
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    tmpvgnezden.Add(subitem.Text);
                }
                tmpseznam.Add(tmpvgnezden);
            }

        }

        private void naslovgradivaBox_TextChanged(object sender, EventArgs e)
        {
            if (naslovgradivaBox.Text == "")
            {
                cobissListView.Items.Clear();
                for (int y = 0; y < tmpseznam.Count; y++)
                {
                    ListViewItem knjiga = new ListViewItem(tmpseznam[y][0]);
                    for (int x = 1; x < 5; x++)
                    {
                        knjiga.SubItems.Add(tmpseznam[y][x]);
                    }
                    cobissListView.Items.Add(knjiga);
                }
               // cobissListView = tmpview;
            }
           
            int index = 0;
            foreach (ListViewItem item in cobissListView.Items)
            {
                foreach(ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    bool vsebuje = subitem.Text.Contains(naslovgradivaBox.Text);
                    if (vsebuje==true)
                    {
                        break;
                    }
                    else
                    {
                        index++;
                        if(item.SubItems.Count==index)
                        {
                            item.Remove();
                        }
                    }
                }
            }
        }
    }
}
