using System;
using System.Data;
using System.Windows.Forms;

namespace Saé
{
    // Contrôle utilisateur pour afficher les détails d'un événement
    public partial class ucEvent1a1 : UserControl
    {
        public ucEvent1a1()
        {
            InitializeComponent();  
        }

        // Constructeur du contrôle utilisateur avec données de l'événement
        public ucEvent1a1(DataTable eventData)
        {
            InitializeComponent();  
            LoadEventData(eventData);  
        }

        private void LoadEventData(DataTable eventData)
        {
            if (eventData.Rows.Count > 0)  // Vérifie si le DataTable contient des lignes
            {
                DataRow row = eventData.Rows[0];  
                lblNumEvent.Text = row["codeEvent"].ToString();  
                lblNum.Text = row["codeEvent"].ToString();  
                lblCreateur.Text = row["codeCreateur"].ToString();  
                lblIntitule.Text = row["titreEvent"].ToString(); 
                lblDesc.Text = row["description"].ToString(); 
                lblDateDeb.Text = row["dateDebut"].ToString();  
                lblDateFin.Text = row["dateFin"].ToString();  
                chkSolde.Checked = row["soldeON"].ToString() == "1";  // Définit l'état de la case à cocher en fonction de la valeur de soldeON
            }
            else
            {
                MessageBox.Show("Aucun événement trouvé avec cet ID.");  // Affiche un message si aucun événement n'est trouvé
            }
        }
    }
}
