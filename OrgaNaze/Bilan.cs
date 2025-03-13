using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Saé
{
    // Contrôle utilisateur pour afficher le bilan
    public partial class ucBilan : UserControl
    {
        private SQLiteConnection cnx;  
        private DataSet ds = new DataSet(); 

        public ucBilan()
        {
            InitializeComponent();  
            CustomizeComboBox(cboEventSolde);  // Personnalisation de la cbo des événements
            btnBilan.FlatAppearance.MouseOverBackColor = Color.LightGreen;  // Change la couleur du bouton Bilan au survol
            tbBilan.DrawMode = TabDrawMode.OwnerDrawFixed;  
            tbBilan.DrawItem += new DrawItemEventHandler(tbBilan_DrawItem);  
            tbBilan.Paint += new PaintEventHandler(tbBilan_Paint);
        }

        // Personnalisation des onglets
        private void tbBilan_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tbBilan.TabPages[e.Index];
            System.Drawing.Rectangle tabBounds = tbBilan.GetTabRect(e.Index);
            e.Graphics.FillRectangle(Brushes.DarkBlue, tabBounds);

            using (var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(tabPage.Text, e.Font, Brushes.White, tabBounds, stringFormat);
            }

            e.Graphics.DrawRectangle(Pens.Black, tabBounds);
        }

        // Personnalisation des onglets
        private void tbBilan_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = tbBilan.ClientRectangle;
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

        // Met en couleur les cbo
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

    


        private void ucBilan_Load(object sender, EventArgs e)
        {
            string chcon = "Data Source=bdEvents.sqlite";  
            cnx = new SQLiteConnection(chcon);
            cnx.Open();  
            ds = new DataSet();
            LoadEvents();
        }

        // Remplit les evenements dans la cbo
        private void LoadEvents()
        {
            string query = "SELECT codeEvent, titreEvent FROM Evenements";  
            using (var adapter = new SQLiteDataAdapter(query, cnx))
            {
                adapter.Fill(ds, "Evenements");  // Remplit le DataSet avec les résultats de la requête
                cboEventSolde.DisplayMember = "titreEvent";  
                cboEventSolde.ValueMember = "codeEvent";  
                cboEventSolde.DataSource = ds.Tables["Evenements"].Copy();  
            }
        }

        // Obtient les dépenses d'un participant pour un événement spécifique
        private DataTable mesDepenses(int eventId, int participantId)
        {
            string query = @"SELECT numDepense, dateDepense, description, montant
                             FROM Depenses
                             WHERE codePart = @pPart
                             AND codeEvent = @pEvent"; 

            using (var cmd = new SQLiteCommand(query, cnx))
            {
                cmd.Parameters.AddWithValue("@pPart", participantId);  // Ajoute le paramètre participantId
                cmd.Parameters.AddWithValue("@pEvent", eventId);  // Ajoute le paramètre eventId
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("MesDepenses"); 
                    adapter.Fill(dt);  // Remplit la table avec les résultats de la requête
                    return dt;  
                }
            }
        }

        // Obtient les dépenses qui concernent un participant pour un événement spécifique
        private DataTable depensesQuiMeConcernent(int eventId, int participantId)
        {
            string query = @"SELECT d.numDepense, d.montant, SUM(p.nbParts) AS SommeDenbParts
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
                DataTable dt = new DataTable("DepensesQuiMeConcernent");  
                cmd.Parameters.AddWithValue("@pEvent", eventId);  // Ajoute le paramètre eventId
                cmd.Parameters.AddWithValue("@pPart", participantId);  // Ajoute le paramètre participantId
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);  // Remplit la table avec les résultats de la requête
                    return dt;  
                }
            }
        }

        // Obtient les parts des participants pour un événement spécifique
        private DataTable GetParticipantsParts(int eventId)
        {
            string query = @"SELECT p.codeParticipant, p.nbParts
                             FROM Participants AS p
                             JOIN Invites AS i ON i.codePart = p.codeParticipant
                             WHERE i.codeEvent = @eventId";  

            using (var cmd = new SQLiteCommand(query, cnx))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);  // Ajoute le paramètre eventId
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable("ParticipantsParts");  
                    adapter.Fill(dt);  // Remplit la table avec les résultats de la requête
                    return dt; 
                }
            }
        }

        private void cboEventSolde_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSolde(int.Parse(cboEventSolde.SelectedValue.ToString()));  // Charge le solde pour l'événement sélectionné
        }

        // Calcule les crédits d'un participant pour un événement spécifique
        private void DepensesCredit(int codeEvent, int numParticipant, out decimal totalCredit)
        {
            DataTable dt = mesDepenses(codeEvent, numParticipant);  // Dépenses du participant
            totalCredit = dt.Rows.Count > 0 ? Math.Round(Convert.ToDecimal(dt.Compute("SUM(montant)", string.Empty)), 2) : 0;  // Calcule le total des crédits
        }

        // Calcule les débits d'un participant pour un événement spécifique
        private void DepensesDebit(int codeEvent, int numParticipant, out decimal totalDebit, DataTable participantsParts)
        {
            DataTable dt = depensesQuiMeConcernent(codeEvent, numParticipant);  // Dépenses qui concernent le participant
            if (dt.Rows.Count > 0)
            {
                DataRow[] participantPartsRow = participantsParts.Select($"codeParticipant = {numParticipant}");
                int participantParts = participantPartsRow.Length > 0 ? Convert.ToInt32(participantPartsRow[0]["nbParts"]) : 1;
                dt.Columns.Add("PartMontant", typeof(decimal), $"montant * {participantParts} / SommeDenbParts");  // Ajoute une colonne calculée pour le montant par part
                totalDebit = Math.Round(Convert.ToDecimal(dt.Compute("SUM(PartMontant)", string.Empty)), 2);  // Calcule le total des débits
            }
            else
            {
                totalDebit = 0;
            }
        }

        // Charge le solde pour un événement spécifique
        private void LoadSolde(int eventId)
        {
            dgvSolde.DataSource = null;
            dgvSolde.Rows.Clear();
            dgvSolde.Columns.Clear();
            dgvSolde.Columns.Add("codePart", "Code");
            dgvSolde.Columns.Add("nomPart", "Nom");
            dgvSolde.Columns.Add("Plus", "Dépenses");
            dgvSolde.Columns.Add("Moins", "Crédit");
            dgvSolde.Columns.Add("Solde", "Solde");

            string query = @"SELECT p.codeParticipant, p.nomPart || ' ' || p.prenomPart AS nomPart, p.mobile, p.nbParts
                             FROM Participants AS p
                             JOIN Invites AS i ON i.codePart = p.codeParticipant
                             WHERE i.codeEvent = @eventId"; 

            AdjustColumnWidth(dgvSolde);  // Ajuste la largeur des colonnes

            using (var cmd = new SQLiteCommand(query, cnx))
            {
                cmd.Parameters.AddWithValue("@eventId", eventId);  // Ajoute le paramètre eventId
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);  // Remplit la table avec les résultats de la requête
                    DataTable participantsParts = GetParticipantsParts(eventId);  // Parts des participants

                    foreach (DataRow row in dt.Rows)
                    {
                        int numParticipant = int.Parse(row["codeParticipant"].ToString());
                        string nomParticipant = row["nomPart"].ToString();
                        DepensesCredit(eventId, numParticipant, out decimal totalCredit);  // Calcule les crédits
                        DepensesDebit(eventId, numParticipant, out decimal totalDebit, participantsParts);  // Calcule les débits
                        decimal solde = Math.Round(totalCredit - totalDebit, 2);  // Calcule le solde
                        dgvSolde.Rows.Add(numParticipant, nomParticipant, totalCredit, totalDebit, solde);  // Ajoute une ligne au DataGridView
                    }
                }
            }
        }

        private void btnBilan_Click(object sender, EventArgs e)
        {
            calculRemboursement();  // Calcule le remboursement
        }

        // Calcule les remboursements entre les participants
        private void calculRemboursement()
        {
            DataTable bilan = new DataTable();
            bilan.Columns.Add("nomPart", typeof(string));
            bilan.Columns.Add("solde", typeof(decimal));

            foreach (DataGridViewRow row in dgvSolde.Rows)
            {
                var nomPartCell = row.Cells["nomPart"].Value;
                var soldeCell = row.Cells["Solde"].Value;

                if (nomPartCell != null && soldeCell != null)
                {
                    bilan.Rows.Add(nomPartCell.ToString(), Convert.ToDecimal(soldeCell));
                }
            }

            string message = calculRemboursementParParticipant(bilan);  // Calcule le remboursement par participant
            string detailedExpenses = GatherDetailedExpenses();  // Obtient les détails des dépenses
            string fullMessage = message + "\n\nDétails des dépenses:\n" + detailedExpenses;
            impresionPDF(fullMessage);  // Imprime le bilan en PDF
            MessageBox.Show(message);  // Affiche le message de remboursement
        }

        // Rassemble les détails des dépenses de chaque participant
        private string GatherDetailedExpenses()
        {
            string details = "";
            foreach (DataGridViewRow row in dgvSolde.Rows)
            {
                if (row.Cells["codePart"].Value != null)
                {
                    int participantId = Convert.ToInt32(row.Cells["codePart"].Value);
                    string participantName = row.Cells["nomPart"].Value.ToString();
                    DataTable dt = mesDepenses(Convert.ToInt32(cboEventSolde.SelectedValue), participantId);

                    details += $"{participantName}:\n";
                    foreach (DataRow expenseRow in dt.Rows)
                    {
                        string description = expenseRow["description"].ToString();
                        DateTime dateDepense = Convert.ToDateTime(expenseRow["dateDepense"]);
                        decimal montant = Convert.ToDecimal(expenseRow["montant"]);
                        details += $"- {dateDepense.ToShortDateString()} : {description} : {montant}?\n";
                    }
                    details += "\n";
                }
            }
            return details;
        }

        // Calcule les remboursements par participant
        private string calculRemboursementParParticipant(DataTable dt)
        {
            string message = "";

            while (dt.Rows.Count > 0)
            {
                DataRow minRow = calculSoldeMin(dt);  // Calcule le solde minimum
                DataRow maxRow = calculSoldeMax(dt);  // Calcule le solde maximum

                decimal soldeMin = Math.Abs((decimal)minRow["solde"]);
                decimal soldeMax = Math.Abs((decimal)maxRow["solde"]);

                if (minRow["nomPart"].ToString() == maxRow["nomPart"].ToString())
                {
                    dt.Rows.Remove(minRow);
                    continue;
                }

                if (soldeMin <= soldeMax)
                {
                    message += $"{minRow["nomPart"]} doit rembourser {soldeMin}? à {maxRow["nomPart"]}\n";
                    maxRow["solde"] = soldeMax - soldeMin;
                    dt.Rows.Remove(minRow);
                }
                else
                {
                    message += $"{minRow["nomPart"]} doit rembourser {soldeMax}? à {maxRow["nomPart"]}\n";
                    minRow["solde"] = soldeMax - soldeMin;
                    dt.Rows.Remove(maxRow);
                }
            }

            return message;
        }

        // Calcule le solde minimum d'un DataTable
        private DataRow calculSoldeMin(DataTable dt)
        {
            return dt.AsEnumerable().OrderBy(row => row.Field<decimal>("solde")).First();
        }

        // Calcule le solde maximum d'un DataTable
        private DataRow calculSoldeMax(DataTable dt)
        {
            return dt.AsEnumerable().OrderByDescending(row => row.Field<decimal>("solde")).First();
        }

        // Imprime le bilan en PDF
        private void impresionPDF(string message)
        {
            string outfile = "bilan_" + cboEventSolde.Text + ".pdf";
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(outfile, FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph("Bilan de l'évènement " + cboEventSolde.Text)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(title);
            doc.Add(new Paragraph("Bilan des remboursements"));
            doc.Add(new Paragraph(message));

            doc.Close();
        }

        // Ajuste la largeur des colonnes d'un DataGridView
        private void AdjustColumnWidth(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns[0].Width = 60;
                dgv.Columns[1].Width = 240;
            }
        }
    }
}
