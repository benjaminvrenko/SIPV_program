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
    public partial class Form3 : Form
    {
        private string fakultetaID = null;
        List<List<string>> vsiPodatkiFakultete = new List<List<string>>();

        public Form3(string ID)
        {
            InitializeComponent();

            fakultetaID = ID;

            if (fakultetaID == null)
            {
                MessageBox.Show("Napaka! ID fakultete ni bil pridobljen.");
            }
            else
            {
                napolniSeznamFakultet();
            }
        }

        private void napolniSeznamFakultet()
        {
            string sicrisURL = "http://www.sicris.si/Common/rest.aspx?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI_JSON&entity=org&methodCall=id=" + fakultetaID + "%20and%20lang=slv";

            string celotnaHTMLvsebina = null;

            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            celotnaHTMLvsebina = client.DownloadString(sicrisURL);

            Match IDZadetki = Regex.Match(celotnaHTMLvsebina, @"""MSTID"":""(\d*)?");         //ID faxa
            string IDFAxa = IDZadetki.Groups[1].Value;

            Match imeZadetki = Regex.Match(celotnaHTMLvsebina, @"""NAME"":""(.*?)""");          //ime faxa
            string imeFaxa = imeZadetki.Groups[1].Value;

            Match mestoZadetki = Regex.Match(celotnaHTMLvsebina, @"""CITY"":""(.*?)""");          //mesto kjer se nahaja
            string mesto = mestoZadetki.Groups[1].Value;

            Match dekanZadetki = Regex.Match(celotnaHTMLvsebina, @"""DIR_LNAME"":""(.*?)"",""DIR_FNAME"":""(.*?)""");         //ime in priimek dekana
            string priimekDekana = dekanZadetki.Groups[1].Value;
            string imeDekana=dekanZadetki.Groups[2].Value;

            Match dekanNaziviZadetki = Regex.Match(celotnaHTMLvsebina, @"""DIRFUN"":""(.*?)"",""DIRTTLPRE"":""(.*?)""");         //nazivi dekana
            string naziv1 = dekanNaziviZadetki.Groups[1].Value;
            string naziv2 = dekanNaziviZadetki.Groups[2].Value;

            Match naslovZadetki = Regex.Match(celotnaHTMLvsebina, @"""ADDR1"":""(.*?)"",""POSTALCODE"":""(.*?)"",""CITY"":""(.*?)"",""COUNTRY"":""(.*?)""");         //naslov faxa
            string naslov = naslovZadetki.Groups[1].Value;
            string postnaSt = naslovZadetki.Groups[2].Value;
            string mesto2 = naslovZadetki.Groups[3].Value;
            string drzava = naslovZadetki.Groups[4].Value;                      //večina faxov tega nima tk da je opcionalno

            Match telefaxZadetki = Regex.Match(celotnaHTMLvsebina, @"""TEL1"":""(.*?)"",""FAX"":""(.*?)""");         //telefonska in fax
            string telefon = telefaxZadetki.Groups[1].Value;
            string fax = telefaxZadetki.Groups[2].Value;

            Match mailZadetki = Regex.Match(celotnaHTMLvsebina, @"""EMAIL"":""(.*?),""URL"":""(.*?)""");         //mail in spletna stran
            string mail = mailZadetki.Groups[1].Value;                                              //escape characterji so not ponucaj eno funkcijo da se jih odstrani, bi mogla bit knjižnica za to
            string splet = mailZadetki.Groups[2].Value;


            Match zaposleni = Regex.Match(celotnaHTMLvsebina, @"""EMPLOY"":.*?""GROUPS");                           // string zaposleni
            string zaposleniBulk = zaposleni.Value;

            MatchCollection zaposleniZadetki = Regex.Matches(zaposleniBulk, @"LNAME"":""(.*?)"",""FNAME"":""(.*?)""");    //priimki in imena zaposlenih
            List<string> imenapriimki = new List<string>();
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
                    List<string> imenaskupin = new List<string>();
                    List<string> idskupin = new List<string>();
                    foreach(Match zadetek in skupineZadetki)
                    {
                        imenaskupin.Add(zadetek.Groups[1].Value);
                        idskupin.Add(zadetek.Groups[2].Value);
                    }

                    ////////////////////////////////////////////////////////  
                    //////     PROJEKTI                             ////////
                    ////////////////////////////////////////////////////////

                    Match projektizadatak = Regex.Match(celotnaHTMLvsebina, @"PROJECTS"":.*?}]");
                    string projektiBulk = projektizadatak.Value;

                    MatchCollection projektiMatch = Regex.Matches(projektiBulk, @"TITLE"":""(.*?)"".*?PRJID"":""(.*?)""");
                    List<string> imenaProjektov = new List<string>();
                    List<string> IDProjektov = new List<string>();
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
                    List<string> imenaskupin = new List<string>();
                    List<string> idskupin = new List<string>();
                    foreach (Match zadetek in skupineZadetki)
                    {
                        imenaskupin.Add(zadetek.Groups[1].Value);
                        idskupin.Add(zadetek.Groups[2].Value);
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
                List<string> imenaProgramov = new List<string>();
                List<string> IDProgramov = new List<string>();
                foreach (Match item in programiMatch)
                {
                    imenaProgramov.Add(item.Groups[1].Value);
                    IDProgramov.Add(item.Groups[2].Value);
                }

            }
            else
            {
                //nema programa
            }


        }

        private void projektProgramListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (projektiListView.SelectedItems.Count > 0)
                {
                    //TBA 


                }



            }
        }

        private void seznamSkupinListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                if (projektiListView.SelectedItems.Count > 0)
                {
                    //TBA
                }



            }
        }

    }
}
