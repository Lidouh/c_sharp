using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace DemClient
{
    public partial class FormConnect : Form
    {
        private static String adresseIP ;
        private int port;
        TcpClient client = new TcpClient();
        NetworkStream stream;
        Joueur j1;
        Thread tAttenteJ2;
        Thread t1, t2, t3;
        bool stopAttenteJ2 = true;
        public bool attenteJ2 = false;
        Object verrou = new Object();
        delegate void DelHide();
        delegate void DelDispose();
        delegate void DelSetStatusStrip(String str);
        delegate void DelMessageBox();  //car sinon la MessageBox n'est pas modale

        public FormConnect()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (pseudoTextBox.Text != "")
            {
                OkButton.Enabled = false;
                pseudoTextBox.Enabled = false;
                adresseIPTextBox.Enabled = false;
                portTextBox.Enabled = false;
                tAttenteJ2 = new Thread(threadAttenteJ2);
                t1 = new Thread(threadStatusStrip1);
                t2 = new Thread(threadStatusStrip2);
                t3 = new Thread(threadStatusStrip3);
                tAttenteJ2.IsBackground = true;
                t1.IsBackground = true;
                t2.IsBackground = true;
                t3.IsBackground = true;
                tAttenteJ2.Start();
                stopAttenteJ2 = false;
                t1.Start();
                t2.Start();
                t3.Start();
                Cursor = Cursors.WaitCursor;
            }
            else {
                MessageBox.Show("Veuillez entrer un pseudo.", "Attention");
            }
        }

        private void threadForm1()   // non utilisé
        {
            Joueur j1 = new Joueur(pseudoTextBox.Text, adresseIPTextBox.Text, Convert.ToInt32(portTextBox.Text));
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormJeu(j1));
        }

        private void clientConnect(Joueur j)
        {
            port = j.getPort();
            adresseIP = j.getAdreseIP();
            IPAddress serverAddress = IPAddress.Parse(adresseIP);
            client.Connect(serverAddress, port);
        }

        private void threadAttenteJ2()
        {
            try
            {
                j1 = new Joueur(pseudoTextBox.Text, adresseIPTextBox.Text, Convert.ToInt32(portTextBox.Text));
                FormJeu jeu = new FormJeu(j1);
                stopAttenteJ2 = true;
                this.Invoke(new DelHide(Hide));
                jeu.ShowDialog();  //Le démarrage d'une deuxième boucle de messages sur un seul thread n'est pas une opération valide. Utilisez Form.ShowDialog à la place.
                jeu.Dispose();  //car sinon n'a pas l'occasion de faire stream.Write
                this.Invoke(new DelDispose(Dispose));
            }
            catch
            {
                this.Invoke(new DelMessageBox(serveurHS));
                stopAttenteJ2 = true;
                this.Invoke(new DelDispose(Dispose));
            } //car si on ouvre un client sans serveur, erreur à client.Connect
        }

        private void serveurHS()
        {
            MessageBox.Show("Le serveur est HS ou l'adresse IP/port sont invalides.", "Erreur");
        }

        private void SetStatusStrip(string str)
        {
            toolStripStatusLabel.Text = str;
            statusStrip.Refresh();
        }

        private void threadStatusStrip1()
        {
            while (!stopAttenteJ2)
            {
                lock (verrou)
                {
                    try
                    {
                        this.Invoke(new DelSetStatusStrip(SetStatusStrip), "En attente d'un joueur.");
                    }
                    catch { }
                    Thread.Sleep(500);
                }
            }
        }

        private void threadStatusStrip2()
        {
            Thread.Sleep(100);
            while (!stopAttenteJ2)
            {
                lock (verrou)
                {
                    try
                    {
                        this.Invoke(new DelSetStatusStrip(SetStatusStrip), "En attente d'un joueur..");
                    }catch{ }
                    Thread.Sleep(500);
                }
            }
        }

        private void threadStatusStrip3()
        {
            Thread.Sleep(200);
            while (!stopAttenteJ2)
            {
                lock (verrou)
                {
                    try{
                    this.Invoke(new DelSetStatusStrip(SetStatusStrip), "En attente d'un joueur...");
                    }
                    catch { }
                    Thread.Sleep(500);
                }
            }
        }


    }
}
