using System;
using System.Threading.Tasks;
using System.Windows;
using Annuaire_CESI.SQLFactory;
using Annuaire_CESI.SQLFactory.Factorys;


namespace Annuaire_CESI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Contact NouveauContact;
        private Contact ContactSelectionne;
        private Contact ContactModifie;
        private int IdASupprimer = -1;


        public MainWindow()
        {
            InitializeComponent();

            DataGridCommande.SelectionChanged += DataGridCommande_SelectionChanged;
            


            //Ici on initialise la combobox afin qu'elle affiche tout les TypeFiltre qu'on a défini dans l'enum
            CBTypeFiltre.ItemsSource = Enum.GetNames(typeof(TypeFiltre));

            CBTypeFiltre.SelectedIndex = 0;

            RequeteSQL();

        }

        /// <summary>
        /// Event qui met a jour les infos affiché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridCommande_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           if(DataGridCommande.SelectedItem !=null)
            {
                ContactSelectionne = (Contact)DataGridCommande.SelectedItem;

                LabelNom.Content = "Nom : " + ContactSelectionne.Nom;
                LabelPrenom.Content = "Prénom : " + ContactSelectionne.Prenom;
                LabelDate.Content = "Date : " + ContactSelectionne.DateEntree.ToString();
                LabelService.Content = "Service : " + ContactSelectionne.Service;

            }
        }


        

        /// <summary>
        /// Bouton de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRecherche_Click(object sender, RoutedEventArgs e)
        {
            RequeteSQL();
        }

        /// <summary>
        /// Bouton de création manuelle d'un contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClickUtilisateur(object sender, RoutedEventArgs e)
        {
            AjoutContact fenetreAjoutContact = new AjoutContact();
            fenetreAjoutContact.ShowDialog();

            if(fenetreAjoutContact.ContactCree!=null)
            NouveauContact = fenetreAjoutContact.ContactCree;

            RequeteSQL();
        }

        /// <summary>
        /// Bouton d'appel de l'api pour créer un contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnClickAPI(object sender, RoutedEventArgs e)
        {
            try
            {
                NouveauContact = await AppelAPI.AppelApiAsync();

                RequeteSQL();

            }
            catch (Exception exc)
            {
                TraceErreur.Log(exc);
                MessageBox.Show("Erreur lors de la tentative de connection");
            }
        }


        private void BtnSupprimerClick(object sender, RoutedEventArgs e)
        {
            IdASupprimer = ContactSelectionne.ContactID;
            RequeteSQL();
            
        }

        private void BtnModifierClick(object sender, RoutedEventArgs e)
        {
            AjoutContact fenetreAjoutContact = new AjoutContact(ContactSelectionne);
            fenetreAjoutContact.ShowDialog();

            if (fenetreAjoutContact.ContactCree != null)
                ContactModifie = fenetreAjoutContact.ContactCree;

            RequeteSQL();

        }

        /// <summary>
        /// La fonction qui appelle les factorys SQL 
        /// "simule" une situation dans laquelle utiliser le design pattern Factory
        /// </summary>
        private void RequeteSQL()
        {
            RequeteFactory factory;


            TypeFiltre typeFiltre = (TypeFiltre)Enum.Parse(typeof(TypeFiltre), CBTypeFiltre.SelectedItem.ToString());

            //si NouveauContact !=null alors il y a un contact à ajouter (add)
            if (NouveauContact != null)
            {
                factory = new AddFactory(NouveauContact);
                NouveauContact = null;
            }
            //Si un id a supprimer est renseigné on supprime le contact lié (delete)
            else if (IdASupprimer!=-1)
            {
                factory = new DeleteFactory(IdASupprimer);
                IdASupprimer = -1;
            }
            //si ContactModifie != null alors on modifie le contact (modifier)
            else if (ContactModifie!=null)
            {
                factory = new ModifierFactory(ContactModifie);
                ContactModifie = null;
            }
            // si il y a un filtre ajouter alors on recherche avec filtre (getBy)
            else if (typeFiltre != TypeFiltre.Aucun && CBTypeFiltre.SelectedItem != null) 
            {
                factory = new GetByFactory(typeFiltre, TBFiltre.Text);
            }
            //on selectionne tous les contacts (get)
            else
            {
                factory = new GetFactory();
            }

            Requete requete = factory.CreerRequete();
            DataGridCommande.ItemsSource = requete.ResultatGet;
        }

  
    }
}
