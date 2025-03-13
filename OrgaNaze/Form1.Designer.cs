namespace Saé
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.lblBilan = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.navBar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptbMenu = new System.Windows.Forms.PictureBox();
            this.lblMenu = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEvenements = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnParticipants = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDepenses = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnBilan = new System.Windows.Forms.Button();
            this.barNavTimer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pcbBienvenue = new System.Windows.Forms.PictureBox();
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.navBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBienvenue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBilan
            // 
            this.lblBilan.AutoSize = true;
            this.lblBilan.Location = new System.Drawing.Point(1262, 19);
            this.lblBilan.Name = "lblBilan";
            this.lblBilan.Size = new System.Drawing.Size(40, 18);
            this.lblBilan.TabIndex = 5;
            this.lblBilan.Text = "Bilan";
            // 
            // btnAjout
            // 
            this.btnAjout.BackColor = System.Drawing.Color.LightBlue;
            this.btnAjout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAjout.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout.ForeColor = System.Drawing.Color.Black;
            this.btnAjout.Location = new System.Drawing.Point(535, 338);
            this.btnAjout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(309, 77);
            this.btnAjout.TabIndex = 6;
            this.btnAjout.Text = "Ajouter une dépense";
            this.btnAjout.UseVisualStyleBackColor = false;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // navBar
            // 
            this.navBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.navBar.Controls.Add(this.panel1);
            this.navBar.Controls.Add(this.panel3);
            this.navBar.Controls.Add(this.panel4);
            this.navBar.Controls.Add(this.panel5);
            this.navBar.Controls.Add(this.panel6);
            this.navBar.Controls.Add(this.panel7);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navBar.MaximumSize = new System.Drawing.Size(350, 675);
            this.navBar.MinimumSize = new System.Drawing.Size(92, 675);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(248, 675);
            this.navBar.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ptbMenu);
            this.panel1.Controls.Add(this.lblMenu);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 100);
            this.panel1.TabIndex = 0;
            // 
            // ptbMenu
            // 
            this.ptbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbMenu.Image = global::Saé.Properties.Resources.Menu_icon_icon_icons1;
            this.ptbMenu.Location = new System.Drawing.Point(9, 8);
            this.ptbMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbMenu.Name = "ptbMenu";
            this.ptbMenu.Size = new System.Drawing.Size(80, 85);
            this.ptbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMenu.TabIndex = 10;
            this.ptbMenu.TabStop = false;
            this.ptbMenu.Click += new System.EventHandler(this.ptbMenu_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.White;
            this.lblMenu.Location = new System.Drawing.Point(95, 34);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(85, 37);
            this.lblMenu.TabIndex = 9;
            this.lblMenu.Text = "Menu";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 70);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAccueil);
            this.panel3.Location = new System.Drawing.Point(3, 106);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 82);
            this.panel3.TabIndex = 10;
            // 
            // btnAccueil
            // 
            this.btnAccueil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccueil.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.ForeColor = System.Drawing.Color.White;
            this.btnAccueil.Image = global::Saé.Properties.Resources.accueil__1__modified;
            this.btnAccueil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccueil.Location = new System.Drawing.Point(-15, -7);
            this.btnAccueil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnAccueil.Size = new System.Drawing.Size(259, 106);
            this.btnAccueil.TabIndex = 9;
            this.btnAccueil.Text = "          Accueil";
            this.btnAccueil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccueil.UseVisualStyleBackColor = true;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnEvenements);
            this.panel4.Location = new System.Drawing.Point(3, 192);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 78);
            this.panel4.TabIndex = 11;
            // 
            // btnEvenements
            // 
            this.btnEvenements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvenements.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvenements.ForeColor = System.Drawing.Color.White;
            this.btnEvenements.Image = global::Saé.Properties.Resources._2413035__1__modified;
            this.btnEvenements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvenements.Location = new System.Drawing.Point(-16, -12);
            this.btnEvenements.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEvenements.Name = "btnEvenements";
            this.btnEvenements.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnEvenements.Size = new System.Drawing.Size(273, 106);
            this.btnEvenements.TabIndex = 9;
            this.btnEvenements.Text = "          Evénements";
            this.btnEvenements.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvenements.UseVisualStyleBackColor = true;
            this.btnEvenements.Click += new System.EventHandler(this.btnEvenements_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnParticipants);
            this.panel5.Location = new System.Drawing.Point(3, 274);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(242, 84);
            this.panel5.TabIndex = 11;
            // 
            // btnParticipants
            // 
            this.btnParticipants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParticipants.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParticipants.ForeColor = System.Drawing.Color.White;
            this.btnParticipants.Image = global::Saé.Properties.Resources._1204035__1__modified;
            this.btnParticipants.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParticipants.Location = new System.Drawing.Point(-13, -11);
            this.btnParticipants.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnParticipants.Name = "btnParticipants";
            this.btnParticipants.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnParticipants.Size = new System.Drawing.Size(259, 106);
            this.btnParticipants.TabIndex = 9;
            this.btnParticipants.Text = "          Participants";
            this.btnParticipants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParticipants.UseVisualStyleBackColor = true;
            this.btnParticipants.Click += new System.EventHandler(this.btnParticipants_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnDepenses);
            this.panel6.Location = new System.Drawing.Point(3, 362);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(245, 84);
            this.panel6.TabIndex = 11;
            // 
            // btnDepenses
            // 
            this.btnDepenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepenses.Font = new System.Drawing.Font("Nirmala UI", 18F);
            this.btnDepenses.ForeColor = System.Drawing.Color.White;
            this.btnDepenses.Image = global::Saé.Properties.Resources._1___1__modified;
            this.btnDepenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepenses.Location = new System.Drawing.Point(-13, -18);
            this.btnDepenses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDepenses.Name = "btnDepenses";
            this.btnDepenses.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnDepenses.Size = new System.Drawing.Size(259, 106);
            this.btnDepenses.TabIndex = 9;
            this.btnDepenses.Text = "          Dépenses";
            this.btnDepenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepenses.UseVisualStyleBackColor = true;
            this.btnDepenses.Click += new System.EventHandler(this.btnDepenses_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnBilan);
            this.panel7.Location = new System.Drawing.Point(3, 450);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(242, 79);
            this.panel7.TabIndex = 11;
            // 
            // btnBilan
            // 
            this.btnBilan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilan.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilan.ForeColor = System.Drawing.Color.White;
            this.btnBilan.Image = global::Saé.Properties.Resources.bilan_icone_modified__1_;
            this.btnBilan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilan.Location = new System.Drawing.Point(-8, -21);
            this.btnBilan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBilan.Name = "btnBilan";
            this.btnBilan.Padding = new System.Windows.Forms.Padding(32, 0, 0, 0);
            this.btnBilan.Size = new System.Drawing.Size(259, 106);
            this.btnBilan.TabIndex = 9;
            this.btnBilan.Text = "          Bilan";
            this.btnBilan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilan.UseVisualStyleBackColor = true;
            this.btnBilan.Click += new System.EventHandler(this.btnBilan_Click);
            // 
            // barNavTimer
            // 
            this.barNavTimer.Interval = 10;
            this.barNavTimer.Tick += new System.EventHandler(this.barNavTimer_Tick);
            // 
            // pcbBienvenue
            // 
            this.pcbBienvenue.BackColor = System.Drawing.Color.Transparent;
            this.pcbBienvenue.Image = global::Saé.Properties.Resources.bienvenue;
            this.pcbBienvenue.Location = new System.Drawing.Point(451, 36);
            this.pcbBienvenue.Name = "pcbBienvenue";
            this.pcbBienvenue.Size = new System.Drawing.Size(481, 163);
            this.pcbBienvenue.TabIndex = 9;
            this.pcbBienvenue.TabStop = false;
            // 
            // lblBienvenue
            // 
            this.lblBienvenue.AutoSize = true;
            this.lblBienvenue.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenue.Font = new System.Drawing.Font("MV Boli", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenue.ForeColor = System.Drawing.Color.White;
            this.lblBienvenue.Location = new System.Drawing.Point(520, 184);
            this.lblBienvenue.Name = "lblBienvenue";
            this.lblBienvenue.Size = new System.Drawing.Size(326, 63);
            this.lblBienvenue.TabIndex = 10;
            this.lblBienvenue.Text = "sur OrgaNaze";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Location = new System.Drawing.Point(288, 250);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(797, 370);
            this.pnlMenu.TabIndex = 11;
            this.pnlMenu.Visible = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.BackgroundImage = global::Saé.Properties.Resources.Fond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1173, 674);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblBienvenue);
            this.Controls.Add(this.pcbBienvenue);
            this.Controls.Add(this.navBar);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.lblBilan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrgaNaze";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.navBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbBienvenue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBilan;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.FlowLayoutPanel navBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccueil;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEvenements;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnParticipants;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnDepenses;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnBilan;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Timer barNavTimer;
        private System.Windows.Forms.PictureBox ptbMenu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pcbBienvenue;
        private System.Windows.Forms.Label lblBienvenue;
        private System.Windows.Forms.Panel pnlMenu;
    }
}

