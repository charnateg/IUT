namespace Saé
{
    partial class ucBilan
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
            this.tbBilan = new System.Windows.Forms.TabControl();
            this.tpSolde = new System.Windows.Forms.TabPage();
            this.btnBilan = new System.Windows.Forms.Button();
            this.cboEventSolde = new System.Windows.Forms.ComboBox();
            this.dgvSolde = new System.Windows.Forms.DataGridView();
            this.tbBilan.SuspendLayout();
            this.tpSolde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolde)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBilan
            // 
            this.tbBilan.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbBilan.Controls.Add(this.tpSolde);
            this.tbBilan.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbBilan.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.tbBilan.Location = new System.Drawing.Point(0, 0);
            this.tbBilan.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.tbBilan.Name = "tbBilan";
            this.tbBilan.SelectedIndex = 0;
            this.tbBilan.Size = new System.Drawing.Size(708, 621);
            this.tbBilan.TabIndex = 0;
            // 
            // tpSolde
            // 
            this.tpSolde.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpSolde.Controls.Add(this.btnBilan);
            this.tpSolde.Controls.Add(this.cboEventSolde);
            this.tpSolde.Controls.Add(this.dgvSolde);
            this.tpSolde.Location = new System.Drawing.Point(4, 36);
            this.tpSolde.Name = "tpSolde";
            this.tpSolde.Size = new System.Drawing.Size(700, 581);
            this.tpSolde.TabIndex = 2;
            this.tpSolde.Text = "Bilan";
            // 
            // btnBilan
            // 
            this.btnBilan.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBilan.FlatAppearance.BorderSize = 0;
            this.btnBilan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilan.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.btnBilan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBilan.Location = new System.Drawing.Point(515, 381);
            this.btnBilan.Name = "btnBilan";
            this.btnBilan.Size = new System.Drawing.Size(167, 48);
            this.btnBilan.TabIndex = 2;
            this.btnBilan.Text = "Bilan";
            this.btnBilan.UseVisualStyleBackColor = false;
            this.btnBilan.Click += new System.EventHandler(this.btnBilan_Click);
            // 
            // cboEventSolde
            // 
            this.cboEventSolde.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEventSolde.FormattingEnabled = true;
            this.cboEventSolde.Location = new System.Drawing.Point(22, 58);
            this.cboEventSolde.Name = "cboEventSolde";
            this.cboEventSolde.Size = new System.Drawing.Size(309, 32);
            this.cboEventSolde.TabIndex = 1;
            this.cboEventSolde.SelectedIndexChanged += new System.EventHandler(this.cboEventSolde_SelectedIndexChanged);
            // 
            // dgvSolde
            // 
            this.dgvSolde.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolde.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSolde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolde.Location = new System.Drawing.Point(22, 117);
            this.dgvSolde.Name = "dgvSolde";
            this.dgvSolde.RowHeadersWidth = 51;
            this.dgvSolde.RowTemplate.Height = 24;
            this.dgvSolde.Size = new System.Drawing.Size(660, 234);
            this.dgvSolde.TabIndex = 0;
            // 
            // ucBilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.tbBilan);
            this.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "ucBilan";
            this.Size = new System.Drawing.Size(716, 630);
            this.Load += new System.EventHandler(this.ucBilan_Load);
            this.tbBilan.ResumeLayout(false);
            this.tpSolde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolde)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbBilan;
        private System.Windows.Forms.TabPage tpSolde;
        private System.Windows.Forms.DataGridView dgvSolde;
        private System.Windows.Forms.ComboBox cboEventSolde;
        private System.Windows.Forms.Button btnBilan;
    }
}
