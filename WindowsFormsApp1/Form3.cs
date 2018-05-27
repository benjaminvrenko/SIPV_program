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
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private string fakultetaID = null;
        List<List<string>> vsiPodatkiFakultete = new List<List<string>>();
        private string celotnaHTMLvsebina = null;

        List<string> imenapriimki = new List<string>();
        List<string> imenaProjektov = new List<string>();
        List<string> IDProjektov = new List<string>();
        List<string> imenaskupin = new List<string>();
        List<string> idSkupin = new List<string>();
        List<string> imenaProgramov = new List<string>();
        List<string> idProgramov = new List<string>();

        string imeFaxa = null;
        string mesto = null;
        string priimekDekana, imeDekana = null;
        string naziv1, naziv2 = null;
        string naslov, postnaSt, mesto2, drzava = null;
        string telefon, fax, mail, splet = null;

        System.Net.WebClient client = new System.Net.WebClient();


        public Form3(string ID)
        {
            InitializeComponent();
            projektiListView.View = View.Details;
            programiListView.View = View.Details;
            skupineListView.View = View.Details;

            vsiRaziskListBox.ScrollAlwaysVisible = true;

            projektiListView.FullRowSelect = true;
            programiListView.FullRowSelect = true;
            skupineListView.FullRowSelect = true;

            projektiListView.FullRowSelect = true;
            projektiListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            programiListView.FullRowSelect = true;
            programiListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            skupineListView.FullRowSelect = true;
            skupineListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);


            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            client.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DownloadProgressChanged);

            fakultetaID = ID;

            if (fakultetaID == null)
            {
                MessageBox.Show("Napaka! ID fakultete ni bil pridobljen.");
            }
            else
            {
                iskanjeSicrisFakulteta();
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void sicrisWorkerFaks_DoWork(object sender, DoWorkEventArgs e)
        {
            branjeJSON();
        }

        private void sicrisWorkerFaks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Branje končano! Polnjenje seznamov...";
            napolniListView();
        }

        private void napolniListView()
        {
            nazivLabel.Text = "Naziv: " + imeFaxa;
            krajLabel.Text = "Kraj: " + mesto;
            odgOsebaLabel.Text = "Odgovorna oseba: " + naziv2 + " " + imeDekana + " " + priimekDekana + ", " + naziv1;
            naslovLabel.Text = "Naslov: " + naslov + ", " + postnaSt + " " + mesto2 + ", " + drzava;
            telefonLabel.Text = "Telefon: " + telefon;
            faksLabel.Text = "Faks: " + fax;
            emailLabel.Text = "E-pošta: " + mail;
            websiteLabel.Text = "Spletni naslov: " + splet;



            for(int i=0; i < imenaProjektov.Count; i++)
            {
                projektiListView.Items.Add(imenaProjektov[i]);
            }

            for(int j=0; j < imenaProgramov.Count; j++)
            {
                programiListView.Items.Add(imenaProgramov[j]);
            }

            for(int k = 0; k < imenaskupin.Count; k++)
            {
                skupineListView.Items.Add(imenaskupin[k]);
            }

            for(int z = 0; z < imenapriimki.Count; z++)
            {
                vsiRaziskListBox.Items.Add(imenapriimki[z]);
            }
            vsiRaziskListBox.HorizontalScrollbar = true;

            toolStripStatusLabel1.Text = "Končano!";

        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Podatki naloženi! Branje podatkov z JSON...";
            celotnaHTMLvsebina = System.IO.File.ReadAllText("podatkiZaFakulteto");
            sicrisWorkerFaks.RunWorkerAsync();
        }

        private void iskanjeSicrisFakulteta()
        {
            string sicrisURL = "http://www.sicris.si/Common/rest.aspx?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI_JSON&entity=org&methodCall=id=" + fakultetaID + "%20and%20lang=slv";
            Uri sicrisURI = new Uri(sicrisURL);
            string celotnaHTMLvsebina = null;

            client.Encoding = System.Text.Encoding.UTF8;
            toolStripStatusLabel1.Text = "Nalaganje podatkov z interneta...";
            client.DownloadFileAsync(sicrisURI, "podatkiZaFakulteto");
        }

        private void branjeJSON()
        {
            Match IDZadetki = Regex.Match(celotnaHTMLvsebina, @"""MSTID"":""(\d*)?");         //ID faxa
            string IDFAxa = IDZadetki.Groups[1].Value;

            Match imeZadetki = Regex.Match(celotnaHTMLvsebina, @"""NAME"":""(.*?)""");          //ime faxa
            imeFaxa = imeZadetki.Groups[1].Value;

            Match mestoZadetki = Regex.Match(celotnaHTMLvsebina, @"""CITY"":""(.*?)""");          //mesto kjer se nahaja
            mesto = mestoZadetki.Groups[1].Value;

            Match dekanZadetki = Regex.Match(celotnaHTMLvsebina, @"""DIR_LNAME"":""(.*?)"",""DIR_FNAME"":""(.*?)""");         //ime in priimek dekana
            priimekDekana = dekanZadetki.Groups[1].Value;
            imeDekana = dekanZadetki.Groups[2].Value;

            Match dekanNaziviZadetki = Regex.Match(celotnaHTMLvsebina, @"""DIRFUN"":""(.*?)"",""DIRTTLPRE"":""(.*?)""");         //nazivi dekana
            naziv1 = dekanNaziviZadetki.Groups[1].Value;
            naziv2 = dekanNaziviZadetki.Groups[2].Value;

            Match naslovZadetki = Regex.Match(celotnaHTMLvsebina, @"""ADDR1"":""(.*?)"",""POSTALCODE"":""(.*?)"",""CITY"":""(.*?)"",""COUNTRY"":""(.*?)""");         //naslov faxa
            naslov = naslovZadetki.Groups[1].Value;
            postnaSt = naslovZadetki.Groups[2].Value;
            mesto2 = naslovZadetki.Groups[3].Value;
            drzava = naslovZadetki.Groups[4].Value;    //večina faxov tega nima tk da je opcionalno

            Match telefaxZadetki = Regex.Match(celotnaHTMLvsebina, @"""TEL1"":""(.*?)"",""FAX"":""(.*?)""");         //telefonska in fax
            telefon = telefaxZadetki.Groups[1].Value;
            fax = telefaxZadetki.Groups[2].Value;

            Match mailZadetki = Regex.Match(celotnaHTMLvsebina, @"""EMAIL"":""(.*?)"",""URL"":""(.*?)""");         //mail in spletna stran
            mail = mailZadetki.Groups[1].Value;                                              //escape characterji so not ponucaj eno funkcijo da se jih odstrani, bi mogla bit knjižnica za to
            splet = mailZadetki.Groups[2].Value;


            Match zaposleni = Regex.Match(celotnaHTMLvsebina, @"""EMPLOY"":.*?""GROUPS");                           // string zaposleni
            string zaposleniBulk = zaposleni.Value;

            MatchCollection zaposleniZadetki = Regex.Matches(zaposleniBulk, @"LNAME"":""(.*?)"",""FNAME"":""(.*?)""");    //priimki in imena zaposlenih

            foreach(Match item in zaposleniZadetki)
            {
                imenapriimki.Add(item.Groups[1] + " " + item.Groups[2]);
            }

            Match skupinesjaaline = Regex.Match(celotnaHTMLvsebina, @"GROUPS");                           // pogleda če so skupine
            if (skupinesjaaline.Success)
            {
                Match projektiajne = Regex.Match(celotnaHTMLvsebina, @"PROJECTS");                           // pogleda če so projekti
                if (projektiajne.Success)
                {
                    Match groupsBulk = Regex.Match(celotnaHTMLvsebina, @"""GROUPS.*?,""PROJECTS""");                           // dobi bulk najde idje in imena za skupine
                    string bulkGroup = groupsBulk.Value;

                    MatchCollection skupineZadetki = Regex.Matches(bulkGroup, @"""GRP_NAME"":""(.*?)"".*?GRPID"":""(.*?)""");

                    foreach(Match zadetek in skupineZadetki)
                    {
                        imenaskupin.Add(zadetek.Groups[1].Value);
                        idSkupin.Add(zadetek.Groups[2].Value);
                    }

                    ////////////////////////////////////////////////////////  
                    //////     PROJEKTI                             ////////
                    ////////////////////////////////////////////////////////

                    Match projektizadatak = Regex.Match(celotnaHTMLvsebina, @"PROJECTS"":.*?}]");
                    string projektiBulk = projektizadatak.Value;

                    MatchCollection projektiMatch = Regex.Matches(projektiBulk, @"TITLE"":""(.*?)"".*?PRJID"":""(.*?)""");

                    foreach(Match item in projektiMatch)
                    {
                        imenaProjektov.Add(item.Groups[1].Value);
                        IDProjektov.Add(item.Groups[2].Value);
                    }

                }
                else
                {
                    Match groupsBulk2 = Regex.Match(celotnaHTMLvsebina, @"""GROUPS.*?}]");                           // dobi bulk to je vse v primeru da faks nima projektov
                    string bulkGroup2 = groupsBulk2.Value;

                    MatchCollection skupineZadetki = Regex.Matches(bulkGroup2, @"""GRP_NAME"":""(.*?)"".*?GRPID"":""(.*?)""");

                    foreach (Match zadetek in skupineZadetki)
                    {
                        imenaskupin.Add(zadetek.Groups[1].Value);
                        idSkupin.Add(zadetek.Groups[2].Value);
                    }
                }
            }
            else
            {
                //čuj nimaš skupin
            }

            ///////////////////////////////////////
            //////////      PROGRAMI      /////////
            ///////////////////////////////////////

            Match ilijeProgram = Regex.Match(celotnaHTMLvsebina, @"PROGRAMS");
            if (ilijeProgram.Success)
            {
                Match programizadatak = Regex.Match(celotnaHTMLvsebina, @"PROGRAMS"":.*?}]");
                string programiBulk = programizadatak.Value;

                MatchCollection programiMatch = Regex.Matches(programiBulk, @"TITLE"":""(.*?)"".*?PRJID"":""(.*?)""");

                foreach (Match item in programiMatch)
                {
                    imenaProgramov.Add(item.Groups[1].Value);
                    idProgramov.Add(item.Groups[2].Value);
                }

            }
            else
            {
                //nema programa
            }


        }



        private void projektListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (projektiListView.SelectedItems.Count > 0)
                {
                    string urlZaProjekt = "http://www.sicris.si/Common/rest.aspx?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI_JSON&entity=prj&methodCall=id=" + IDProjektov[projektiListView.Items.IndexOf(projektiListView.SelectedItems[0])] + "%20and%20lang=slv";



                }
            }
        }

        private void programiListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (skupineListView.SelectedItems.Count > 0)
                {
                    string urlZaProgram = "http://www.sicris.si/Common/rest.aspx?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI_JSON&entity=prg&methodCall=id=" + idProgramov[programiListView.Items.IndexOf(programiListView.SelectedItems[0])] + "%20and%20lang=slv";



                }
            }
        }

        private void skupineListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (projektiListView.SelectedItems.Count > 0)
                {
                    string urlZaSkupine = "http://www.sicris.si/Common/rest.aspx?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI_JSON&entity=grp&methodCall=id=" + idSkupin[skupineListView.Items.IndexOf(skupineListView.SelectedItems[0])] + "%20and%20lang=slv";



                }
            }
        }

    }
}
