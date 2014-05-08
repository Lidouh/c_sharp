﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections; //pour la ArrayList

namespace DemClient
{
    public partial class Form1 : Form
    {
        /// Largeur des buttons servant à représenter les cases du damier
        const int LARGEUREMPLACEMENT = 20;

        /// Lettre pour représenter le drapeau
        const string CHARACTERTROUVE = "M";

        /// Largeur du damier, en nombre de case
        private int largeur;

        /// Longueur du damier, en nombre de case
        private int longueur;

        /// Nombre de mines
        private int nombreDeMines;

        /// Liste des emplacements, sa capacité est donc = longueur * largeur
        private ArrayList listeDesEmplacements;

        /// Nombre de mines que le joueur a trouvé
        private int nombreDeMinesTrouvees = 0;

        /// Etat de la partie (cf enumération 'etatPartie')
        private etatPartie etatCourant;

        

        public Form1()
        {
           
            InitializeComponent();

            //On lance la procédure qui initilialise un nouveau jeu
            initialise();
        }

        private void initialise() /// Initialise une nouvelle partie
        {
            //On positionne les différents paramètres
                    largeur = 16;
                    longueur = 16;
                    nombreDeMines = 40;

            //On nettoie la liste des emplacements
            if (listeDesEmplacements != null)
                listeDesEmplacements.Clear();

            listeDesEmplacements = new ArrayList(largeur * longueur);

            //On crée le damier
            creerDamier();
            nombreDeMinesTrouvees = 0;
            afficheMinesTrouvees();

            //La partie va commencer des que le joueur va cliquer sur une case...
            etatCourant = etatPartie.EnAttente;
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialise();
        }

        private void afficheMinesTrouvees()
        {
            nbMinesJ1TextBox.Text = Convert.ToString(nombreDeMinesTrouvees);
            txt_nbMinesRestantes.Text = Convert.ToString(nombreDeMines - nombreDeMinesTrouvees);
        }

        /// Procédure de création du damier
        private void creerDamier()
        {
            Button btn;
            grillePanel.Controls.Clear();

            //Boucle dans laquelle on crée tous les boutons qui vont nous permettre de représenter les cases
            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < longueur; j++)
                {
                    btn = new Button();
                    btn.Text = "";
                    btn.Size = new Size(LARGEUREMPLACEMENT, LARGEUREMPLACEMENT);
                    btn.Location = new Point(i * LARGEUREMPLACEMENT, j * LARGEUREMPLACEMENT);

                    //Le tag va nous servir à stocker le type de case: Est-ce une mine ou pas ?
                    //Lors de la création on les mets toutes comme vide, on placera les mines après
                    btn.Tag = typeEmplacement.Vide;

                    btn.Font = new Font(FontFamily.GenericSansSerif, (float)8, FontStyle.Bold);

                    //Abonnement aux évènements
                    btn.Click += new EventHandler(btn_Click);

                    //On ajoute le bouton crée à la liste des emplacements
                    listeDesEmplacements.Add(btn);
                    grillePanel.Controls.Add(btn);
                }
            }

            //On positionne correctement les différents éléments graphiques qui demandent à être repositionnés
            grillePanel.Size = new Size(largeur * LARGEUREMPLACEMENT, longueur * LARGEUREMPLACEMENT);

            //Enfin on pose les mines...
            Random r = new Random();
            int nbMinesPosees = 0;
            int rand = 0;
            while (nbMinesPosees < nombreDeMines)
            {
                rand = r.Next(0, largeur * longueur);
                //listeDesEmplacements contient une liste d'objet de type Button, dont le tag est vide ou minée
                if ((typeEmplacement)(((Button)listeDesEmplacements[rand]).Tag) == typeEmplacement.Vide)
                {
                    ((Button)listeDesEmplacements[rand]).Tag = typeEmplacement.Mine;
                    nbMinesPosees++;
                }
            }
        }

        private void victoire()
        {
            MessageBox.Show("Bravo, partie terminée.", "Fin");
        }

        void btn_Click(object sender, EventArgs e)
        {
            if (etatCourant == etatPartie.EnAttente)
            {
                etatCourant = etatPartie.EnCours;
            }
            Button btn = ((Button)sender);
            if (nombreDeMinesTrouvees < nombreDeMines && ((typeEmplacement)btn.Tag) == typeEmplacement.Mine)
            {
                btn.Text = CHARACTERTROUVE;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Blue;

                nombreDeMinesTrouvees++;
                afficheMinesTrouvees();

                if (nombreDeMinesTrouvees == nombreDeMines)
                {
                    victoire();
                }
                
            }
            else //Sinon il faut explorer les cases avoisinantes
            {
                RechercheRecursive(listeDesEmplacements.IndexOf(btn));
            }

        }

        /// Exploration récursive des cases du damier, index = numéro de la case de départ
        private void RechercheRecursive(int index)
        {

            int nombreDeMinesAutour = 0; //Nombre de mines autour de la case sélectionnée
            int temp = longueur - 1; //variable permettant de connaitre l'entier nécessaire pour calculer les positions des 8 autres cases dans un plan 2 dimensions.
            int resultat = 0;
            double reminder = 0;

            /*
             *   Exemple: longueur = 3, largeur = 4
             *     0 1 2 3 
             *     _ _ _ _ 
             *  0 |_|_|_|_|
             *  1 |_|_|_|_|
             *  2 |_|_|_|_|
             * 
             *  Chaque case est référencée dans la liste listDesEmplacements qui contient le handle de chaque objet de type Button
             *  Chaque Button est classé dans l'ordre de sa création, de 0 à (longueur * largeur -1)
             *  Les deux boucles de créations sont imbriquées de telle sorte qu'avec notre exemple on obtient le classement suivant:
             * 
             *     0 1 2 3 
             *     _ _ _ _ 
             *  0 |0|3|6|9|
             *  1 |1|4|7|10|
             *  2 |2|5|8|11|
             * 
             * Dans cet exemple, les cases qui entourent la case 4 sont:
             * Les trois au dessus: 0,3 et 6
             * Les trois en dessous: 2,5 et 8
             * Celle à gauche: 1
             * Celle à droite: 7
             * 
             * Donc si on veut connaitre les numéros des cases autours d'une case de numéro X, on obtient:
             * Les trois au dessus: X - ((longueur - 1) + 2), X - 1 et X + (longueur - 1)
             * Les trois en dessous: X - (longueur - 1), X + 1 et X + ((longueur - 1) + 2)
             * Celle à gauche: X - ((longueur-1) + 1)
             * Celle à droite: X + ((longueur-1) + 1)
             * 
             */


            //les 3 cases au dessus
            //on vérifie qu'on est pas sur la 1ère ligne du damier - Auquel cas on ne va pas vérifier les cases au dessus
            reminder = Math.IEEERemainder((index), longueur);
            if (
                 reminder != 0
                )
            {
                resultat = rechercheMinesAutour(index - 1);
                nombreDeMinesAutour += resultat;
                resultat = rechercheMinesAutour(index + temp);
                nombreDeMinesAutour += resultat;
                resultat = rechercheMinesAutour(index - (temp + 2));
                nombreDeMinesAutour += resultat;
            }

            //Celle de droite
            // on vérifie qu'on est pas sur la dernière colonne du damier
            if (index < (listeDesEmplacements.Count - longueur))
            {
                resultat = rechercheMinesAutour(index + temp + 1);
                nombreDeMinesAutour += resultat;
            }

            //Celle gauche
            // on vérifie qu'on est pas sur la première colonne du damier
            if (index >= longueur)
            {
                resultat = rechercheMinesAutour(index - (temp + 1));
                nombreDeMinesAutour += resultat;
            }

            //les 3 au dessous
            //on vérifie qu'on est pas sur la dernière ligne du damier - Auquel cas on ne va pas vérifier les cases en dessous
            reminder = Math.IEEERemainder((index + 1), longueur);
            if (
                 reminder != 0
                )
            {
                resultat = rechercheMinesAutour(index + 1);
                nombreDeMinesAutour += resultat;
                resultat = rechercheMinesAutour(index - temp);
                nombreDeMinesAutour += resultat;
                resultat = rechercheMinesAutour(index + (temp + 2));
                nombreDeMinesAutour += resultat;
            }

            //Si on a trouvé des mines autours alors on affiche le résultat dans la propriété Text de l'objet Button concerné
            if (nombreDeMinesAutour > 0)
            {
                ((Button)(listeDesEmplacements[index])).Text = nombreDeMinesAutour.ToString();
                switch (nombreDeMinesAutour)
                {
                    case 1:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.Blue;
                        break;
                    case 2:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.Green;
                        break;
                    case 3:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.Red;
                        break;
                    case 4:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.Violet;
                        break;
                    case 5:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.Maroon;
                        break;
                    case 6:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.Orange;
                        break;
                    case 7:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.Black;
                        break;
                    case 8:
                        ((Button)(listeDesEmplacements[index])).ForeColor = Color.White;
                        break;
                }
            }
            else
            { //Sinon alors la case n'a pas de mine autours et il faut donc explorer les cases autours...

                //Comme on n'affiche pas '0' sur la case pour dire que la case n'a pas de mine autours, 
                //on met un texte ' ' qui ne se voit pas mais qui nous permet de ne pas laisser la propriété Text à vide
                ((Button)(listeDesEmplacements[index])).Text = " ";
                ((Button)(listeDesEmplacements[index])).FlatStyle = FlatStyle.Flat;
                ((Button)(listeDesEmplacements[index])).BackColor = Color.Gainsboro;
                ((Button)(listeDesEmplacements[index])).Click -= new EventHandler(btn_Click);

                //les 3 au dessus
                //on vérifie qu'on est pas sur la 1ère ligne du damier
                reminder = Math.IEEERemainder((index), longueur);
                if (reminder != 0)
                {
                    investigation(index - 1);
                    investigation(index + temp);
                    investigation(index - (temp + 2));
                }

                //a droite
                // on vérifie qu'on est pas sur la dernière colonne du damier
                if (index < (listeDesEmplacements.Count - longueur))
                {
                    investigation(index + temp + 1);
                }

                //a gauche
                // on vérifie qu'on est pas sur la première colonne du damier
                if (index >= longueur)
                {
                    investigation(index - (temp + 1));
                }

                // les 3 au dessous
                //on vérifie qu'on est pas sur la dernière ligne du damier
                reminder = Math.IEEERemainder((index + 1), longueur);
                if (reminder != 0)
                {
                    investigation(index + 1);
                    investigation(index - temp);
                    investigation(index + (temp + 2));
                }

            }

        }

        /// Fonction permettant de savoir si la case concernée par l'index est une mine (renvoie 1) ou pas (renvoie 0)
        private int rechercheMinesAutour(int index)
        {
            Button btn2;
            int result = 0;
            if ((index >= 0) && (index < (longueur * largeur)))
            {
                btn2 = ((Button)listeDesEmplacements[index]);
                if (((typeEmplacement)btn2.Tag) == typeEmplacement.Mine)
                {
                    result = 1;
                }
            }

            return result;
        }

        /// Procédure permettant de produire une récursivité dans l'exploration des cases.
        /// Si le numéro envoyé en paramètre correspond à un emplacement valide
        /// alors la procédure lance une recherche récursive sur cette case
        private void investigation(int index)
        {
            Button btn2;

            if ((index >= 0) && (index < (longueur * largeur)))
            {
                btn2 = ((Button)listeDesEmplacements[index]);
                if (btn2.Text == "")
                {
                    RechercheRecursive(index);
                }
            }
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message;
            message = "Projet C#  :  Mon démineur" + (char)10;
            message += "Auteur      :  Lidouh Samia" + (char)10;
            message += "Source      :  http://codes-sources.commentcamarche.net/" + (char)10 + (char)10;
            MessageBox.Show(message, "A propos...");
        }



    }

    /// Enumération des type d'emplacements possibles
    public enum typeEmplacement { Vide, Mine };

    /// Enumération des différents états possibles pour une partie
    public enum etatPartie { EnCours, Perdue, EnAttente };
}