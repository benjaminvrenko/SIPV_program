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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
  

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
                fakulteteListView.Items.Add(fakulteta);

            }


        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            rezultatiListView.Items.Clear();

            string raziskovalecString;
            string raziskovalecSearch = null;
            

            raziskovalecString = raziskovalciBox.Text;


            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            if (raziskovalciBox.Text != "")
            {
                string raziskovalecBesede = raziskovalecString.Replace(" ", "%20");

                string urlstring = "http://webservice.izum.si/ws-cris/CrisService.asmx/Retrieve?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI&entity=RSR&methodCall=auto=" + raziskovalecBesede + "%20and%20lang=slv";

                raziskovalecSearch = client.DownloadString(urlstring);              

                XmlDocument raziskovalecSearchXML = new XmlDocument();
                raziskovalecSearchXML.LoadXml(raziskovalecSearch);

                XmlNodeList recordsFound = raziskovalecSearchXML.GetElementsByTagName("RecordsFound");
                int steviloZadetkov = Convert.ToInt32(recordsFound[0].InnerText);
                toolStripStatusLabel1.Text = "Število zadetkov: " + steviloZadetkov;

                int stRezultatovZaPrikaz = Convert.ToInt32(stRezultatovCBox.SelectedItem);
                int stevecRezultatov = 0;

                if (steviloZadetkov < 15) //zato ko je 15 minimalna vrednost pa da ne bo exception če bo manj rezultatov kot 15
                {
                    stevecRezultatov = steviloZadetkov;
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
                    
                    if(vsiRaziskovalci[i].SelectSingleNode("field") == null) // če ni razisk. področja, prazno       //
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

                    rezultatiListView.Items.Add(raziskovalec);


                 
                }






            }




            //if (nazivBox.Text != "")
            //{

            //    string[] nazivBesede = naziv.Split(null);
            //    string zlepljenString = null;

            //    for (int i = 1; i <= nazivBesede.Length; i++)
            //    {
            //        zlepljenString += "val" + i + "=" + nazivBesede[i - 1] + "&";
            //    }

            //    nazivSearch = client.DownloadString("https://dk.um.si/ajax.php?cmd=getAdvancedSearch&source=dk&workType=0&language=0&op1=and&" + zlepljenString + "col1=naziv&page=1");
            //}



        }


        public Form1()
        {
            InitializeComponent();

            fakulteteListView.Scrollable = true;
            fakulteteListView.View = View.Details;
            fakulteteListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);

            rezultatiListView.View = View.Details;
            rezultatiListView.FullRowSelect = true;
            rezultatiListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            stRezultatovCBox.SelectedIndex = 0;


        }


        private void rezultatiListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string ID = rezultatiListView.SelectedItems[0].Text;

                Form2 prikazGradivForm = new Form2(ID);
                
                prikazGradivForm.Show(this);


            }

        }
    }
}
