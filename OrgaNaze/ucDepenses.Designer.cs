namespace Saé
{
    partial class ucDepenses
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
            this.tbDepenses = new System.Windows.Forms.TabControl();
            this.tpMesDepenses = new System.Windows.Forms.TabPage();
            this.cboQui = new System.Windows.Forms.ComboBox();
            this.dgvMesDepenses = new System.Windows.Forms.DataGridView();
            this.cboEvent = new System.Windows.Forms.ComboBox();
            this.tpDepensesQuiMeConcernent = new System.Windows.Forms.TabPage();
            this.cboEvent2 = new System.Windows.Forms.ComboBox();
            this.cboQui2 = new System.Windows.Forms.ComboBox();
            this.dgvDepensesQuiMeConcernent = new System.Windows.Forms.DataGridView();
            this.tbDepenses.SuspendLayout();
            this.tpMesDepenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesDepenses)).BeginInit();
            this.tpDepensesQuiMeConcernent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepensesQuiMeConcernent)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDepenses
            // 
            this.tbDepenses.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbDepenses.Controls.Add(this.tpMesDepenses);
            this.tbDepenses.Controls.Add(this.tpDepensesQuiMeConcernent);
            this.tbDepenses.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbDepenses.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14.25F);
            this.tbDepenses.Location = new System.Drawing.Point(18, 19);
            this.tbDepenses.Name = "tbDepenses";
            this.tbDepenses.RightToLeftLayout = true;
            this.tbDepenses.SelectedIndex = 0;
            this.tbDepenses.Size = new System.Drawing.Size(542, 426);
            this.tbDepenses.TabIndex = 3;
            // 
            // tpMesDepenses
            // 
            this.tpMesDepenses.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpMesDepenses.Controls.Add(this.cboQui);
            this.tpMesDepenses.Controls.Add(this.dgvMesDepenses);
            this.tpMesDepenses.Controls.Add(this.cboEvent);
            this.tpMesDepenses.Location = new System.Drawing.Point(4, 36);
            this.tpMesDepenses.Name = "tpMesDepenses";
            this.tpMesDepenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpMesDepenses.Size = new System.Drawing.Size(534, 386);
            this.tpMesDepenses.TabIndex = 1;
            this.tpMesDepenses.Text = "Mes dépenses";
            // 
            // cboQui
            // 
            this.cboQui.FormattingEnabled = true;
            this.cboQui.Location = new System.Drawing.Point(46, 53);
            this.cboQui.Name = "cboQui";
            this.cboQui.Size = new System.Drawing.Size(205, 32);
            this.cboQui.TabIndex = 2;
            this.cboQui.SelectedIndexChanged += new System.EventHandler(this.cboQui_SelectedIndexChanged);
            // 
            // dgvMesDepenses
            // 
            this.dgvMesDepenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMesDepenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMesDepenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMesDepenses.Location = new System.Drawing.Point(46, 187);
            this.dgvMesDepenses.Name = "dgvMesDepenses";
            this.dgvMesDepenses.RowHeadersWidth = 51;
            this.dgvMesDepenses.RowTemplate.Height = 24;
            this.dgvMesDepenses.Size = new System.Drawing.Size(425, 146);
            this.dgvMesDepenses.TabIndex = 1;
            // 
            // cboEvent
            // 
            this.cboEvent.FormattingEnabled = true;
            this.cboEvent.Location = new System.Drawing.Point(46, 118);
            this.cboEvent.Name = "cboEvent";
            this.cboEvent.Size = new System.Drawing.Size(205, 32);
            this.cboEvent.TabIndex = 0;
            this.cboEvent.SelectedIndexChanged += new System.EventHandler(this.cboEvent_SelectedIndexChanged);
            // 
            // tpDepensesQuiMeConcernent
            // 
            this.tpDepensesQuiMeConcernent.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tpDepensesQuiMeConcernent.Controls.Add(this.cboEvent2);
            this.tpDepensesQuiMeConcernent.Controls.Add(this.cboQui2);
            this.tpDepensesQuiMeConcernent.Controls.Add(this.dgvDepensesQuiMeConcernent);
            this.tpDepensesQuiMeConcernent.Location = new System.Drawing.Point(4, 36);
            this.tpDepensesQuiMeConcernent.Name = "tpDepensesQuiMeConcernent";
            this.tpDepensesQuiMeConcernent.Padding = new System.Windows.Forms.Padding(3);
            this.tpDepensesQuiMeConcernent.Size = new System.Drawing.Size(534, 386);
            this.tpDepensesQuiMeConcernent.TabIndex = 2;
            this.tpDepensesQuiMeConcernent.Text = "depenses qui me concernent";
            // 
            // cboEvent2
            // 
            this.cboEvent2.FormattingEnabled = true;
            this.cboEvent2.Location = new System.Drawing.Point(50, 114);
            this.cboEvent2.Name = "cboEvent2";
            this.cboEvent2.Size = new System.Drawing.Size(240, 32);
            this.cboEvent2.TabIndex = 2;
            this.cboEvent2.SelectedIndexChanged += new System.EventHandler(this.cboEvent2_SelectedIndexChanged);
            // 
            // cboQui2
            // 
            this.cboQui2.FormattingEnabled = true;
            this.cboQui2.Location = new System.Drawing.Point(50, 51);
            this.cboQui2.Name = "cboQui2";
            this.cboQui2.Size = new System.Drawing.Size(240, 32);
            this.cboQui2.TabIndex = 1;
            this.cboQui2.SelectedIndexChanged += new System.EventHandler(this.cboQui2_SelectedIndexChanged);
            // 
            // dgvDepensesQuiMeConcernent
            // 
            this.dgvDepensesQuiMeConcernent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepensesQuiMeConcernent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDepensesQuiMeConcernent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepensesQuiMeConcernent.Location = new System.Drawing.Point(33, 164);
            this.dgvDepensesQuiMeConcernent.Name = "dgvDepensesQuiMeConcernent";
            this.dgvDepensesQuiMeConcernent.RowHeadersWidth = 51;
            this.dgvDepensesQuiMeConcernent.RowTemplate.Height = 24;
            this.dgvDepensesQuiMeConcernent.Size = new System.Drawing.Size(463, 213);
            this.dgvDepensesQuiMeConcernent.TabIndex = 0;
            // 
            // ucDepenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbDepenses);
            this.Name = "ucDepenses";
            this.Size = new System.Drawing.Size(583, 468);
            this.Load += new System.EventHandler(this.ucDepenses_Load);
            this.tbDepenses.ResumeLayout(false);
            this.tpMesDepenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesDepenses)).EndInit();
            this.tpDepensesQuiMeConcernent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepensesQuiMeConcernent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbDepenses;
        private System.Windows.Forms.TabPage tpMesDepenses;
        private System.Windows.Forms.ComboBox cboQui;
        private System.Windows.Forms.DataGridView dgvMesDepenses;
        private System.Windows.Forms.ComboBox cboEvent;
        private System.Windows.Forms.TabPage tpDepensesQuiMeConcernent;
        private System.Windows.Forms.ComboBox cboEvent2;
        private System.Windows.Forms.ComboBox cboQui2;
        private System.Windows.Forms.DataGridView dgvDepensesQuiMeConcernent;
    }
}
