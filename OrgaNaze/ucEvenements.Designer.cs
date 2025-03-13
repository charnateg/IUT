namespace Saé
{
    partial class ucEvenements
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbcParcours = new System.Windows.Forms.TabControl();
            this.tpParcours = new System.Windows.Forms.TabPage();
            this.ptbDernier = new System.Windows.Forms.PictureBox();
            this.ptbPremier = new System.Windows.Forms.PictureBox();
            this.ptbPrecedant = new System.Windows.Forms.PictureBox();
            this.ptbSuivant = new System.Windows.Forms.PictureBox();
            this.tpNouvelEvenement = new System.Windows.Forms.TabPage();
            this.chkSolde = new System.Windows.Forms.CheckBox();
            this.btnNewEventValider = new System.Windows.Forms.Button();
            this.cboNewEventAuteur = new System.Windows.Forms.ComboBox();
            this.txtNewEventNomEvent = new System.Windows.Forms.TextBox();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.lblNewEventCreePar = new System.Windows.Forms.Label();
            this.lblNewEventDesc = new System.Windows.Forms.Label();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDeb = new System.Windows.Forms.DateTimePicker();
            this.lblNewEventDateFin = new System.Windows.Forms.Label();
            this.lblNewEventDateDeb = new System.Windows.Forms.Label();
            this.lblTitreEvent = new System.Windows.Forms.Label();
            this.tbcParcours.SuspendLayout();
            this.tpParcours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDernier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPremier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPrecedant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSuivant)).BeginInit();
            this.tpNouvelEvenement.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcParcours
            // 
            this.tbcParcours.AccessibleName = "";
            this.tbcParcours.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbcParcours.Controls.Add(this.tpParcours);
            this.tbcParcours.Controls.Add(this.tpNouvelEvenement);
            this.tbcParcours.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbcParcours.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcParcours.Location = new System.Drawing.Point(13, 21);
            this.tbcParcours.Name = "tbcParcours";
            this.tbcParcours.SelectedIndex = 0;
            this.tbcParcours.Size = new System.Drawing.Size(509, 440);
            this.tbcParcours.TabIndex = 1;
            this.tbcParcours.Tag = "";
            // 
            // tpParcours
            // 
            this.tpParcours.AllowDrop = true;
            this.tpParcours.Controls.Add(this.ptbDernier);
            this.tpParcours.Controls.Add(this.ptbPremier);
            this.tpParcours.Controls.Add(this.ptbPrecedant);
            this.tpParcours.Controls.Add(this.ptbSuivant);
            this.tpParcours.Location = new System.Drawing.Point(4, 37);
            this.tpParcours.Name = "tpParcours";
            this.tpParcours.Padding = new System.Windows.Forms.Padding(3);
            this.tpParcours.Size = new System.Drawing.Size(501, 399);
            this.tpParcours.TabIndex = 0;
            this.tpParcours.Text = "Parcours 1 à 1";
            this.tpParcours.UseVisualStyleBackColor = true;
            // 
            // ptbDernier
            // 
            this.ptbDernier.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ptbDernier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbDernier.Image = global::Saé.Properties.Resources.doubleFlecheDroite;
            this.ptbDernier.Location = new System.Drawing.Point(373, 344);
            this.ptbDernier.Name = "ptbDernier";
            this.ptbDernier.Size = new System.Drawing.Size(51, 43);
            this.ptbDernier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbDernier.TabIndex = 3;
            this.ptbDernier.TabStop = false;
            this.ptbDernier.Click += new System.EventHandler(this.ptbDernier_Click);
            // 
            // ptbPremier
            // 
            this.ptbPremier.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ptbPremier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPremier.Image = global::Saé.Properties.Resources.doubleFlecheGauche;
            this.ptbPremier.Location = new System.Drawing.Point(75, 344);
            this.ptbPremier.Name = "ptbPremier";
            this.ptbPremier.Size = new System.Drawing.Size(51, 43);
            this.ptbPremier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPremier.TabIndex = 2;
            this.ptbPremier.TabStop = false;
            this.ptbPremier.Click += new System.EventHandler(this.ptbPremier_Click);
            // 
            // ptbPrecedant
            // 
            this.ptbPrecedant.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ptbPrecedant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPrecedant.Image = global::Saé.Properties.Resources.FlecheGauche;
            this.ptbPrecedant.Location = new System.Drawing.Point(145, 344);
            this.ptbPrecedant.Name = "ptbPrecedant";
            this.ptbPrecedant.Size = new System.Drawing.Size(54, 43);
            this.ptbPrecedant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPrecedant.TabIndex = 1;
            this.ptbPrecedant.TabStop = false;
            this.ptbPrecedant.Click += new System.EventHandler(this.ptbPrecedant_Click);
            // 
            // ptbSuivant
            // 
            this.ptbSuivant.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ptbSuivant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbSuivant.Image = global::Saé.Properties.Resources.FlecheDroite;
            this.ptbSuivant.Location = new System.Drawing.Point(301, 344);
            this.ptbSuivant.Name = "ptbSuivant";
            this.ptbSuivant.Size = new System.Drawing.Size(54, 43);
            this.ptbSuivant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSuivant.TabIndex = 0;
            this.ptbSuivant.TabStop = false;
            this.ptbSuivant.Click += new System.EventHandler(this.ptbSuivant_Click);
            // 
            // tpNouvelEvenement
            // 
            this.tpNouvelEvenement.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpNouvelEvenement.Controls.Add(this.chkSolde);
            this.tpNouvelEvenement.Controls.Add(this.btnNewEventValider);
            this.tpNouvelEvenement.Controls.Add(this.cboNewEventAuteur);
            this.tpNouvelEvenement.Controls.Add(this.txtNewEventNomEvent);
            this.tpNouvelEvenement.Controls.Add(this.rtxtDescription);
            this.tpNouvelEvenement.Controls.Add(this.lblNewEventCreePar);
            this.tpNouvelEvenement.Controls.Add(this.lblNewEventDesc);
            this.tpNouvelEvenement.Controls.Add(this.dtpDateFin);
            this.tpNouvelEvenement.Controls.Add(this.dtpDateDeb);
            this.tpNouvelEvenement.Controls.Add(this.lblNewEventDateFin);
            this.tpNouvelEvenement.Controls.Add(this.lblNewEventDateDeb);
            this.tpNouvelEvenement.Controls.Add(this.lblTitreEvent);
            this.tpNouvelEvenement.ForeColor = System.Drawing.Color.Black;
            this.tpNouvelEvenement.Location = new System.Drawing.Point(4, 37);
            this.tpNouvelEvenement.Name = "tpNouvelEvenement";
            this.tpNouvelEvenement.Padding = new System.Windows.Forms.Padding(3);
            this.tpNouvelEvenement.Size = new System.Drawing.Size(501, 399);
            this.tpNouvelEvenement.TabIndex = 1;
            this.tpNouvelEvenement.Text = "Nouvel Evénement";
            // 
            // chkSolde
            // 
            this.chkSolde.AutoSize = true;
            this.chkSolde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSolde.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.chkSolde.Location = new System.Drawing.Point(358, 161);
            this.chkSolde.Margin = new System.Windows.Forms.Padding(2);
            this.chkSolde.Name = "chkSolde";
            this.chkSolde.Size = new System.Drawing.Size(105, 28);
            this.chkSolde.TabIndex = 11;
            this.chkSolde.Text = "soldeON";
            this.chkSolde.UseVisualStyleBackColor = true;
            // 
            // btnNewEventValider
            // 
            this.btnNewEventValider.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnNewEventValider.FlatAppearance.BorderSize = 0;
            this.btnNewEventValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEventValider.Location = new System.Drawing.Point(309, 338);
            this.btnNewEventValider.Name = "btnNewEventValider";
            this.btnNewEventValider.Size = new System.Drawing.Size(157, 48);
            this.btnNewEventValider.TabIndex = 10;
            this.btnNewEventValider.Text = "Enregistrer";
            this.btnNewEventValider.UseVisualStyleBackColor = false;
            this.btnNewEventValider.Click += new System.EventHandler(this.btnNewEventValider_Click);
            // 
            // cboNewEventAuteur
            // 
            this.cboNewEventAuteur.FormattingEnabled = true;
            this.cboNewEventAuteur.Location = new System.Drawing.Point(120, 293);
            this.cboNewEventAuteur.Name = "cboNewEventAuteur";
            this.cboNewEventAuteur.Size = new System.Drawing.Size(346, 33);
            this.cboNewEventAuteur.TabIndex = 9;
            // 
            // txtNewEventNomEvent
            // 
            this.txtNewEventNomEvent.Location = new System.Drawing.Point(236, 19);
            this.txtNewEventNomEvent.Name = "txtNewEventNomEvent";
            this.txtNewEventNomEvent.Size = new System.Drawing.Size(246, 33);
            this.txtNewEventNomEvent.TabIndex = 8;
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Location = new System.Drawing.Point(24, 187);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(442, 91);
            this.rtxtDescription.TabIndex = 6;
            this.rtxtDescription.Text = "";
            // 
            // lblNewEventCreePar
            // 
            this.lblNewEventCreePar.AutoSize = true;
            this.lblNewEventCreePar.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblNewEventCreePar.Location = new System.Drawing.Point(20, 298);
            this.lblNewEventCreePar.Name = "lblNewEventCreePar";
            this.lblNewEventCreePar.Size = new System.Drawing.Size(94, 24);
            this.lblNewEventCreePar.TabIndex = 7;
            this.lblNewEventCreePar.Text = "Créé Par :";
            // 
            // lblNewEventDesc
            // 
            this.lblNewEventDesc.AutoSize = true;
            this.lblNewEventDesc.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblNewEventDesc.Location = new System.Drawing.Point(20, 158);
            this.lblNewEventDesc.Name = "lblNewEventDesc";
            this.lblNewEventDesc.Size = new System.Drawing.Size(122, 24);
            this.lblNewEventDesc.TabIndex = 5;
            this.lblNewEventDesc.Text = "Description :";
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Location = new System.Drawing.Point(266, 103);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(200, 33);
            this.dtpDateFin.TabIndex = 4;
            // 
            // dtpDateDeb
            // 
            this.dtpDateDeb.Location = new System.Drawing.Point(24, 103);
            this.dtpDateDeb.Name = "dtpDateDeb";
            this.dtpDateDeb.Size = new System.Drawing.Size(200, 33);
            this.dtpDateDeb.TabIndex = 3;
            // 
            // lblNewEventDateFin
            // 
            this.lblNewEventDateFin.AutoSize = true;
            this.lblNewEventDateFin.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblNewEventDateFin.Location = new System.Drawing.Point(262, 72);
            this.lblNewEventDateFin.Name = "lblNewEventDateFin";
            this.lblNewEventDateFin.Size = new System.Drawing.Size(89, 24);
            this.lblNewEventDateFin.TabIndex = 2;
            this.lblNewEventDateFin.Text = "Date fin :";
            // 
            // lblNewEventDateDeb
            // 
            this.lblNewEventDateDeb.AutoSize = true;
            this.lblNewEventDateDeb.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblNewEventDateDeb.Location = new System.Drawing.Point(20, 72);
            this.lblNewEventDateDeb.Name = "lblNewEventDateDeb";
            this.lblNewEventDateDeb.Size = new System.Drawing.Size(120, 24);
            this.lblNewEventDateDeb.TabIndex = 1;
            this.lblNewEventDateDeb.Text = "Date début :";
            // 
            // lblTitreEvent
            // 
            this.lblTitreEvent.AutoSize = true;
            this.lblTitreEvent.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblTitreEvent.Location = new System.Drawing.Point(20, 23);
            this.lblTitreEvent.Name = "lblTitreEvent";
            this.lblTitreEvent.Size = new System.Drawing.Size(210, 24);
            this.lblTitreEvent.TabIndex = 0;
            this.lblTitreEvent.Text = "Nom de l\'événement :";
            // 
            // ucEvenements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcParcours);
            this.Name = "ucEvenements";
            this.Size = new System.Drawing.Size(535, 476);
            this.Load += new System.EventHandler(this.ucEvenements_Load);
            this.tbcParcours.ResumeLayout(false);
            this.tpParcours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbDernier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPremier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPrecedant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSuivant)).EndInit();
            this.tpNouvelEvenement.ResumeLayout(false);
            this.tpNouvelEvenement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcParcours;
        private System.Windows.Forms.TabPage tpParcours;
        private System.Windows.Forms.PictureBox ptbDernier;
        private System.Windows.Forms.PictureBox ptbPremier;
        private System.Windows.Forms.PictureBox ptbPrecedant;
        private System.Windows.Forms.PictureBox ptbSuivant;
        private System.Windows.Forms.TabPage tpNouvelEvenement;
        private System.Windows.Forms.Button btnNewEventValider;
        private System.Windows.Forms.ComboBox cboNewEventAuteur;
        private System.Windows.Forms.TextBox txtNewEventNomEvent;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Label lblNewEventCreePar;
        private System.Windows.Forms.Label lblNewEventDesc;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.DateTimePicker dtpDateDeb;
        private System.Windows.Forms.Label lblNewEventDateFin;
        private System.Windows.Forms.Label lblNewEventDateDeb;
        private System.Windows.Forms.Label lblTitreEvent;
        private System.Windows.Forms.CheckBox chkSolde;
    }
}
