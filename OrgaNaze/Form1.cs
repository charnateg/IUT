using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Saé
{
    public partial class frmMenu : Form
    {
        bool barNavExtention = true;  // Indique si la barre de navigation est étendue
        private bool isHovered = false;  // Indique si un bouton est survolé
        private Panel titleBar;  // Titre du formulaire
        private Button closeButton;  // Bouton de fermeture
        private Button minimizeButton;  // Bouton de minimisation
        private Point pnlMenuLocation;  // Position initiale des dépenses

        public frmMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;  // Supprime le contour supérieur

            // Initialise et configure la barre de titre
            titleBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.FromArgb(24, 30, 54)
            };
            titleBar.Paint += TitleBar_Paint;  
            this.Controls.Add(titleBar);  
            titleBar.MouseDown += TitleBar_MouseDown; 

            // Initialise et configure le bouton de minimisation
            minimizeButton = new Button
            {
                Text = "-",
                Dock = DockStyle.Right,
                Width = 30,
            };
            minimizeButton.Paint += Button_Paint; 
            minimizeButton.Click += (s, e) => this.WindowState = FormWindowState.Minimized; 
            titleBar.Controls.Add(minimizeButton); 

            // Initialise et configure le bouton de fermeture
            closeButton = new Button
            {
                Text = "X",
                Dock = DockStyle.Right,
                Width = 30,
            };
            closeButton.Paint += Button_Paint;  
            closeButton.Click += (s, e) => this.Close();  
            titleBar.Controls.Add(closeButton); 

            pnlMenuLocation = pnlMenu.Location;  
        }

        // Ecrit le titre sur le contour supérieur
        private void TitleBar_Paint(object sender, PaintEventArgs e)
        {
            using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                e.Graphics.DrawString("    OrgaNaze", titleFont, Brushes.White, new Point(10, 5));
            }
        }

        // Permet le déplacement de la fenêtre 
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Personnalisation des boutons
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.DarkBlue, Color.LightBlue, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }
                using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center })
                {
                    e.Graphics.DrawString(btn.Text, btn.Font, Brushes.White, btn.ClientRectangle, sf);
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);  // Envoie un message à la fenêtre spécifiée

        private const int WM_NCLBUTTONDOWN = 0xA1;  // Clic gauche
        private const int HT_CAPTION = 0x2;  // Code du contour supérieur



        private void frmMenu_Load(object sender, EventArgs e)
        {
            btnAjout.Paint += new PaintEventHandler(btnAjout_Paint);
            btnAjout.MouseEnter += new EventHandler(btnAjout_MouseEnter);
            btnAjout.MouseLeave += new EventHandler(btnAjout_MouseLeave);
        }

        // Clic sur le bouton ajout pour afficher le panneau d'ajout de dépense
        private void btnAjout_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
            pnlMenu.Controls.Clear();

            ucAjouterDepense ucAjoutDepense = new ucAjouterDepense();
            ucAjoutDepense.AnnulerClicked += UcAjoutDepense_AnnulerClicked;
            pnlMenu.Controls.Add(ucAjoutDepense);

            pnlMenu.Width = ucAjoutDepense.Width;
            pnlMenu.Height = ucAjoutDepense.Height;
        }

        // Clic sur le bouton annuler
        private void UcAjoutDepense_AnnulerClicked(object sender, EventArgs e)
        {
            pnlMenu.Visible = false;
            pnlMenu.Controls.Clear();
        }

        // Personnalisation du bouton d'ajout
        private void btnAjout_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;

            Color fillColor = isHovered ? Color.CornflowerBlue : btn.BackColor;
            g.Clear(fillColor);

            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath graphPath = GetRoundRectPath(rect, 20);

            btn.Region = new Region(graphPath);

            TextRenderer.DrawText(g, btn.Text, btn.Font, rect, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Entrée de la souris sur le bouton d'ajout
        private void btnAjout_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            btnAjout.Invalidate();
        }

        // Sortie de la souris sur le bouton d'ajout
        private void btnAjout_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            btnAjout.Invalidate();
        }

        // Arrondi les coins des boutons
        private GraphicsPath GetRoundRectPath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        // Déclenchement du timer pour l'extension de la barre de navigation
        private void barNavTimer_Tick(object sender, EventArgs e)
        {
            if (barNavExtention)
            {
                barNavTimer.Stop();
                navBar.Width -= 150;
                barNavExtention = false;
            }
            else
            {
                barNavTimer.Stop();
                navBar.Width += 150;
                barNavExtention = true;
            }
        }

        // Clic sur l'icône menu pour démarrer le timer
        private void ptbMenu_Click(object sender, EventArgs e)
        {
            barNavTimer.Start();
        }

        // Clic sur le bouton des dépenses pour afficher le panneau des dépenses
        private void btnDepenses_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
            pnlMenu.Controls.Clear();

            ucDepenses ucDepense = new ucDepenses();
            pnlMenu.Controls.Add(ucDepense);

            pnlMenu.Width = ucDepense.Width;
            pnlMenu.Height = ucDepense.Height;

            int navBarWidth = navBar.Width;
            int formWidth = this.ClientSize.Width;
            int ucWidth = ucDepense.Width;

            pnlMenu.Location = new Point((formWidth - ucWidth + navBarWidth) / 2, 30);
        }

        // Clic sur le bouton des participants pour afficher le panneau des participants
        private void btnParticipants_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
            pnlMenu.Controls.Clear();

            ucParticipants ucParticipant = new ucParticipants();
            pnlMenu.Controls.Add(ucParticipant);

            pnlMenu.Width = ucParticipant.Width;
            pnlMenu.Height = ucParticipant.Height;

            int navBarWidth = navBar.Width;
            int formWidth = this.ClientSize.Width;
            int ucWidth = ucParticipant.Width;

            pnlMenu.Location = new Point((formWidth - ucWidth + navBarWidth) / 2, 30);
        }

        // Clic sur le bouton des événements pour afficher le panneau des événements
        private void btnEvenements_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
            pnlMenu.Controls.Clear();

            ucEvenements ucEvenement = new ucEvenements();
            pnlMenu.Controls.Add(ucEvenement);

            pnlMenu.Width = ucEvenement.Width;
            pnlMenu.Height = ucEvenement.Height;

            int navBarWidth = navBar.Width;
            int formWidth = this.ClientSize.Width;
            int ucWidth = ucEvenement.Width;

            pnlMenu.Location = new Point((formWidth - ucWidth + navBarWidth) / 2, 30);
        }

        // Clic sur le bouton du bilan pour afficher le panneau du bilan
        private void btnBilan_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = true;
            pnlMenu.Controls.Clear();

            ucBilan ucBilan = new ucBilan();
            pnlMenu.Controls.Add(ucBilan);

            pnlMenu.Width = ucBilan.Width;
            pnlMenu.Height = ucBilan.Height;

            int navBarWidth = navBar.Width;
            int formWidth = this.ClientSize.Width;
            int ucWidth = ucBilan.Width;

            pnlMenu.Location = new Point((formWidth - ucWidth + navBarWidth) / 2, 30);
        }

        // Clic sur le bouton d'accueil pour réinitialiser le panneau de menu
        private void btnAccueil_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = false;
            pnlMenu.Controls.Clear();
            pnlMenu.Location = pnlMenuLocation;
        }
    }
}
