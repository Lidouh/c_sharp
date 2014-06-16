namespace DemClient
{
    partial class FormConnect
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
            if (!stopAttenteJ2)
            {
                clientConnect(j1);
            }

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
            this.adresseIPLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.pseudoLabel = new System.Windows.Forms.Label();
            this.adresseIPTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.pseudoTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // adresseIPLabel
            // 
            this.adresseIPLabel.AutoSize = true;
            this.adresseIPLabel.Location = new System.Drawing.Point(57, 61);
            this.adresseIPLabel.Name = "adresseIPLabel";
            this.adresseIPLabel.Size = new System.Drawing.Size(58, 13);
            this.adresseIPLabel.TabIndex = 0;
            this.adresseIPLabel.Text = "Adresse IP";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(57, 118);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port";
            // 
            // pseudoLabel
            // 
            this.pseudoLabel.AutoSize = true;
            this.pseudoLabel.Location = new System.Drawing.Point(57, 178);
            this.pseudoLabel.Name = "pseudoLabel";
            this.pseudoLabel.Size = new System.Drawing.Size(43, 13);
            this.pseudoLabel.TabIndex = 2;
            this.pseudoLabel.Text = "Pseudo";
            // 
            // adresseIPTextBox
            // 
            this.adresseIPTextBox.Location = new System.Drawing.Point(159, 61);
            this.adresseIPTextBox.Name = "adresseIPTextBox";
            this.adresseIPTextBox.Size = new System.Drawing.Size(155, 20);
            this.adresseIPTextBox.TabIndex = 3;
            this.adresseIPTextBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(159, 118);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(155, 20);
            this.portTextBox.TabIndex = 4;
            this.portTextBox.Text = "8003";
            // 
            // pseudoTextBox
            // 
            this.pseudoTextBox.Location = new System.Drawing.Point(159, 171);
            this.pseudoTextBox.Name = "pseudoTextBox";
            this.pseudoTextBox.Size = new System.Drawing.Size(155, 20);
            this.pseudoTextBox.TabIndex = 5;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(110, 225);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(136, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 316);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(347, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(93, 17);
            this.toolStripStatusLabel.Text = "Connectez-vous";
            // 
            // FormConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 338);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.pseudoTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.adresseIPTextBox);
            this.Controls.Add(this.pseudoLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.adresseIPLabel);
            this.Name = "FormConnect";
            this.Text = "Connexion";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label adresseIPLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label pseudoLabel;
        private System.Windows.Forms.TextBox adresseIPTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox pseudoTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}