﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

using System.IO;

namespace DemServer
{
    class Program
    {
        //méthode qui ecrit dans un tableau de byte en fonction de l'index.
        public static byte[] SetBit( byte[] self, int index, bool value)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;
            byte mask = (byte)(1 << bitIndex);

            self[byteIndex] = (byte)(value ? (self[byteIndex] | mask) : (self[byteIndex] & ~mask));
            return self;
        }

        //méthode qui lit et retourne le bit correspondant à l'index .
        public static bool GetBit(byte[] self, int index)
        {
            int byteIndex = index / 8;
            int bitIndex = index % 8;
            byte mask = (byte)(1 << bitIndex);

            return (self[byteIndex] & mask) != 0;
        }

        private static byte[] ToByteArray(object o)  //byte[] b = ToByteArray(Obj)
        {
            var stream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, o);
            return stream.ToArray();
        }       


        /// Procédure de création du damier
        private static byte[] creerDamier()
        {
            int nombreDeMines = 40, largeur = 16, longueur=16;
            //Enfin on pose les mines...
            Random r = new Random();
            int nbMinesPosees = 0;
            int rand = 0;
            byte[] tabBytes = new byte [32] ; // car 8*32 = 256 bits = 16*16


            while (nbMinesPosees < nombreDeMines)
            {
               
                rand = r.Next(0, largeur * longueur);
                //listeDesEmplacements contient une liste d'objet de type Button, dont le tag est vide ou minée


                if (!GetBit(tabBytes,rand))
                {
                    SetBit(tabBytes, rand, true);
                    nbMinesPosees++;
                }
            }

            return tabBytes;
        }


        static void Main(string[] args)
        {
            
            try {
                
                IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //use local m/c IP address, and use the same in the client
                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8003);
                /* Start Listeneting at the specified port */
                myList.Start();
                Console.WriteLine("The server is running at port 8003...");
                Console.WriteLine("The local End point is :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                //Socket s = myList.AcceptSocket();
                    TcpClient cl1 = myList.AcceptTcpClient();
                    Console.WriteLine("First client connected.....");
                    TcpClient cl2 = myList.AcceptTcpClient();
                    Console.WriteLine("Second client connected.....");
                    NetworkStream stm1 = cl1.GetStream();
                    NetworkStream stm2 = cl2.GetStream();

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

                    byte[] rcvBytesTour = new byte[1];
                    byte[] rcvBytesClick = new byte[1024];

                    while (true)
                    {
                        stm1.Read(rcvBytesClick, 0, rcvBytesClick.Length);
                        stm1.Read(rcvBytesTour, 0, rcvBytesTour.Length);
                        Console.WriteLine("Le 1e client a joué");

                        while (rcvBytesTour[0] == 0)
                        {
                            stm2.Write(rcvBytesClick, 0, rcvBytesClick.Length);
                            stm2.Write(rcvBytesTour, 0, rcvBytesTour.Length);
                            Console.WriteLine("Le 2e client est encore en attente");
                            stm1.Read(rcvBytesClick, 0, rcvBytesClick.Length);
                            stm1.Read(rcvBytesTour, 0, rcvBytesTour.Length);
                            Console.WriteLine("Le 1e client a joué");
                        }
                        stm2.Write(rcvBytesClick, 0, rcvBytesClick.Length);
                        stm2.Write(rcvBytesTour, 0, rcvBytesTour.Length);
                        Console.WriteLine("C'est au tour du 2e");

                        stm2.Read(rcvBytesClick, 0, rcvBytesClick.Length);
                        stm2.Read(rcvBytesTour, 0, rcvBytesTour.Length);
                        Console.WriteLine("Le 2e client a joué");

                        while (rcvBytesTour[0] == 0)
                        {
                            stm1.Write(rcvBytesClick, 0, rcvBytesClick.Length);
                            stm1.Write(rcvBytesTour, 0, rcvBytesTour.Length);
                            Console.WriteLine("Le 1e client est encore en attente");
                            stm2.Read(rcvBytesClick, 0, rcvBytesClick.Length);
                            stm2.Read(rcvBytesTour, 0, rcvBytesTour.Length);
                            Console.WriteLine("Le 2e client a joué");
                        }

                        stm1.Write(rcvBytesClick, 0, rcvBytesClick.Length);
                        stm1.Write(rcvBytesTour, 0, rcvBytesTour.Length);
                        Console.WriteLine("C'est au tour du 1e");

                    };
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            } 
        }
    }
}