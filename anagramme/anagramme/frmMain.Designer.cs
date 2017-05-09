namespace anagramme
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbxQuestion = new System.Windows.Forms.GroupBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblReponse = new System.Windows.Forms.Label();
            this.Réponse = new System.Windows.Forms.GroupBox();
            this.btnNouvellePartie = new System.Windows.Forms.Button();
            this.btnReponse = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gbxQuestion
            // 
            this.gbxQuestion.Location = new System.Drawing.Point(12, 108);
            this.gbxQuestion.Name = "gbxQuestion";
            this.gbxQuestion.Size = new System.Drawing.Size(1023, 118);
            this.gbxQuestion.TabIndex = 0;
            this.gbxQuestion.TabStop = false;
            this.gbxQuestion.Text = "Question";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(925, 92);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(76, 13);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Question N°: 0";
            // 
            // lblReponse
            // 
            this.lblReponse.AutoSize = true;
            this.lblReponse.Location = new System.Drawing.Point(861, 248);
            this.lblReponse.Name = "lblReponse";
            this.lblReponse.Size = new System.Drawing.Size(140, 13);
            this.lblReponse.TabIndex = 3;
            this.lblReponse.Text = "Nombre de réponse juste : 0";
            // 
            // Réponse
            // 
            this.Réponse.Location = new System.Drawing.Point(12, 264);
            this.Réponse.Name = "Réponse";
            this.Réponse.Size = new System.Drawing.Size(1023, 118);
            this.Réponse.TabIndex = 2;
            this.Réponse.TabStop = false;
            this.Réponse.Text = "Réponse";
            // 
            // btnNouvellePartie
            // 
            this.btnNouvellePartie.Location = new System.Drawing.Point(12, 403);
            this.btnNouvellePartie.Name = "btnNouvellePartie";
            this.btnNouvellePartie.Size = new System.Drawing.Size(186, 48);
            this.btnNouvellePartie.TabIndex = 4;
            this.btnNouvellePartie.Text = "Nouvelle partie";
            this.btnNouvellePartie.UseVisualStyleBackColor = true;
            this.btnNouvellePartie.Click += new System.EventHandler(this.btnNouvellePartie_Click);
            // 
            // btnReponse
            // 
            this.btnReponse.Location = new System.Drawing.Point(291, 403);
            this.btnReponse.Name = "btnReponse";
            this.btnReponse.Size = new System.Drawing.Size(186, 48);
            this.btnReponse.TabIndex = 5;
            this.btnReponse.Text = "Afficher la réponse";
            this.btnReponse.UseVisualStyleBackColor = true;
            this.btnReponse.Click += new System.EventHandler(this.btnReponse_Click);
            // 
            // btnSuivant
            // 
            this.btnSuivant.Location = new System.Drawing.Point(570, 403);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(186, 48);
            this.btnSuivant.TabIndex = 6;
            this.btnSuivant.Text = "Question suivante";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(849, 403);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(186, 48);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annule le dernier click";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Black;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(12, 31);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1023, 35);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Trouvez le mot caché et cliquez dans l\'ordre sur les lettres afin de le reconstit" +
    "uer\r\n";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 463);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.btnReponse);
            this.Controls.Add(this.btnNouvellePartie);
            this.Controls.Add(this.lblReponse);
            this.Controls.Add(this.Réponse);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.gbxQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Anagrammes";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxQuestion;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblReponse;
        private System.Windows.Forms.GroupBox Réponse;
        private System.Windows.Forms.Button btnNouvellePartie;
        private System.Windows.Forms.Button btnReponse;
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label lblInfo;
    }
}

