using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Saé
{
    // Contrôle utilisateur pour gérer les participants
    public partial class ucParticipants : UserControl
    {
        private SQLiteConnection cnx;  
        private DataSet ds;  
        private DataTable dtParticipants; 

        public ucParticipants()
        {
            InitializeComponent();  
            CustomizeComboBox(cboEvent);  // Personnalisation de la cbo des événements
            CustomizeComboBox(cboInvite);  // Personnalisation de la cbo des participants à inviter

            tbParticipant.DrawMode = TabDrawMode.OwnerDrawFixed;  
            tbParticipant.DrawItem += new DrawItemEventHandler(tbParticipants_DrawItem); 
            tbParticipant.Paint += new PaintEventHandler(tbParticipants_Paint);  

            btnAjoutInvite.FlatAppearance.MouseOverBackColor = Color.LightGreen;  // Change la couleur du bouton Ajout Invite au survol
            btnAjoutUser.FlatAppearance.MouseOverBackColor = Color.LightGreen;  // Change la couleur du bouton Ajout User au survol
            btnInviter.FlatAppearance.MouseOverBackColor = Color.LightGreen;  // Change la couleur du bouton Inviter au survol
        }

        // Personnalisation des cbo
        private void CustomizeComboBox(ComboBox comboBox)
        {
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;  
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;  
            comboBox.FlatStyle = FlatStyle.Flat;  
            comboBox.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem); }


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
        private void tbParticipants_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tbParticipant.TabPages[e.Index];
            Rectangle tabBounds = tbParticipant.GetTabRect(e.Index);
            e.Graphics.FillRectangle(e.State == DrawItemState.Selected ? Brushes.DarkBlue : Brushes.LightBlue, tabBounds);

            using (var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(tabPage.Text, e.Font, Brushes.White, tabBounds, stringFormat);
            }
        }

        // Personnalisation des onglets
        private void tbParticipants_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = tbParticipant.ClientRectangle;
            rect.Inflate(-1, -1);
            ControlPaint.DrawBorder(e.Graphics, rect, Color.Black, ButtonBorderStyle.Solid);
        }



        private void ucParticipants_Load(object sender, EventArgs e)
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

            ds = new DataSet();  
            RemplirEvenements();  // Remplit la liste des événements
        }

        // Fermeture du formulaire
        private void ucParticipants_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cnx != null && cnx.State == ConnectionState.Open)
            {
                cnx.Close(); 
            }
        }

        // Remplit la liste des événements
        private void RemplirEvenements()
        {
            try
            {
                string sql = "SELECT codeEvent, titreEvent FROM Evenements";  
                SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
                SQLiteDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                cboEvent.DataSource = dt;  
                cboEvent.ValueMember = "codeEvent";
                cboEvent.DisplayMember = "titreEvent"; 

                if (cboEvent.Items.Count > 0)
                {
                    cboEvent.SelectedIndex = 0;  // Sélectionne le premier élément si la liste n'est pas vide
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du remplissage des événements : " + ex.Message);
            }
        }

        // Remplit la liste des participants pour un événement sélectionné
        private void RemplirParticipants()
        {
            try
            {
                string cmdText = "SELECT codeParticipant, nomPart || ' ' || prenomPart AS NomComplet " +
                                 "FROM Participants " +
                                 "JOIN Invites ON Participants.codeParticipant = Invites.codePart " +
                                 "WHERE Invites.codeEvent = @codeEvent";  
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdText, cnx);
                adapter.SelectCommand.Parameters.AddWithValue("@codeEvent", cboEvent.SelectedValue);

                if (ds.Tables.Contains("Participants"))
                {
                    ds.Tables["Participants"].Clear();  // Vide la table existante si elle existe
                }

                adapter.Fill(ds, "Participants");  // Remplit le DataSet avec les résultats de la requête
                dtParticipants = ds.Tables["Participants"];  
                dgvParticipants.DataSource = dtParticipants; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du remplissage des participants : " + ex.Message);
            }
        }

        // Remplit la liste des participants à inviter pour un événement spécifique
        private void RemplircboParticipants(int EventID)
        {
            try
            {
                cboInvite.Items.Clear();  // Vide la liste des participants à inviter

                string sql = "SELECT codeParticipant, nomPart || ' ' || prenomPart AS NomComplet " +
                             "FROM Participants " +
                             "WHERE codeParticipant NOT IN " +
                             "(SELECT codePart FROM Invites WHERE codeEvent = @codeEvent)";  
                SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@codeEvent", EventID);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboInvite.Items.Add(dr.GetString(1));  // Ajoute les participants non invités à la cbo
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du remplissage de la liste des participants : " + ex.Message);
            }
        }

        private void cboEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpInviter.Visible = false;  // Cache le groupe d'invitation
            RemplirParticipants();  // Remplit la liste des participants
        }

        private void btnAjoutInvite_Click(object sender, EventArgs e)
        {
            grpInviter.Visible = true;  // Affiche le groupe d'invitation
            RemplircboParticipants(Convert.ToInt32(cboEvent.SelectedValue));  // Remplit la liste des participants à inviter
        }

        private void btnInviter_Click(object sender, EventArgs e)
        {
            string nomComplet = cboInvite.SelectedItem.ToString();
            string[] nomPrenom = nomComplet.Split(' ');
            string nom = nomPrenom[0];
            string prenom = nomPrenom[1];

            string sql = "SELECT codeParticipant FROM Participants WHERE nomPart = @nom AND prenomPart = @prenom"; 
            SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@prenom", prenom);
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int codeParticipant = dr.GetInt32(0);
                dr.Close();

                sql = "SELECT codePart FROM Invites WHERE codePart = @codePart AND codeEvent = @codeEvent";  
                cmd = new SQLiteCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@codePart", codeParticipant);
                cmd.Parameters.AddWithValue("@codeEvent", cboEvent.SelectedValue);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Ce participant est déjà invité à cet événement.");
                }
                else
                {
                    dr.Close();
                    sql = "INSERT INTO Invites (codeEvent, codePart, login, mdp) VALUES (@codeEvent, @codePart, @login, @mdp)";  // Requête SQL pour inviter le participant
                    cmd = new SQLiteCommand(sql, cnx);
                    cmd.Parameters.AddWithValue("@codePart", codeParticipant);
                    cmd.Parameters.AddWithValue("@codeEvent", cboEvent.SelectedValue);
                    cmd.Parameters.AddWithValue("@login", nom.ToLower() + prenom.ToLower());
                    cmd.Parameters.AddWithValue("@mdp", "1234");
                    MessageBox.Show("Login : " + nom.ToLower() + prenom.ToLower() + "\nMot de passe : 1234");
                    int nb = cmd.ExecuteNonQuery();
                    if (nb == 1)
                    {
                        MessageBox.Show("Participant ajouté à la liste des invités.");
                        RemplirParticipants();  // Met à jour la liste des participants
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout du participant à la liste des invités.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Participant inconnu.");
            }
        }

        private void btnAjoutUser_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string mobile = txtMobile.Text;
            string email = txtMail.Text;
            if (!int.TryParse(txtNbParts.Text, out int nbParts))
            {
                MessageBox.Show("Nombre de participants invalide.");
                return;
            }

            try
            {
                string sqlCheck = "SELECT codeParticipant FROM Participants WHERE nomPart = @nom AND prenomPart = @prenom";  
                SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheck, cnx);
                cmdCheck.Parameters.AddWithValue("@nom", nom);
                cmdCheck.Parameters.AddWithValue("@prenom", prenom);
                SQLiteDataReader drCheck = cmdCheck.ExecuteReader();

                if (drCheck.Read())
                {
                    drCheck.Close();
                    MessageBox.Show("Ce participant est déjà enregistré.");
                    return;
                }
                drCheck.Close();

                string sqlInsert = "INSERT INTO Participants (nomPart, prenomPart, mobile, adresseMail, nbParts, solde) " +
                                   "VALUES (@nom, @prenom, @mobile, @email, @nbParts, 0)";  
                SQLiteCommand cmdInsert = new SQLiteCommand(sqlInsert, cnx);
                cmdInsert.Parameters.AddWithValue("@nom", nom);
                cmdInsert.Parameters.AddWithValue("@prenom", prenom);
                cmdInsert.Parameters.AddWithValue("@mobile", mobile);
                cmdInsert.Parameters.AddWithValue("@email", email);
                cmdInsert.Parameters.AddWithValue("@nbParts", nbParts);

                int rowsAffected = cmdInsert.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Participant ajouté à la base de données.");
                    RemplircboParticipants(Convert.ToInt32(cboEvent.SelectedValue));  // Met à jour la liste des participants à inviter
                    txtNom.Text = "";
                    txtPrenom.Text = "";
                    txtMobile.Text = "";
                    txtMail.Text = "";
                    txtNbParts.Text = "";
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du participant à la base de données.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du participant : " + ex.Message);
            }
        }
    }
}
