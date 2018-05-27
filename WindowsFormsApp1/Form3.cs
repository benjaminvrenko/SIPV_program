using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //    napolniSeznamFakultet();
            }
        }

        private void napolniSeznamFakultet()
        {
            string sicrisURL = "http://www.sicris.si/Common/rest.aspx?sessionID=1234CRIS12002B01B01A03IZUMBFICDOSKJHS588Nn44131&fields=&country=SI_JSON&entity=org&methodCall=id=" + fakultetaID + "%20and%20lang=slv";

            string celotnaHTMLvsebina = null;

            System.Net.WebClient client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            celotnaHTMLvsebina = client.DownloadString(sicrisURL);
        }


    }
}
