using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Saé
{
    // Contrôle utilisateur pour gérer les événements
    public partial class ucEvenements : UserControl
    {
        private SQLiteConnection cnx;  
        private int uid;  // Identifiant unique de l'événement

        public ucEvenements()
        {
            InitializeComponent(); 
            InitializeCustomComponents();  // Initialisation des composants personnalisés
            uid = 1;  

            btnNewEventValider.FlatAppearance.MouseOverBackColor = Color.LightGreen;  // Change la couleur du bouton Valider au survol
        }

        // Initialise les composants personnalisés
        private void InitializeCustomComponents()
        {
            tbcParcours.DrawMode = TabDrawMode.OwnerDrawFixed;  
            tbcParcours.DrawItem += new DrawItemEventHandler(tbcParcours_DrawItem);  
            tbcParcours.Paint += new PaintEventHandler(tbcParcours_Paint); 
            CustomizeComboBox(cboNewEventAuteur);  // Personnalisation de la cbo des auteurs
        }

        // Personnalisation des cbo
        private void CustomizeComboBox(ComboBox comboBox)
        {
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;  
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;  
            comboBox.FlatStyle = FlatStyle.Flat;  
            comboBox.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);  
        }

        // Colorer les cbo
        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (e.Index < 0) return;
            Color highlightColor = Color.LightBlue;
            e.Graphics.FillRectangle((e.State & DrawItemState.Selected) == DrawItemState.Selected ? new SolidBrush(highlightColor) : new SolidBrush(comboBox.BackColor), e.Bounds);
            e.DrawFocusRectangle();
            string text = comboBox.GetItemText(comboBox.Items[e.Index]);
            using (Brush textBrush = new SolidBrush(comboBox.ForeColor))
            {
                e.Graphics.DrawString(text, comboBox.Font, textBrush, e.Bounds);
            }
        }

        // Personnalisation des onglets
        private void tbcParcours_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tbcParcours.TabPages[e.Index];
            Rectangle tabBounds = tbcParcours.GetTabRect(e.Index);
            e.Graphics.FillRectangle(e.State == DrawItemState.Selected ? Brushes.DarkBlue : Brushes.LightBlue, tabBounds);

            using (var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(tabPage.Text, e.Font, Brushes.White, tabBounds, stringFormat);
            }
        }

        // Personnalisation des onglets
        private void tbcParcours_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = tbcParcours.ClientRectangle;
            rect.Inflate(-1, -1);
            ControlPaint.DrawBorder(e.Graphics, rect, Color.Black, ButtonBorderStyle.Solid);
        }

        private void ucEvenements_Load(object sender, EventArgs e)
        {
            string chcon = "Data Source=bdEvents.sqlite"; 
            try
            {
                cnx = new SQLiteConnection(chcon);
                cnx.Open();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message);
                return;
            }
            UpdateUserControl(uid);  // Met à jour le contrôle utilisateur avec l'identifiant unique
            RemplirParticipants();  // Remplit la liste des participants
        }

        // Remplit la liste des participants 
        private void RemplirParticipants()
        {
            try
            {
                cboNewEventAuteur.Items.Clear();  // Vide la liste des auteurs
                string sql = "SELECT codeParticipant, nomPart || ' ' || prenomPart AS NomComplet FROM Participants"; 
                SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
                SQLiteDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cboNewEventAuteur.DataSource = dt;  
                cboNewEventAuteur.DisplayMember = "NomComplet";  
                cboNewEventAuteur.ValueMember = "codeParticipant";  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du remplissage de la liste des participants : " + ex.Message);
            }
        }

        // Obtient les données d'un événement spécifique
        private DataTable GetEventData(int id)
        {
            DataTable eventData = new DataTable();
            string query = "SELECT * FROM Evenements WHERE codeEvent = @codeEvent"; 
            using (SQLiteCommand cmd = new SQLiteCommand(query, cnx))
            {
                cmd.Parameters.AddWithValue("@codeEvent", id);  // Ajoute le paramètre codeEvent
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(eventData);  // Remplit la table avec les résultats de la requête
            }
            return eventData;  
        }

        // Met à jour le contrôle utilisateur avec les données de l'événement spécifique
        private void UpdateUserControl(int id)
        {
            foreach (Control c in tpParcours.Controls)
            {
                if (c is ucEvent1a1)
                {
                    tpParcours.Controls.Remove(c);  // Supprime le contrôle existant
                    break;
                }
            }
            DataTable eventData = GetEventData(id);  
            ucEvent1a1 uc = new ucEvent1a1(eventData);  // Crée un nouveau contrôle utilisateur pour l'événement
            tpParcours.Controls.Add(uc);  // Ajoute le nouveau contrôle utilisateur
            uc.Dock = DockStyle.Fill;  
        }

        private void ptbSuivant_Click(object sender, EventArgs e)
        {
            uid++;
            UpdateUserControl(uid);  // Met à jour le contrôle utilisateur avec l'identifiant unique suivant
        }

        private void ptbPrecedant_Click(object sender, EventArgs e)
        {
            uid--;
            UpdateUserControl(uid);  // Met à jour le contrôle utilisateur avec l'identifiant unique précédent
        }

        private void ptbDernier_Click(object sender, EventArgs e)
        {
            string query = "SELECT MAX(codeEvent) FROM Evenements";  
            using (SQLiteCommand cmd = new SQLiteCommand(query, cnx))
            {
                uid = Convert.ToInt32(cmd.ExecuteScalar());  // Met à jour l'identifiant unique avec le code de l'événement le plus récent
            }
            UpdateUserControl(uid);  // Met à jour le contrôle utilisateur avec l'identifiant unique
        }

        private void ptbPremier_Click(object sender, EventArgs e)
        {
            string query = "SELECT MIN(codeEvent) FROM Evenements"; 
            using (SQLiteCommand cmd = new SQLiteCommand(query, cnx))
            {
                uid = Convert.ToInt32(cmd.ExecuteScalar());  // Met à jour l'identifiant unique avec le code de l'événement le plus ancien
            }
            UpdateUserControl(uid);  // Met à jour le contrôle utilisateur avec l'identifiant unique
        }

        private void btnNewEventValider_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewEventNomEvent.Text) || string.IsNullOrEmpty(cboNewEventAuteur.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs");  // Affiche un message d'erreur si des champs sont vides
                return;
            }

            string nom = txtNewEventNomEvent.Text;
            string dateDeb = dtpDateDeb.Value.ToString("yyyy-MM-dd");
            string dateFin = dtpDateFin.Value.ToString("yyyy-MM-dd");
            string description = rtxtDescription.Text;
            string auteur = cboNewEventAuteur.SelectedValue.ToString();
            int soldeON = chkSolde.Checked ? 1 : 0;

            string query = "INSERT INTO Evenements (codeEvent, titreEvent, dateDebut, dateFin, description, soldeON, codeCreateur) " +
                           "VALUES ((SELECT IFNULL(MAX(codeEvent), 0) + 1 FROM Evenements), @nom, @dateDeb, @dateFin, @description, @soldeON, @auteur)";
            using (SQLiteCommand cmd = new SQLiteCommand(query, cnx))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@dateDeb", dateDeb);
                cmd.Parameters.AddWithValue("@dateFin", dateFin);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@soldeON", soldeON);
                cmd.Parameters.AddWithValue("@auteur", auteur);
                cmd.ExecuteNonQuery();  
            }

            UpdateUserControl(uid);  // Met à jour le contrôle utilisateur avec l'identifiant unique
            txtNewEventNomEvent.Text = "";
            dtpDateDeb.Value = DateTime.Now;
            dtpDateFin.Value = DateTime.Now;
            rtxtDescription.Text = "";
            cboNewEventAuteur.Text = "";
            MessageBox.Show("Evénement ajouté avec succès");  // Affiche un message de confirmation
        }
    }
}
