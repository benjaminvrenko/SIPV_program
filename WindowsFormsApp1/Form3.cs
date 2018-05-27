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
            string mail = mailZadetki.Groups[1].Value;
            string splet = mailZadetki.Groups[2].Value;
        }


    }
}
