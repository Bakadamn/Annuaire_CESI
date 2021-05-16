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

        public MainWindow()
        {
            InitializeComponent();
            


            //Ici on initialise la combobox afin qu'elle affiche tout les TypeFiltre qu'on a défini dans l'enum
            CBTypeFiltre.ItemsSource = Enum.GetNames(typeof(TypeFiltre));

            CBTypeFiltre.SelectedIndex = 0;

            

            /* //Ajout simple
            using (ContexteSQL db = new ContexteSQL())
            {
                db.Contact.Add(new Contact()
                {
                    Nom = "ahaz",
                    Prenom = "JouetTEST",
                     DateEntree = DateTime.Now,
                     Service =" ahraer",
                     Telephone = "0737337363"

                });
                //db.SaveChanges();
            }
            */

            //Par défaut au lancement de l'application on fait un Select all de la database dans la datagrid
            GetFactory factory = new GetFactory();

            Requete requete = factory.CreerRequete();

            DataGridCommande.ItemsSource = requete.ResultatGet;


        }


        /// <summary>
        /// Fonction sans paramètre, fonctionne selon le pattern factory
        /// </summary>
        private void RequeteSQL()
        {
            RequeteFactory factory = null;

            
            TypeFiltre typeFiltre = (TypeFiltre)Enum.Parse(typeof(TypeFiltre), CBTypeFiltre.SelectedItem.ToString());

            if (NouveauContact!=null) //si NouveauContact !=null alors il y a un contact à ajouter (add)
            {
                factory = new AddFactory(NouveauContact);
                NouveauContact = null;
            }
            else if(typeFiltre != TypeFiltre.Aucun && CBTypeFiltre.SelectedItem != null) // si il y a un filtre ajouter alors on recherche avec filtre (getBy)
            {
                factory = new GetByFactory(typeFiltre, TBFiltre.Text);  
            }
            else //on selectionne tous les contacts (get)
            {
                factory = new GetFactory();
            }

            Requete requete = factory.CreerRequete();
            DataGridCommande.ItemsSource = requete.ResultatGet;
        }

        private void BtnRecherche_Click(object sender, RoutedEventArgs e)
        {
            RequeteSQL();
        }

        private void BtnClickUtilisateur(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact("bonjour","bonjour2","telephone","service de guerre", DateTime.Now);
            NouveauContact = contact;
            RequeteSQL();
        }

        private async void BtnClickAPI(object sender, RoutedEventArgs e)
        {
            NouveauContact = await AppelAPI.AppelApiAsync();
            RequeteSQL();

        }
    }
}
