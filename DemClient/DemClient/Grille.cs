using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace DemClient
{
   

    }
    class Grille : Panel

    {

        
        private Button[,] grille = new Button[16, 16];


       public Grille() {
            Button btn;
            for (int i = 0; i < grille.Length; i++) {
                for (int j = 0; j < grille.Length; j++) {
                    btn = new Button();
                    btn.Text = "";
                    btn.Size = new Size(20, 20);
                    btn.Location = new Point(i * 20, j * 20);
                    Controls.Add(btn);
                    //grille[i, j] = null;
                }
            }
        }

       public Grille(List <Button> list){
            int cpt =0;
            for (int i = 0; i < grille.Length; i++)
            {
                for (int j = 0; j < grille.Length; j++)
                {
                    
                    grille[i, j] = list.ElementAt(cpt);
                    cpt++;
                }
            }
        
        }


        public void Add(Button but, int pos) {
            int ligne = pos / 16;
            int colonne = pos % 16; ;
            grille[ligne, colonne] = but;
        }
        
}
