using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Saé
{
    // Contrôle utilisateur pour afficher les dépenses
    public partial class ucDepenses : UserControl
    {
        private SQLiteConnection cnx;  
        private DataSet ds;  

        
        public ucDepenses()
        {
            InitializeComponent();  
            CustomizeComboBox(cboEvent);  // Personnalisation de la cbo des événements
            CustomizeComboBox(cboEvent2);  //Personnalisation de la cbo des événements
            CustomizeComboBox(cboQui);  // Personnalisation de la cbo des participants
            CustomizeComboBox(cboQui2);  // Personnalisation de la cbo des participants

            tbDepenses.DrawMode = TabDrawMode.OwnerDrawFixed;  
            tbDepenses.DrawItem += new DrawItemEventHandler(tbDepenses_DrawItem);  
            tbDepenses.Paint += new PaintEventHandler(tbDepenses_Paint);  
        }

        // Personnalisation des onglets
        private void tbDepenses_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tbDepenses.TabPages[e.Index];
            Rectangle tabBounds = tbDepenses.GetTabRect(e.Index);

            e.Graphics.FillRectangle(e.State == DrawItemState.Selected ? Brushes.DarkBlue : Brushes.LightBlue, tabBounds);

            using (var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(tabPage.Text, e.Font, Brushes.White, tabBounds, stringFormat);
            }
        }

        // Personnalisation des onglets
        private void tbDepenses_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = tbDepenses.ClientRectangle;
            rect.Inflate(-1, -1);
            ControlPaint.DrawBorder(e.Graphics, rect, Color.Black, ButtonBorderStyle.Solid);
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

        private void ucDepenses_Load(object sender, EventArgs e)
        {
            string chcon = "Data Source=bdEvents.sqlite";  
            cnx = new SQLiteConnection(chcon);
            cnx.Open();  

            ds = new DataSet();  
            LoadEvents();  // Charge les événements
            LoadParticipants();  // Charge les participants
        }

        // Remplit les evenements dans les cbo
        private void LoadEvents()
        {
            string query = "SELECT codeEvent, titreEvent FROM Evenements"; 
            using (var adapter = new SQLiteDataAdapter(query, cnx))
            {
                adapter.Fill(ds, "Evenements");  // Remplit le DataSet avec les résultats de la requête

                cboEvent.DisplayMember = "titreEvent";  
                cboEvent.ValueMember = "codeEvent"; 
                cboEvent.DataSource = ds.Tables["Evenements"]; 

                cboEvent2.DisplayMember = "titreEvent";  
                cboEvent2.ValueMember = "codeEvent";  
                cboEvent2.DataSource = ds.Tables["Evenements"].Copy();  
            }
        }

        // Remplit les participants dans les cbo
        private void LoadParticipants()
        {
            string query = "SELECT codeParticipant, nomPart || ' ' || prenomPart AS fullName FROM Participants"; 
            using (var adapter = new SQLiteDataAdapter(query, cnx))
            {
                adapter.Fill(ds, "Participants");  // Remplit le DataSet avec les résultats de la requête

                cboQui.DisplayMember = "fullName";  
                cboQui.ValueMember = "codeParticipant";  
                cboQui.DataSource = ds.Tables["Participants"];  

                cboQui2.DisplayMember = "fullName";  
                cboQui2.ValueMember = "codeParticipant"; 
                cboQui2.DataSource = ds.Tables["Participants"].Copy(); 
            }
        }

        private void cboEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEvent.SelectedValue != null && int.TryParse(cboEvent.SelectedValue.ToString(), out int eventId))
            {
                actualisationMesDepenses();  // Actualise les dépenses du participant
            }
            else
            {
                MessageBox.Show("La valeur sélectionnée ne peut pas être convertie en entier.");  // Affiche un message d'erreur si la conversion échoue
            }
        }

        private void cboQui_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualisationMesDepenses();  // Actualise les dépenses du participant
        }

        // Actualise les dépenses du participant pour l'événement sélectionné
        private void actualisationMesDepenses()
        {
            if (cboEvent.SelectedValue != null && cboQui.SelectedValue != null)
            {
                if (int.TryParse(cboEvent.SelectedValue.ToString(), out int eventId) &&
                    int.TryParse(cboQui.SelectedValue.ToString(), out int participantId))
                {
                    LoadMesDepenses(eventId, participantId);  
                }
                else
                {
                    MessageBox.Show("La valeur sélectionnée ne peut pas être convertie en entier.");  // Affiche un message d'erreur si la conversion échoue
                }
            }
        }

        // Actualise les dépenses qui concernent le participant pour l'événement sélectionné
        private void actualisationDepensesQuiMeConcernent()
        {
            if (cboEvent2.SelectedValue != null && cboQui2.SelectedValue != null)
            {
                if (int.TryParse(cboEvent2.SelectedValue.ToString(), out int eventId) &&
                    int.TryParse(cboQui2.SelectedValue.ToString(), out int participantId))
                {
                    LoadDepensesQuiMeConcernent(eventId, participantId); 
                }
                else
                {
                    MessageBox.Show("La valeur sélectionnée ne peut pas être convertie en entier.");  // Affiche un message d'erreur si la conversion échoue
                }
            }
        }

        private void LoadMesDepenses(int eventId, int participantId)
        {
            string query = @"
            SELECT numDepense, dateDepense, description, montant
            FROM Depenses
            WHERE codePart = @pPart
            AND codeEvent = @pEvent";  

            using (var cmd = new SQLiteCommand(query, cnx))
            {
                cmd.Parameters.AddWithValue("@pEvent", eventId);  // Ajoute le paramètre eventId
                cmd.Parameters.AddWithValue("@pPart", participantId);  // Ajoute le paramètre participantId
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("MesDepenses");  
                    adapter.Fill(dt);  // Remplit la table avec les résultats de la requête
                    if (ds.Tables.Contains("MesDepenses"))
                    {
                        ds.Tables["MesDepenses"].Clear();  // Vide la table existante si elle existe
                        ds.Tables["MesDepenses"].Merge(dt);  // Fusionne les nouvelles données dans la table existante
                    }
                    else
                    {
                        ds.Tables.Add(dt);  
                    }
                    dgvMesDepenses.DataSource = ds.Tables["MesDepenses"]; 
                }
            }
            AdjustColumnWidth(dgvMesDepenses);  // Ajuste la largeur des colonnes du DataGridView
        }

        private void LoadDepensesQuiMeConcernent(int eventId, int participantId)
        {
            string query = @"
                SELECT d.numDepense, d.montant, SUM(p.nbParts) AS SommeDenbParts
                FROM Depenses AS d
                JOIN Beneficiaires AS b ON d.numDepense = b.numDepense
                JOIN Participants AS p ON b.codePart = p.codeParticipant
                WHERE d.numDepense IN (
                    SELECT d1.numDepense
                    FROM Beneficiaires bl
                    JOIN Depenses d1 ON bl.numDepense = d1.numDepense
                    WHERE d1.codeEvent = @pEvent
                    AND bl.codePart = @pPart
                )
                GROUP BY d.numDepense, d.montant";  

            using (var cmd = new SQLiteCommand(query, cnx))
            {
                cmd.Parameters.AddWithValue("@pEvent", eventId);  // Ajoute le paramètre eventId
                cmd.Parameters.AddWithValue("@pPart", participantId);  // Ajoute le paramètre participantId
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("DepensesQuiMeConcernent");  // Crée une nouvelle table pour les dépenses qui concernent le participant
                    dt.Columns.Add("numDepense", typeof(int));  // Ajoute une colonne pour le numéro de dépense
                    dt.Columns.Add("montant", typeof(double));  // Ajoute une colonne pour le montant
                    dt.Columns.Add("SommeDenbParts", typeof(double));  // Ajoute une colonne pour la somme des parts

                    adapter.Fill(dt);  // Remplit la table avec les résultats de la requête
                    if (ds.Tables.Contains("DepensesQuiMeConcernent"))
                    {
                        ds.Tables["DepensesQuiMeConcernent"].Clear();  // Vide la table existante si elle existe
                        ds.Tables["DepensesQuiMeConcernent"].Merge(dt);  // Fusionne les nouvelles données dans la table existante
                    }
                    else
                    {
                        ds.Tables.Add(dt); 
                    }
                    dgvDepensesQuiMeConcernent.DataSource = ds.Tables["DepensesQuiMeConcernent"]; 
                }
            }
        }

        private void cboQui2_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualisationDepensesQuiMeConcernent();  // Actualise les dépenses qui concernent le participant
        }

        private void cboEvent2_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualisationDepensesQuiMeConcernent();  // Actualise les dépenses qui concernent le participant
        }

        // Ajuste la largeur des colonnes d'un DataGridView
        private void AdjustColumnWidth(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns[0].Width = 52;  
                dgv.Columns[2].Width = 210; 
            }
        }
    }
}
