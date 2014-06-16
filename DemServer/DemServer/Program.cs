using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

using System.IO;

namespace DemServer
{
    class Program
    {
        //Méthode qui ecrit dans un tableau de byte en fonction de l'index.
        public static byte[] SetBit(byte[] self, int index, bool value)
        {
            /*
             * index = position du bit au sein du tableau self (entre 0 et 8*self.length-1)
             * byteIndex = position du byte dans lequel se trouve le bit (entre 0 et self.length-1)
             * bitIndex = position du bit au sein du byte (entre 0 et 8)
             */
            int byteIndex = index / 8;
            int bitIndex = index % 8;
            byte mask = (byte)(1 << bitIndex);  //1 est décalé vers la gauche de bitIndex
            self[byteIndex] = (byte)(value ? (self[byteIndex] | mask) : (self[byteIndex] & ~mask));
            /*
             * si value = true alors seul (self[byteIndex] | mask) est évalué
             * si value = false alors seul (self[byteIndex] & ~mask) est évalué
             * ~mask signifie qu'on prend le complément à 1 de mask, cad qu'on inverse tous ses bits
             */
            return self;
        }

        //Méthode qui lit et retourne le bit correspondant à l'index .
        public static bool GetBit(byte[] self, int index)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;
            byte mask = (byte)(1 << bitIndex);
            return (self[byteIndex] & mask) != 0;
        }

        private static byte[] ToByteArray(object o)  //byte[] b = ToByteArray(Obj)   //non utilisé
        {
            var stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, o);
            return stream.ToArray();
        }


        /// Procédure de création du damier
        private static byte[] creerDamier()
        {
            int nombreDeMines = 40, largeur = 16, longueur = 16;
            //Enfin on pose les mines...
            Random r = new Random();
            int nbMinesPosees = 0;
            int rand = 0;
            byte[] tabBytes = new byte[32]; // car 8*32 = 256 bits = 16*16
            while (nbMinesPosees < nombreDeMines)
            {
                rand = r.Next(0, largeur * longueur);  //largeur*longueur est non inclu dans la plage spécifiée
                //listeDesEmplacements contient une liste d'objet de type Button, dont le tag est vide ou minée
                if (!GetBit(tabBytes, rand))
                {
                    SetBit(tabBytes, rand, true);
                    nbMinesPosees++;
                }
            }
            return tabBytes;
        }

        private static void threadReadStm(TcpClient cl1, TcpClient cl2)
        {
            try
            {
                NetworkStream stm1 = cl1.GetStream();
                NetworkStream stm2 = cl2.GetStream();

                byte[] rcvBytesClick = new byte[2];

                while (stm1.Read(rcvBytesClick, 0, rcvBytesClick.Length) != 0)
                {
                    Console.WriteLine("{0} a cliqué --> {1}", cl1.Client.RemoteEndPoint, Thread.CurrentThread.Name);
                    stm2.Write(rcvBytesClick, 0, rcvBytesClick.Length);
                    stm2.Flush();
                    
                    if (rcvBytesClick[0] == 2)  //si l'un des clients a clické sur Rejouer
                    {
                        stm1.Write(rcvBytesClick, 0, rcvBytesClick.Length);  //pour qu'il initialise a travers son threadRead
                        byte[] tabBytes = new byte[32]; // car 8*32 = 256 bits = 16*16
                        tabBytes = creerDamier();

                        stm1.Write(tabBytes, 0, tabBytes.Length);
                        byte[] sndBytesTour = new byte[] { 255 };
                        stm1.Write(sndBytesTour, 0, sndBytesTour.Length);
                        stm1.Flush();

                        stm2.Write(tabBytes, 0, tabBytes.Length);
                        byte[] sndBytesAtt = new byte[] { 0 };
                        stm2.Write(sndBytesAtt, 0, sndBytesAtt.Length);
                        stm2.Flush();
                        Console.WriteLine("Nouvelle partie");
                    }
                }
                stm1.Close();
                cl1.Close();
                Console.WriteLine("{0} terminé", Thread.CurrentThread.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }

        }

        private static void threadReadStm2(TcpClient cl2, TcpClient cl1)   //non utilisé
        {
            NetworkStream stm2 = cl2.GetStream();
            NetworkStream stm1 = cl1.GetStream();

            byte[] rcvBytesTour = new byte[1];
            byte[] rcvBytesClick = new byte[4];

            try
            {
                while (stm2.Read(rcvBytesClick, 0, rcvBytesClick.Length) != 0)
                {
                    stm2.Read(rcvBytesTour, 0, rcvBytesTour.Length);
                    Console.WriteLine("Le 2e client a écrit");

                    stm1.Write(rcvBytesClick, 0, rcvBytesClick.Length);
                    stm1.Write(rcvBytesTour, 0, rcvBytesTour.Length);
                    Console.WriteLine("Le 1e client a lu");

                    if (rcvBytesTour[0] == 5)  //si l'un des clients a clické sur Rejouer
                    {
                        stm2.Write(rcvBytesClick, 0, rcvBytesClick.Length);
                        stm2.Write(rcvBytesTour, 0, rcvBytesTour.Length);
                        Console.WriteLine("Le 2e client a lu");
                        byte[] tabBytes = new byte[32]; // car 8*32 = 256 bits = 16*16
                        tabBytes = creerDamier();
                        stm2.Write(tabBytes, 0, tabBytes.Length);
                        byte[] sndBytesTour = new byte[] { 255 };
                        stm2.Write(sndBytesTour, 0, sndBytesTour.Length);
                        Console.WriteLine("C'est au tour du 2e client");
                        stm2.Flush();

                        stm1.Write(tabBytes, 0, tabBytes.Length);
                        byte[] sndBytesAtt = new byte[] { 0 };
                        stm1.Write(sndBytesAtt, 0, sndBytesAtt.Length);
                        Console.WriteLine("Le 1e client est en attente");
                        stm1.Flush();
                    }

                }
                stm2.Close();
                cl2.Close();
                Console.WriteLine("2e client fermé");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                //Console.ReadLine();
            }
        }


        static void Main(string[] args)
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //use local m/c IP address, and use the same in the client
                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8003);
                /* Start Listeneting at the specified port */
                myList.Start();
                Console.WriteLine("The server is running at port 8003...");
                Console.WriteLine("The local End point is :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                //Socket s = myList.AcceptSocket();
                while (true)
                {
                    try
                    {
                        TcpClient cl1 = myList.AcceptTcpClient();
                        Console.WriteLine("First client connected.....");
                        NetworkStream stm1 = cl1.GetStream();
                        byte[] rcvBytesPseudoJ1 = new byte[100];
                        stm1.Read(rcvBytesPseudoJ1, 0, rcvBytesPseudoJ1.Length);

                        TcpClient cl2 = myList.AcceptTcpClient();
                        Console.WriteLine("Second client connected.....");
                        NetworkStream stm2 = cl2.GetStream();
                        byte[] rcvBytesPseudoJ2 = new byte[100];
                        stm2.Read(rcvBytesPseudoJ2, 0, rcvBytesPseudoJ2.Length);

                        stm2.Write(rcvBytesPseudoJ1, 0, rcvBytesPseudoJ1.Length);
                        stm1.Write(rcvBytesPseudoJ2, 0, rcvBytesPseudoJ2.Length);
                        byte[] tabBytes = new byte[32]; // car 8*32 = 256 bits = 16*16
                        tabBytes = creerDamier();

                        stm1.Write(tabBytes, 0, tabBytes.Length);
                        byte[] sndBytesTour = new byte[] { 255 };
                        stm1.Write(sndBytesTour, 0, sndBytesTour.Length);
                        Console.WriteLine("C'est au tour du 1e client");
                        stm1.Flush();

                        stm2.Write(tabBytes, 0, tabBytes.Length);
                        byte[] sndBytesAtt = new byte[] { 0 };
                        stm2.Write(sndBytesAtt, 0, sndBytesAtt.Length);
                        Console.WriteLine("Le 2e client est en attente");
                        stm2.Flush();
                        /*
                         * un thread ne peut avoir qu'un seul paramètre au maximum
                         * pour plus de paramètres, on peut utiliser une méthode anonyme
                         * une méthode anonyme permet de passer un bloc de code en paramètre d'un délégué
                         * il n'est plus nécessaire d'instancier le délégué avec sa méthode nommée
                         */
                        Thread t1 = new Thread(delegate() { threadReadStm(cl1, cl2); });
                        t1.Name = "J1 to J2";
                        t1.Start();
                        Thread t2 = new Thread(delegate() { threadReadStm(cl2, cl1); });
                        t2.Name = "J2 to J1";
                        t2.Start();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error..... " + e.StackTrace);
                    }
                    //myList.Stop();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
