namespace Saé
{
    partial class ucParticipants
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
            this.tbParticipant = new System.Windows.Forms.TabControl();
            this.tpPartEvent = new System.Windows.Forms.TabPage();
            this.cboEvent = new System.Windows.Forms.ComboBox();
            this.dgvParticipants = new System.Windows.Forms.DataGridView();
            this.btnAjoutInvite = new System.Windows.Forms.Button();
            this.grpInviter = new System.Windows.Forms.GroupBox();
            this.btnInviter = new System.Windows.Forms.Button();
            this.cboInvite = new System.Windows.Forms.ComboBox();
            this.lblQuelParticipant = new System.Windows.Forms.Label();
            this.lblEnregistres = new System.Windows.Forms.Label();
            this.lblNomEvent = new System.Windows.Forms.Label();
            this.tpAjoutUtil = new System.Windows.Forms.TabPage();
            this.txtNbParts = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblNbParts = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.btnAjoutUser = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.tbParticipant.SuspendLayout();
            this.tpPartEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).BeginInit();
            this.grpInviter.SuspendLayout();
            this.tpAjoutUtil.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbParticipant
            // 
            this.tbParticipant.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbParticipant.Controls.Add(this.tpPartEvent);
            this.tbParticipant.Controls.Add(this.tpAjoutUtil);
            this.tbParticipant.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbParticipant.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.tbParticipant.Location = new System.Drawing.Point(24, 19);
            this.tbParticipant.Name = "tbParticipant";
            this.tbParticipant.SelectedIndex = 0;
            this.tbParticipant.Size = new System.Drawing.Size(593, 518);
            this.tbParticipant.TabIndex = 1;
            // 
            // tpPartEvent
            // 
            this.tpPartEvent.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpPartEvent.Controls.Add(this.cboEvent);
            this.tpPartEvent.Controls.Add(this.dgvParticipants);
            this.tpPartEvent.Controls.Add(this.btnAjoutInvite);
            this.tpPartEvent.Controls.Add(this.grpInviter);
            this.tpPartEvent.Controls.Add(this.lblEnregistres);
            this.tpPartEvent.Controls.Add(this.lblNomEvent);
            this.tpPartEvent.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.tpPartEvent.Location = new System.Drawing.Point(4, 36);
            this.tpPartEvent.Name = "tpPartEvent";
            this.tpPartEvent.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpPartEvent.Size = new System.Drawing.Size(585, 478);
            this.tpPartEvent.TabIndex = 0;
            this.tpPartEvent.Text = "Particpants";
            // 
            // cboEvent
            // 
            this.cboEvent.ForeColor = System.Drawing.Color.Black;
            this.cboEvent.FormattingEnabled = true;
            this.cboEvent.Location = new System.Drawing.Point(256, 21);
            this.cboEvent.Name = "cboEvent";
            this.cboEvent.Size = new System.Drawing.Size(280, 32);
            this.cboEvent.TabIndex = 12;
            this.cboEvent.SelectedIndexChanged += new System.EventHandler(this.cboEvent_SelectedIndexChanged);
            // 
            // dgvParticipants
            // 
            this.dgvParticipants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParticipants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipants.Location = new System.Drawing.Point(44, 96);
            this.dgvParticipants.Name = "dgvParticipants";
            this.dgvParticipants.RowHeadersWidth = 51;
            this.dgvParticipants.RowTemplate.Height = 24;
            this.dgvParticipants.Size = new System.Drawing.Size(492, 155);
            this.dgvParticipants.TabIndex = 11;
            // 
            // btnAjoutInvite
            // 
            this.btnAjoutInvite.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAjoutInvite.FlatAppearance.BorderSize = 0;
            this.btnAjoutInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutInvite.ForeColor = System.Drawing.Color.Black;
            this.btnAjoutInvite.Location = new System.Drawing.Point(324, 260);
            this.btnAjoutInvite.Name = "btnAjoutInvite";
            this.btnAjoutInvite.Size = new System.Drawing.Size(212, 46);
            this.btnAjoutInvite.TabIndex = 10;
            this.btnAjoutInvite.Text = "Ajouter un invité";
            this.btnAjoutInvite.UseVisualStyleBackColor = false;
            this.btnAjoutInvite.Click += new System.EventHandler(this.btnAjoutInvite_Click);
            // 
            // grpInviter
            // 
            this.grpInviter.Controls.Add(this.btnInviter);
            this.grpInviter.Controls.Add(this.cboInvite);
            this.grpInviter.Controls.Add(this.lblQuelParticipant);
            this.grpInviter.ForeColor = System.Drawing.Color.Black;
            this.grpInviter.Location = new System.Drawing.Point(9, 309);
            this.grpInviter.Name = "grpInviter";
            this.grpInviter.Size = new System.Drawing.Size(558, 126);
            this.grpInviter.TabIndex = 9;
            this.grpInviter.TabStop = false;
            this.grpInviter.Visible = false;
            // 
            // btnInviter
            // 
            this.btnInviter.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnInviter.FlatAppearance.BorderSize = 0;
            this.btnInviter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInviter.Location = new System.Drawing.Point(378, 73);
            this.btnInviter.Name = "btnInviter";
            this.btnInviter.Size = new System.Drawing.Size(152, 44);
            this.btnInviter.TabIndex = 4;
            this.btnInviter.Text = "Inviter";
            this.btnInviter.UseVisualStyleBackColor = false;
            this.btnInviter.Click += new System.EventHandler(this.btnInviter_Click);
            // 
            // cboInvite
            // 
            this.cboInvite.FormattingEnabled = true;
            this.cboInvite.Location = new System.Drawing.Point(250, 28);
            this.cboInvite.Name = "cboInvite";
            this.cboInvite.Size = new System.Drawing.Size(280, 32);
            this.cboInvite.TabIndex = 3;
            // 
            // lblQuelParticipant
            // 
            this.lblQuelParticipant.AutoSize = true;
            this.lblQuelParticipant.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblQuelParticipant.Location = new System.Drawing.Point(34, 31);
            this.lblQuelParticipant.Name = "lblQuelParticipant";
            this.lblQuelParticipant.Size = new System.Drawing.Size(194, 24);
            this.lblQuelParticipant.TabIndex = 2;
            this.lblQuelParticipant.Text = "Nom du participant :";
            // 
            // lblEnregistres
            // 
            this.lblEnregistres.AutoSize = true;
            this.lblEnregistres.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblEnregistres.ForeColor = System.Drawing.Color.Black;
            this.lblEnregistres.Location = new System.Drawing.Point(40, 69);
            this.lblEnregistres.Name = "lblEnregistres";
            this.lblEnregistres.Size = new System.Drawing.Size(229, 24);
            this.lblEnregistres.TabIndex = 8;
            this.lblEnregistres.Text = "Participants enregistrés :";
            // 
            // lblNomEvent
            // 
            this.lblNomEvent.AutoSize = true;
            this.lblNomEvent.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.lblNomEvent.ForeColor = System.Drawing.Color.Black;
            this.lblNomEvent.Location = new System.Drawing.Point(40, 24);
            this.lblNomEvent.Name = "lblNomEvent";
            this.lblNomEvent.Size = new System.Drawing.Size(210, 24);
            this.lblNomEvent.TabIndex = 7;
            this.lblNomEvent.Text = "Nom de l\'événement :";
            // 
            // tpAjoutUtil
            // 
            this.tpAjoutUtil.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpAjoutUtil.Controls.Add(this.txtNbParts);
            this.tpAjoutUtil.Controls.Add(this.lblMail);
            this.tpAjoutUtil.Controls.Add(this.lblNbParts);
            this.tpAjoutUtil.Controls.Add(this.lblMobile);
            this.tpAjoutUtil.Controls.Add(this.lblPrenom);
            this.tpAjoutUtil.Controls.Add(this.lblNom);
            this.tpAjoutUtil.Controls.Add(this.btnAjoutUser);
            this.tpAjoutUtil.Controls.Add(this.txtMail);
            this.tpAjoutUtil.Controls.Add(this.txtMobile);
            this.tpAjoutUtil.Controls.Add(this.txtPrenom);
            this.tpAjoutUtil.Controls.Add(this.txtNom);
            this.tpAjoutUtil.Location = new System.Drawing.Point(4, 36);
            this.tpAjoutUtil.Name = "tpAjoutUtil";
            this.tpAjoutUtil.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpAjoutUtil.Size = new System.Drawing.Size(585, 478);
            this.tpAjoutUtil.TabIndex = 1;
            this.tpAjoutUtil.Text = "Ajout utilisateur";
            // 
            // txtNbParts
            // 
            this.txtNbParts.ForeColor = System.Drawing.Color.Black;
            this.txtNbParts.Location = new System.Drawing.Point(338, 286);
            this.txtNbParts.Name = "txtNbParts";
            this.txtNbParts.Size = new System.Drawing.Size(138, 32);
            this.txtNbParts.TabIndex = 11;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.ForeColor = System.Drawing.Color.Black;
            this.lblMail.Location = new System.Drawing.Point(101, 175);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(80, 24);
            this.lblMail.TabIndex = 10;
            this.lblMail.Text = "- Email :";
            // 
            // lblNbParts
            // 
            this.lblNbParts.AutoSize = true;
            this.lblNbParts.ForeColor = System.Drawing.Color.Black;
            this.lblNbParts.Location = new System.Drawing.Point(101, 289);
            this.lblNbParts.Name = "lblNbParts";
            this.lblNbParts.Size = new System.Drawing.Size(185, 24);
            this.lblNbParts.TabIndex = 9;
            this.lblNbParts.Text = "- Nombre de parts :";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.ForeColor = System.Drawing.Color.Black;
            this.lblMobile.Location = new System.Drawing.Point(101, 232);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(95, 24);
            this.lblMobile.TabIndex = 8;
            this.lblMobile.Text = "- Mobile :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.ForeColor = System.Drawing.Color.Black;
            this.lblPrenom.Location = new System.Drawing.Point(101, 118);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(103, 24);
            this.lblPrenom.TabIndex = 7;
            this.lblPrenom.Text = "- Prénom :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.ForeColor = System.Drawing.Color.Black;
            this.lblNom.Location = new System.Drawing.Point(101, 60);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(77, 24);
            this.lblNom.TabIndex = 6;
            this.lblNom.Text = "- Nom :";
            // 
            // btnAjoutUser
            // 
            this.btnAjoutUser.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAjoutUser.FlatAppearance.BorderSize = 0;
            this.btnAjoutUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjoutUser.ForeColor = System.Drawing.Color.Black;
            this.btnAjoutUser.Location = new System.Drawing.Point(308, 356);
            this.btnAjoutUser.Name = "btnAjoutUser";
            this.btnAjoutUser.Size = new System.Drawing.Size(168, 63);
            this.btnAjoutUser.TabIndex = 5;
            this.btnAjoutUser.Text = "Ajouter un utilisateur";
            this.btnAjoutUser.UseVisualStyleBackColor = false;
            this.btnAjoutUser.Click += new System.EventHandler(this.btnAjoutUser_Click);
            // 
            // txtMail
            // 
            this.txtMail.ForeColor = System.Drawing.Color.Black;
            this.txtMail.Location = new System.Drawing.Point(231, 172);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(245, 32);
            this.txtMail.TabIndex = 4;
            // 
            // txtMobile
            // 
            this.txtMobile.ForeColor = System.Drawing.Color.Black;
            this.txtMobile.Location = new System.Drawing.Point(231, 229);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(245, 32);
            this.txtMobile.TabIndex = 2;
            // 
            // txtPrenom
            // 
            this.txtPrenom.ForeColor = System.Drawing.Color.Black;
            this.txtPrenom.Location = new System.Drawing.Point(231, 115);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(245, 32);
            this.txtPrenom.TabIndex = 1;
            // 
            // txtNom
            // 
            this.txtNom.ForeColor = System.Drawing.Color.Black;
            this.txtNom.Location = new System.Drawing.Point(231, 57);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(245, 32);
            this.txtNom.TabIndex = 0;
            // 
            // ucParticipants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbParticipant);
            this.Name = "ucParticipants";
            this.Size = new System.Drawing.Size(640, 546);
            this.Load += new System.EventHandler(this.ucParticipants_Load);
            this.tbParticipant.ResumeLayout(false);
            this.tpPartEvent.ResumeLayout(false);
            this.tpPartEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).EndInit();
            this.grpInviter.ResumeLayout(false);
            this.grpInviter.PerformLayout();
            this.tpAjoutUtil.ResumeLayout(false);
            this.tpAjoutUtil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbParticipant;
        private System.Windows.Forms.TabPage tpPartEvent;
        private System.Windows.Forms.ComboBox cboEvent;
        private System.Windows.Forms.DataGridView dgvParticipants;
        private System.Windows.Forms.Button btnAjoutInvite;
        private System.Windows.Forms.GroupBox grpInviter;
        private System.Windows.Forms.Button btnInviter;
        private System.Windows.Forms.ComboBox cboInvite;
        private System.Windows.Forms.Label lblQuelParticipant;
        private System.Windows.Forms.Label lblEnregistres;
        private System.Windows.Forms.Label lblNomEvent;
        private System.Windows.Forms.TabPage tpAjoutUtil;
        private System.Windows.Forms.TextBox txtNbParts;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblNbParts;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Button btnAjoutUser;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
    }
}
