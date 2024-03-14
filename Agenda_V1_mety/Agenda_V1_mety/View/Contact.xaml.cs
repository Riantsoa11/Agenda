using Agenda_V1_mety.Service.DAO;
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

namespace Agenda_V1_mety.View
{
    /// <summary>
    /// Logique d'interaction pour Contact.xaml
    /// </summary>
    public partial class Contact : UserControl
    {
        DAO_cantact dAO_Contact;
        public Contact()
        {
            InitializeComponent();
            dAO_Contact = new DAO_cantact();
            DAO_contact.ItemsSource = dAO_Contact.GetContacts();
        }



        private void Modifier_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Supprimer_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            //bouton ajouter qui va vers la page ajouter
            Ajouter ajouter = new Ajouter();
            this.Content = ajouter;
        }
    }
}
