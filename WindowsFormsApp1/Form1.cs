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
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int procentMax1, procentMax2 = 0;
        private int stZadetkov = 0;
        private int stRezultatovZaPrikaz = 0;
        private string raziskovalecSearch = null;


        private List<ListViewItem> seznamItemovSicriss = new List<ListViewItem>();
        private List<string> seznamIDfakultet = new List<string>();
        System.Net.WebClient client = new System.Net.WebClient();

        public Form1()
        {
            InitializeComponent();
            sicrisWorker.WorkerReportsProgress = true;
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            client.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DownloadProgressChanged);

            fakulteteListView.Scrollable = true;
            fakulteteListView.View = View.Details;
            fakulteteListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            rezultatiListView.View = View.Details;
            rezultatiListView.FullRowSelect = true;
            rezultatiListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            stRezultatovCBox.SelectedIndex = 0;
            stRezultatovZaPrikaz = Convert.ToInt32(stRezultatovCBox.SelectedItem);
        }


        private void pocistiVse()
        {
            rezultatiListView.Items.Clear();
            seznamItemovSicriss.Clear();
            progressBarDownload.Value = 0;
            progressBarBranje.Value = 0;
            progressBarFill.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            napolniSeznamFakultet();
        }

        private void napolniSeznamFakultet()
        {
            string seznamFakultetRaw = null;

            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            seznamFakultetRaw = client.DownloadString("http://webservice.izum.si/ws-cris/CrisService.asmx/Retrieve?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI&entity=ORG&methodCall=nameadvanced=name=%20and%20sci=%20and%20fil=%20and%20sub=%20and%20statfrm=21%20and%20lang=slv");

            XmlDocument seznamFakultetXML = new XmlDocument();
            seznamFakultetXML.LoadXml(seznamFakultetRaw);

            XmlNodeList vseFakulteteRaw = seznamFakultetXML.GetElementsByTagName("Records");
            string dejanskiXML = vseFakulteteRaw[0].InnerText;      // preberemo dejanski XML ki se nahaja med <records> značkami, ki ga drugače narobe prebere

            XmlDocument vseFakultete = new XmlDocument();
            vseFakultete.LoadXml(dejanskiXML);

            XmlNodeList seznamFakultet = vseFakultete.GetElementsByTagName("ORG");

            for(int i=0; i< seznamFakultet.Count; i++)
            {
                ListViewItem fakulteta = new ListViewItem(seznamFakultet[i].SelectSingleNode("name").InnerText);
                string IDfakultete = seznamFakultet[i].Attributes[0].Value;
                seznamIDfakultet.Add(IDfakultete);
                fakulteteListView.Items.Add(fakulteta);

            }


        }



        private void iskanjeSicriss(int stRezultatovZaPrikaz)
        {
            string raziskovalecString = raziskovalciBox.Text;
            client.Encoding = System.Text.Encoding.UTF8;

            if (raziskovalciBox.Text != "")
            {
                string raziskovalecBesede = raziskovalecString.Replace(" ", "%20");

                string urlstring = "http://webservice.izum.si/ws-cris/CrisService.asmx/Retrieve?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI&entity=RSR&methodCall=auto=" + raziskovalecBesede + "%20and%20lang=slv";

                Uri uristring = new Uri(urlstring);

                client.DownloadFileAsync(uristring, "sicrisSearchData");
            
            }
        }

        private void branjeXML()
        {
            XmlDocument raziskovalecSearchXML = new XmlDocument();
            raziskovalecSearchXML.LoadXml(raziskovalecSearch);

            XmlNodeList recordsFound = raziskovalecSearchXML.GetElementsByTagName("RecordsFound");
            stZadetkov = Convert.ToInt32(recordsFound[0].InnerText);

            int stevecRezultatov = 0;

            if (stZadetkov < 15) //zato ko je 15 minimalna vrednost pa da ne bo exception če bo manj rezultatov kot 15
            {
                stevecRezultatov = stZadetkov;
            }
            else
            {
                stevecRezultatov = stRezultatovZaPrikaz;  //drugače pa naj gre do izbranega števila v comboboxu
            }

            XmlNodeList vsiRezultati = raziskovalecSearchXML.GetElementsByTagName("Records");
            string dejanskiXML = vsiRezultati[0].InnerText;      // preberemo dejanski XML ki se nahaja med <records> značkami, ki ga drugače narobe prebere

            XmlDocument najdeniRaziskovalci = new XmlDocument();
            najdeniRaziskovalci.LoadXml(dejanskiXML);

            XmlNodeList vsiRaziskovalci = najdeniRaziskovalci.GetElementsByTagName("RSR");


            for (int i = 0; i < stevecRezultatov; i++)
            {

                ListViewItem raziskovalec = new ListViewItem(vsiRaziskovalci[i].Attributes["mstid"].Value); // mstid = evidenčna št.

                if (vsiRaziskovalci[i].SelectSingleNode("abbrev") == null) // če ni naziva, prazno               //
                    raziskovalec.SubItems.Add(" ");                                                              //   abbrev = naziv
                else                                                                                             //
                    raziskovalec.SubItems.Add(vsiRaziskovalci[i].SelectSingleNode("abbrev").InnerText);          //

                raziskovalec.SubItems.Add(vsiRaziskovalci[i].SelectSingleNode("lname").InnerText); // priimek
                raziskovalec.SubItems.Add(vsiRaziskovalci[i].SelectSingleNode("fname").InnerText); // ime

                if (vsiRaziskovalci[i].SelectSingleNode("field") == null) // če ni razisk. področja, prazno       //
                    raziskovalec.SubItems.Add(" ");                                                              //   raziskovalno področje
                else                                                                                             //
                    raziskovalec.SubItems.Add(vsiRaziskovalci[i].SelectSingleNode("field").InnerText);           //

                if (vsiRaziskovalci[i].SelectSingleNode("science") == null)
                    raziskovalec.SubItems.Add(" ");
                else
                    raziskovalec.SubItems.Add(vsiRaziskovalci[i].SelectSingleNode("science").InnerText);         // glavno področje


                //email, dobimo json string in najdemo mail z regexom
                string json = client.DownloadString(" http://www.sicris.si/Common/rest.aspx?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI_JSON&entity=rsr&methodCall=id= " + vsiRaziskovalci[i].Attributes[1].Value + "%20and%20lang=slv");
                Match najdenMail = Regex.Match(json, @"EMAIL"":""(.*?)""");
                if (najdenMail.Success)
                {
                    string mail = najdenMail.Groups[1].Value;
                    raziskovalec.SubItems.Add(mail);
                }
                else
                    raziskovalec.SubItems.Add(" ");

                seznamItemovSicriss.Add(raziskovalec);

                //  rezultatiListView.Items.Add(raziskovalec);
                decimal iDec = Convert.ToDecimal(i);
                decimal stRezDec = Convert.ToDecimal(stRezultatovZaPrikaz);
                decimal nekaj = iDec / stRezDec;
                decimal zmnozek = nekaj * 100m;
                int procentComplete = Convert.ToInt32(zmnozek);
                if (procentComplete > procentMax1)
                {
                    procentMax1 = procentComplete;
                    sicrisWorker.ReportProgress(procentComplete);
                }

            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarDownload.Value = e.ProgressPercentage;
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            raziskovalecSearch = System.IO.File.ReadAllText("sicrisSearchData");
            statusBarLabel.Text = "Branje podatkov...";
            sicrisWorker.RunWorkerAsync();
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            pocistiVse();

            iskanjeSicriss(stRezultatovZaPrikaz);

            searchButton.Enabled = false;

            statusBarLabel.Text = "Nalaganje podatkov s spleta...";
        }





        private void rezultatiListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (rezultatiListView.SelectedItems.Count > 0)
                {
                    string ID = rezultatiListView.SelectedItems[0].Text;
                    string ime = rezultatiListView.SelectedItems[0].SubItems[2].Text;
                    string priimek = rezultatiListView.SelectedItems[0].SubItems[3].Text;
                    Form2 prikazGradivForm = new Form2(ID, ime, priimek);

                    prikazGradivForm.Show(this);

                }
            }

        }



        private void stRezultatovCBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            stRezultatovZaPrikaz = Convert.ToInt32(stRezultatovCBox.SelectedItem);

            //pocistiVse();

            //sicrissWorker.RunWorkerAsync();
        }

        private void sicrissWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            branjeXML();
        }

        private void sicrissWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusBar.Text = "Branje naloženih podatkov...";
            progressBarBranje.Value = e.ProgressPercentage;
        }

        private void fakulteteListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (fakulteteListView.SelectedItems.Count > 0)
                {
                    string ID = seznamIDfakultet[fakulteteListView.Items.IndexOf(fakulteteListView.SelectedItems[0])];
                    Form3 prikazFakulteteForm = new Form3(ID);
                    prikazFakulteteForm.Owner = this;
                    prikazFakulteteForm.Show(this);
                    fakulteteListView.Enabled = false;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 cobissSearch = new Form2(null, null, null);

            cobissSearch.Show(this);
        }

        private void sicrissWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int stItemov = seznamItemovSicriss.Count;

            statusBarLabel.Text = "Polnjenje seznama...";

            for (int i=0; i<stItemov; i++)
            {
                rezultatiListView.Items.Add(seznamItemovSicriss[i]);
                decimal iDec = Convert.ToDecimal(i);
                decimal stItemovDec = Convert.ToDecimal(stItemov);
                decimal zmnozek = iDec / stItemovDec;
                int procentComplete = Convert.ToInt32(zmnozek);
                if (procentComplete > procentMax2)
                {
                    procentMax2 = procentComplete;
                    progressBarFill.Value = procentComplete;
                }
            }

            progressBarFill.Value = 100;
            progressBarBranje.Value = 100;

            searchButton.Enabled = true;

            statusBarLabel.Text = "Iskanje končano! Najdenih " + stZadetkov + " rezultatov.";
            
        }
    }
}
