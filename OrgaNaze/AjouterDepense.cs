using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saé
{
    public partial class ucAjouterDepense : UserControl
    {
        SQLiteConnection cnx = new SQLiteConnection();
        public event EventHandler AnnulerClicked;

        public ucAjouterDepense()
        {
            InitializeComponent();

            // Connecter les événements TextChanged
            txtQuoi.TextChanged += txtQuoi_TextChanged;
            txtCombien.TextChanged += txtCombien_TextChanged;

            // Connecter les événements des ComboBox et DateTimePicker
            cboEvenement.SelectedIndexChanged += cboEvenement_SelectedIndexChanged;
            cboPayePar.SelectedIndexChanged += cboPayePar_SelectedIndexChanged;
            dtpQuand.ValueChanged += dtpQuand_ValueChanged;

            // Connecter l'événement CheckedChanged du CheckBox
            ckbBeneficiares.CheckedChanged += ckbBeneficiares_CheckedChanged;

            // Connecter l'événement ItemCheck du CheckedListBox
            clbBeneficiaires.ItemCheck += clbBeneficiaires_ItemCheck;

            // Personnaliser la ComboBox
            CustomizeComboBox(cboEvenement);
            CustomizeComboBox(cboPayePar);
            btnAnnuler.FlatAppearance.MouseOverBackColor = Color.LightCoral;
        }

        private void CustomizeComboBox(ComboBox comboBox)
        {
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (e.Index < 0) return;
            Color highlightColor = Color.LightBlue;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(highlightColor), e.Bounds);
            }
            else
            {
                e.DrawBackground();
            }
            e.DrawFocusRectangle();
            string text = comboBox.GetItemText(comboBox.Items[e.Index]);
            using (Brush textBrush = new SolidBrush(comboBox.ForeColor))
            {
                e.Graphics.DrawString(text, comboBox.Font, textBrush, e.Bounds);
            }
        }

        private void ucAjouterDepense_Load(object sender, EventArgs e)
        {
            string chcon = "Data Source=bdEvents.sqlite";
            cnx.ConnectionString = chcon;
            cnx.Open();
            RemplirEvenements();
            ToggleValiderButton();
        }

        private void cboPayePar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleValiderButton();
        }

        private void ckbBeneficiares_CheckedChanged(object sender, EventArgs e)
        {
            // cocher ou décocher tous les bénéficiaires
            for (int i = 0; i < clbBeneficiaires.Items.Count; i++)
            {
                clbBeneficiaires.SetItemChecked(i, ckbBeneficiares.Checked);
            }
            ToggleValiderButton();
        }

        private void RemplirEvenements()
        {
            string sql = "SELECT codeEvent, titreEvent FROM Evenements";
            SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                // Ajouter les événements avec leur ID dans le ComboBox
                cboEvenement.Items.Add(new { CodeEvent = dr.GetInt32(0), TitreEvent = dr.GetString(1) });
            }
            dr.Close();

            // Définir les propriétés DisplayMember et ValueMember
            cboEvenement.DisplayMember = "TitreEvent";
            cboEvenement.ValueMember = "CodeEvent";
        }

        private void cboEvenement_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPayePar.Items.Clear();
            clbBeneficiaires.Items.Clear();

            var selectedItem = cboEvenement.SelectedItem;
            if (selectedItem != null)
            {
                RemplirParticipants(((dynamic)selectedItem).CodeEvent);
            }

            ToggleValiderButton();
        }

        private void RemplirParticipants(int codeEvent)
        {
            string sql = "SELECT nomPart || ' ' || prenomPart " +
                         "FROM Participants " +
                         "JOIN Invites ON Participants.codeParticipant = Invites.codePart " +
                         "WHERE Invites.codeEvent = @codeEvent";
            SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
            // remplir cboPayePar et clbBeneficiaires
            cmd.Parameters.AddWithValue("@codeEvent", codeEvent);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboPayePar.Items.Add(dr.GetString(0));
                clbBeneficiaires.Items.Add(dr.GetString(0));
            }
            dr.Close();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            // ajouter la dépense dans la base de données
            // Depenses : numDepense, description, montant, dateDepense, commentaire, codeEvent, codePart

            // récupérer un numéro de dépense
            string sql = "SELECT MAX(numDepense) FROM Depenses";
            SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
            int numDepense = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

            // récupérer le codePart du payeur
            sql = "SELECT codeParticipant FROM Participants WHERE nomPart || ' ' || prenomPart = @nomPart";
            cmd = new SQLiteCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@nomPart", cboPayePar.Text);
            int codePart = Convert.ToInt32(cmd.ExecuteScalar());

            // récupérer le codeEvent
            int codeEvent = ((dynamic)cboEvenement.SelectedItem).CodeEvent;

            // convertir la date en format SQLite
            DateTime dateDepense = dtpQuand.Value;
            string dateSQLite = dateDepense.ToString("yyyy-MM-dd");

            // ajouter la dépense
            sql = "INSERT INTO Depenses VALUES (@numDepense, @description, @montant, @dateDepense, @commentaire, @codeEvent, @codePart)";
            cmd = new SQLiteCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@numDepense", numDepense);
            cmd.Parameters.AddWithValue("@description", txtQuoi.Text);
            cmd.Parameters.AddWithValue("@montant", Convert.ToDouble(txtCombien.Text));
            cmd.Parameters.AddWithValue("@dateDepense", dateSQLite);
            cmd.Parameters.AddWithValue("@commentaire", rtxtCommentaire.Text);
            cmd.Parameters.AddWithValue("@codeEvent", codeEvent);
            cmd.Parameters.AddWithValue("@codePart", codePart);
            cmd.ExecuteNonQuery();

            // ajouter les bénéficiaires dans la table Beneficiaires
            foreach (string beneficiaire in clbBeneficiaires.CheckedItems)
            {
                // récupérer le codePart du bénéficiaire
                sql = "SELECT codeParticipant FROM Participants WHERE nomPart || ' ' || prenomPart = @nomPart";
                cmd = new SQLiteCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@nomPart", beneficiaire);
                int codeBeneficiaire = Convert.ToInt32(cmd.ExecuteScalar());

                // ajouter le bénéficiaire
                sql = "INSERT INTO Beneficiaires VALUES (@numDepense, @codePart)";
                cmd = new SQLiteCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@numDepense", numDepense);
                cmd.Parameters.AddWithValue("@codePart", codeBeneficiaire);
                cmd.ExecuteNonQuery();
            }

            // vider les champs
            txtQuoi.Text = "";
            txtCombien.Text = "";
            rtxtCommentaire.Text = "";
            cboEvenement.SelectedIndex = -1;
            cboPayePar.SelectedIndex = -1;
            clbBeneficiaires.Items.Clear();
            grpDepense.Visible = false;

            MessageBox.Show("La dépense a été ajoutée avec succès.");
        }

        private bool ChampsRemplis()
        {
            // Vérifiez si tous les champs nécessaires sont remplis
            bool txtQuoiRempli = !string.IsNullOrEmpty(txtQuoi.Text);
            bool txtCombienRempli = !string.IsNullOrEmpty(txtCombien.Text);
            bool cboEvenementSelectionne = cboEvenement.SelectedIndex != -1;
            bool cboPayeParSelectionne = cboPayePar.SelectedIndex != -1;
            bool clbBeneficiairesSelectionnes = clbBeneficiaires.CheckedItems.Count > 0;
            bool dtpQuandSelectionne = dtpQuand.Value != DateTime.MinValue;

            return txtQuoiRempli && txtCombienRempli && cboEvenementSelectionne && cboPayeParSelectionne && clbBeneficiairesSelectionnes && dtpQuandSelectionne;
        }

        private void ToggleValiderButton()
        {
            bool champsRemplis = ChampsRemplis();
            btnValider.Enabled = champsRemplis;
            if (champsRemplis)
            {
                btnValider.BackColor = Color.CornflowerBlue;
                btnValider.FlatAppearance.MouseOverBackColor = Color.LightGreen;
            }
            else
            {
                btnValider.BackColor = SystemColors.Control;
                btnValider.FlatAppearance.MouseOverBackColor = SystemColors.Control;
            }
        }

        private void txtQuoi_TextChanged(object sender, EventArgs e)
        {
            ToggleValiderButton();
        }

        private void txtCombien_TextChanged(object sender, EventArgs e)
        {
            ToggleValiderButton();
        }

        private void dtpQuand_ValueChanged(object sender, EventArgs e)
        {
            ToggleValiderButton();
        }

        private void clbBeneficiaires_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() => ToggleValiderButton()));
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            AnnulerClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}