namespace Saé
{
    partial class ucAjouterDepense
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
            this.grpDepense = new System.Windows.Forms.GroupBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.clbBeneficiaires = new System.Windows.Forms.CheckedListBox();
            this.ckbBeneficiares = new System.Windows.Forms.CheckBox();
            this.dtpQuand = new System.Windows.Forms.DateTimePicker();
            this.rtxtCommentaire = new System.Windows.Forms.RichTextBox();
            this.txtCombien = new System.Windows.Forms.TextBox();
            this.txtQuoi = new System.Windows.Forms.TextBox();
            this.cboPayePar = new System.Windows.Forms.ComboBox();
            this.cboEvenement = new System.Windows.Forms.ComboBox();
            this.lblBeneficiaires = new System.Windows.Forms.Label();
            this.lblQuand = new System.Windows.Forms.Label();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.lblPayePar = new System.Windows.Forms.Label();
            this.lblCombien = new System.Windows.Forms.Label();
            this.lblQuoi = new System.Windows.Forms.Label();
            this.lblEvenement = new System.Windows.Forms.Label();
            this.grpDepense.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDepense
            // 
            this.grpDepense.Controls.Add(this.btnAnnuler);
            this.grpDepense.Controls.Add(this.btnValider);
            this.grpDepense.Controls.Add(this.clbBeneficiaires);
            this.grpDepense.Controls.Add(this.ckbBeneficiares);
            this.grpDepense.Controls.Add(this.dtpQuand);
            this.grpDepense.Controls.Add(this.rtxtCommentaire);
            this.grpDepense.Controls.Add(this.txtCombien);
            this.grpDepense.Controls.Add(this.txtQuoi);
            this.grpDepense.Controls.Add(this.cboPayePar);
            this.grpDepense.Controls.Add(this.cboEvenement);
            this.grpDepense.Controls.Add(this.lblBeneficiaires);
            this.grpDepense.Controls.Add(this.lblQuand);
            this.grpDepense.Controls.Add(this.lblCommentaire);
            this.grpDepense.Controls.Add(this.lblPayePar);
            this.grpDepense.Controls.Add(this.lblCombien);
            this.grpDepense.Controls.Add(this.lblQuoi);
            this.grpDepense.Controls.Add(this.lblEvenement);
            this.grpDepense.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDepense.ForeColor = System.Drawing.Color.White;
            this.grpDepense.Location = new System.Drawing.Point(9, 0);
            this.grpDepense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDepense.Name = "grpDepense";
            this.grpDepense.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDepense.Size = new System.Drawing.Size(613, 293);
            this.grpDepense.TabIndex = 8;
            this.grpDepense.TabStop = false;
            this.grpDepense.Text = "Nouvelle Dépense";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.Black;
            this.btnAnnuler.Location = new System.Drawing.Point(371, 241);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(110, 36);
            this.btnAnnuler.TabIndex = 16;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.ForeColor = System.Drawing.Color.Black;
            this.btnValider.Location = new System.Drawing.Point(487, 241);
            this.btnValider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(110, 36);
            this.btnValider.TabIndex = 15;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // clbBeneficiaires
            // 
            this.clbBeneficiaires.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbBeneficiaires.FormattingEnabled = true;
            this.clbBeneficiaires.Location = new System.Drawing.Point(314, 70);
            this.clbBeneficiaires.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbBeneficiaires.Name = "clbBeneficiaires";
            this.clbBeneficiaires.Size = new System.Drawing.Size(282, 64);
            this.clbBeneficiaires.TabIndex = 14;
            // 
            // ckbBeneficiares
            // 
            this.ckbBeneficiares.AutoSize = true;
            this.ckbBeneficiares.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbBeneficiares.Location = new System.Drawing.Point(447, 39);
            this.ckbBeneficiares.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ckbBeneficiares.Name = "ckbBeneficiares";
            this.ckbBeneficiares.Size = new System.Drawing.Size(148, 27);
            this.ckbBeneficiares.TabIndex = 13;
            this.ckbBeneficiares.Text = "Tout le monde";
            this.ckbBeneficiares.UseVisualStyleBackColor = true;
            this.ckbBeneficiares.CheckedChanged += new System.EventHandler(this.ckbBeneficiares_CheckedChanged);
            // 
            // dtpQuand
            // 
            this.dtpQuand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpQuand.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpQuand.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpQuand.Location = new System.Drawing.Point(142, 204);
            this.dtpQuand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpQuand.Name = "dtpQuand";
            this.dtpQuand.Size = new System.Drawing.Size(146, 33);
            this.dtpQuand.TabIndex = 1;
            // 
            // rtxtCommentaire
            // 
            this.rtxtCommentaire.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCommentaire.Location = new System.Drawing.Point(314, 165);
            this.rtxtCommentaire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtCommentaire.Name = "rtxtCommentaire";
            this.rtxtCommentaire.Size = new System.Drawing.Size(282, 65);
            this.rtxtCommentaire.TabIndex = 12;
            this.rtxtCommentaire.Text = "";
            // 
            // txtCombien
            // 
            this.txtCombien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCombien.Location = new System.Drawing.Point(142, 122);
            this.txtCombien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCombien.Name = "txtCombien";
            this.txtCombien.Size = new System.Drawing.Size(146, 26);
            this.txtCombien.TabIndex = 10;
            // 
            // txtQuoi
            // 
            this.txtQuoi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuoi.Location = new System.Drawing.Point(142, 81);
            this.txtQuoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuoi.Name = "txtQuoi";
            this.txtQuoi.Size = new System.Drawing.Size(146, 26);
            this.txtQuoi.TabIndex = 9;
            // 
            // cboPayePar
            // 
            this.cboPayePar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPayePar.FormattingEnabled = true;
            this.cboPayePar.Location = new System.Drawing.Point(142, 163);
            this.cboPayePar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboPayePar.Name = "cboPayePar";
            this.cboPayePar.Size = new System.Drawing.Size(146, 26);
            this.cboPayePar.TabIndex = 8;
            // 
            // cboEvenement
            // 
            this.cboEvenement.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEvenement.FormattingEnabled = true;
            this.cboEvenement.Location = new System.Drawing.Point(142, 42);
            this.cboEvenement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboEvenement.Name = "cboEvenement";
            this.cboEvenement.Size = new System.Drawing.Size(146, 26);
            this.cboEvenement.TabIndex = 7;
            this.cboEvenement.SelectedIndexChanged += new System.EventHandler(this.cboEvenement_SelectedIndexChanged);
            // 
            // lblBeneficiaires
            // 
            this.lblBeneficiaires.AutoSize = true;
            this.lblBeneficiaires.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaires.Location = new System.Drawing.Point(310, 39);
            this.lblBeneficiaires.Name = "lblBeneficiaires";
            this.lblBeneficiaires.Size = new System.Drawing.Size(132, 24);
            this.lblBeneficiaires.TabIndex = 6;
            this.lblBeneficiaires.Text = "Bénéficiaires :";
            // 
            // lblQuand
            // 
            this.lblQuand.AutoSize = true;
            this.lblQuand.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuand.Location = new System.Drawing.Point(16, 210);
            this.lblQuand.Name = "lblQuand";
            this.lblQuand.Size = new System.Drawing.Size(61, 24);
            this.lblQuand.TabIndex = 5;
            this.lblQuand.Text = "Date :";
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.AutoSize = true;
            this.lblCommentaire.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentaire.Location = new System.Drawing.Point(310, 139);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(143, 24);
            this.lblCommentaire.TabIndex = 4;
            this.lblCommentaire.Text = "Commentaire :";
            // 
            // lblPayePar
            // 
            this.lblPayePar.AutoSize = true;
            this.lblPayePar.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayePar.Location = new System.Drawing.Point(15, 163);
            this.lblPayePar.Name = "lblPayePar";
            this.lblPayePar.Size = new System.Drawing.Size(101, 24);
            this.lblPayePar.TabIndex = 3;
            this.lblPayePar.Text = "Acheteur :";
            // 
            // lblCombien
            // 
            this.lblCombien.AutoSize = true;
            this.lblCombien.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombien.Location = new System.Drawing.Point(14, 122);
            this.lblCombien.Name = "lblCombien";
            this.lblCombien.Size = new System.Drawing.Size(124, 24);
            this.lblCombien.TabIndex = 2;
            this.lblCombien.Text = "Prix (euros) : ";
            // 
            // lblQuoi
            // 
            this.lblQuoi.AutoSize = true;
            this.lblQuoi.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuoi.Location = new System.Drawing.Point(16, 82);
            this.lblQuoi.Name = "lblQuoi";
            this.lblQuoi.Size = new System.Drawing.Size(70, 24);
            this.lblQuoi.TabIndex = 1;
            this.lblQuoi.Text = "Achat :";
            // 
            // lblEvenement
            // 
            this.lblEvenement.AutoSize = true;
            this.lblEvenement.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvenement.Location = new System.Drawing.Point(15, 43);
            this.lblEvenement.Name = "lblEvenement";
            this.lblEvenement.Size = new System.Drawing.Size(121, 24);
            this.lblEvenement.TabIndex = 0;
            this.lblEvenement.Text = "Evénement :";
            // 
            // ucAjouterDepense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpDepense);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucAjouterDepense";
            this.Size = new System.Drawing.Size(633, 302);
            this.Load += new System.EventHandler(this.ucAjouterDepense_Load);
            this.grpDepense.ResumeLayout(false);
            this.grpDepense.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDepense;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.CheckedListBox clbBeneficiaires;
        private System.Windows.Forms.CheckBox ckbBeneficiares;
        private System.Windows.Forms.DateTimePicker dtpQuand;
        private System.Windows.Forms.RichTextBox rtxtCommentaire;
        private System.Windows.Forms.TextBox txtCombien;
        private System.Windows.Forms.TextBox txtQuoi;
        private System.Windows.Forms.ComboBox cboPayePar;
        private System.Windows.Forms.ComboBox cboEvenement;
        private System.Windows.Forms.Label lblBeneficiaires;
        private System.Windows.Forms.Label lblQuand;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.Label lblPayePar;
        private System.Windows.Forms.Label lblCombien;
        private System.Windows.Forms.Label lblQuoi;
        private System.Windows.Forms.Label lblEvenement;
    }
}
