namespace DemClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.grillePanel = new System.Windows.Forms.Panel();
            this.joueur2Panel = new System.Windows.Forms.Panel();
            this.J2label = new System.Windows.Forms.Label();
            this.nbMinesJ2TextBox = new System.Windows.Forms.TextBox();
            this.joueur1Panel = new System.Windows.Forms.Panel();
            this.J1label = new System.Windows.Forms.Label();
            this.nbMinesJ1TextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.partieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abandonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_nbMinesRestantes = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.joueur2Panel.SuspendLayout();
            this.joueur1Panel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillePanel
            // 
            this.grillePanel.Location = new System.Drawing.Point(193, 29);
            this.grillePanel.Name = "grillePanel";
            this.grillePanel.Size = new System.Drawing.Size(320, 320);
            this.grillePanel.TabIndex = 0;
            // 
            // joueur2Panel
            // 
            this.joueur2Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.joueur2Panel.Controls.Add(this.J2label);
            this.joueur2Panel.Controls.Add(this.nbMinesJ2TextBox);
            this.joueur2Panel.Location = new System.Drawing.Point(12, 29);
            this.joueur2Panel.Name = "joueur2Panel";
            this.joueur2Panel.Size = new System.Drawing.Size(160, 120);
            this.joueur2Panel.TabIndex = 1;
            // 
            // J2label
            // 
            this.J2label.AutoSize = true;
            this.J2label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.J2label.ForeColor = System.Drawing.Color.Red;
            this.J2label.Location = new System.Drawing.Point(25, 14);
            this.J2label.Name = "J2label";
            this.J2label.Size = new System.Drawing.Size(96, 25);
            this.J2label.TabIndex = 5;
            this.J2label.Text = "Joueur 2";
            // 
            // nbMinesJ2TextBox
            // 
            this.nbMinesJ2TextBox.BackColor = System.Drawing.Color.Red;
            this.nbMinesJ2TextBox.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbMinesJ2TextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nbMinesJ2TextBox.Location = new System.Drawing.Point(55, 53);
            this.nbMinesJ2TextBox.Name = "nbMinesJ2TextBox";
            this.nbMinesJ2TextBox.Size = new System.Drawing.Size(39, 37);
            this.nbMinesJ2TextBox.TabIndex = 4;
            this.nbMinesJ2TextBox.Text = "0";
            this.nbMinesJ2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // joueur1Panel
            // 
            this.joueur1Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.joueur1Panel.Controls.Add(this.J1label);
            this.joueur1Panel.Controls.Add(this.nbMinesJ1TextBox);
            this.joueur1Panel.Location = new System.Drawing.Point(12, 229);
            this.joueur1Panel.Name = "joueur1Panel";
            this.joueur1Panel.Size = new System.Drawing.Size(160, 120);
            this.joueur1Panel.TabIndex = 2;
            // 
            // J1label
            // 
            this.J1label.AutoSize = true;
            this.J1label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.J1label.ForeColor = System.Drawing.Color.MediumBlue;
            this.J1label.Location = new System.Drawing.Point(25, 17);
            this.J1label.Name = "J1label";
            this.J1label.Size = new System.Drawing.Size(96, 25);
            this.J1label.TabIndex = 0;
            this.J1label.Text = "Joueur 1";
            // 
            // nbMinesJ1TextBox
            // 
            this.nbMinesJ1TextBox.BackColor = System.Drawing.Color.MediumBlue;
            this.nbMinesJ1TextBox.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbMinesJ1TextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nbMinesJ1TextBox.Location = new System.Drawing.Point(55, 58);
            this.nbMinesJ1TextBox.Name = "nbMinesJ1TextBox";
            this.nbMinesJ1TextBox.Size = new System.Drawing.Size(39, 37);
            this.nbMinesJ1TextBox.TabIndex = 3;
            this.nbMinesJ1TextBox.Text = "0";
            this.nbMinesJ1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partieToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(530, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // partieToolStripMenuItem
            // 
            this.partieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abandonToolStripMenuItem});
            this.partieToolStripMenuItem.Name = "partieToolStripMenuItem";
            this.partieToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.partieToolStripMenuItem.Text = "Partie";
            // 
            // abandonToolStripMenuItem
            // 
            this.abandonToolStripMenuItem.Name = "abandonToolStripMenuItem";
            this.abandonToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.abandonToolStripMenuItem.Text = "Abandon";
            this.abandonToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aProposToolStripMenuItem.Text = "A propos";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // txt_nbMinesRestantes
            // 
            this.txt_nbMinesRestantes.BackColor = System.Drawing.Color.Black;
            this.txt_nbMinesRestantes.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nbMinesRestantes.ForeColor = System.Drawing.Color.White;
            this.txt_nbMinesRestantes.Location = new System.Drawing.Point(68, 170);
            this.txt_nbMinesRestantes.Name = "txt_nbMinesRestantes";
            this.txt_nbMinesRestantes.Size = new System.Drawing.Size(39, 37);
            this.txt_nbMinesRestantes.TabIndex = 4;
            this.txt_nbMinesRestantes.Text = "40";
            this.txt_nbMinesRestantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 369);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(530, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(27, 17);
            this.toolStripStatusLabel.Text = "Etat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 391);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txt_nbMinesRestantes);
            this.Controls.Add(this.joueur1Panel);
            this.Controls.Add(this.joueur2Panel);
            this.Controls.Add(this.grillePanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mon Démineur";
            this.joueur2Panel.ResumeLayout(false);
            this.joueur2Panel.PerformLayout();
            this.joueur1Panel.ResumeLayout(false);
            this.joueur1Panel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel grillePanel;
        private System.Windows.Forms.Panel joueur2Panel;
        private System.Windows.Forms.Panel joueur1Panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem partieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abandonToolStripMenuItem;
        private System.Windows.Forms.TextBox nbMinesJ1TextBox;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_nbMinesRestantes;
        private System.Windows.Forms.TextBox nbMinesJ2TextBox;
        private System.Windows.Forms.Label J2label;
        private System.Windows.Forms.Label J1label;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

