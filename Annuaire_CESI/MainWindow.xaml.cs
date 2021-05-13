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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Annuaire_CESI.SQLFactory;
using Annuaire_CESI.SQLFactory.Factorys;

namespace Annuaire_CESI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            using (ContexteSQL db = new ContexteSQL())
            {
                db.Contact.Add(new Contact()
                {
                    Nom = "ah",
                    Prenom = "oh",
                    DateEntree = DateTime.Now,
                    Service = "service 2",
                    Telephone = "02 35 23 44 53"
                }) ;

                db.SaveChanges();

            

            }





            GetFactory factory = null;

            factory = new SQLFactory.Factorys.GetFactory();

            SQLFactory.Requete requete = factory.CreerRequete();

            DataGridCommande.ItemsSource = requete.ResultatGet;
            
        }
    }
}
