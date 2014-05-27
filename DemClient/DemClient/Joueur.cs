using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemClient
{
    public class Joueur
    {
        private String pseudo;
        private String adresseIP;
        private int port;

        public Joueur(String pseudo, String adresseIP, int port)
        {
            this.pseudo = pseudo;
            this.adresseIP = adresseIP;
            this.port = port;
        }

        public String getPseudo()
        {
            return this.pseudo;
        }

        public String getAdreseIP()
        {
            return this.adresseIP;
        }

        public int getPort()
        {
            return this.port;
        }

    }
}
