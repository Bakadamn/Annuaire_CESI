using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Annuaire_CESI
{
    /// <summary>
    /// Fenetre d'ajout manuel d'un contact
    /// </summary>
    public partial class AjoutContact : Window
    {
        public Contact ContactCree = null;
        public AjoutContact()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructeur de la fenetre en cas de modification de contact
        /// </summary>
        /// <param name="contact"></param>
        public AjoutContact(Contact contact)
        {
            InitializeComponent();
            TBNom.Text = contact.Nom;
            TBPrenom.Text = contact.Prenom;
            TBService.Text = contact.Service;
            TBTelephone.Text = contact.Telephone;
            TBDate.SelectedDate = contact.DateEntree;

            BtnAjout.Content = "Modifier";
        }

        private void BtnAjout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToDateTime(TBDate.Text);
            }
            catch
            {
                MessageBox.Show("Veuillez renseigner la date d'entrée");
                return;
            }


            ContactCree = new Contact(
                TBNom.Text,
                TBPrenom.Text,
                TBTelephone.Text,
                TBService.Text,
                TBDate.SelectedDate.Value.Date == null ? DateTime.Now : TBDate.SelectedDate.Value.Date
                );

            Close();
        }

        private void BtnAnnul_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
