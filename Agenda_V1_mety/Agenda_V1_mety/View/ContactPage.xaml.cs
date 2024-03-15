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

using Agenda_V1_mety.Agenda_tsiory;

namespace Agenda_V1_mety.View
{
    /// <summary>
    /// Logique d'interaction pour Contact.xaml
    /// </summary>
    public partial class ContacPage : UserControl
    {
        DAO_cantact dAO_Contact;
        public ContacPage()
        {
            InitializeComponent();
            dAO_Contact = new DAO_cantact();
            DG_Contact.ItemsSource = dAO_Contact.GetContacts();
        }



        public void Modifier_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Supprimer_Button_Click(object sender, RoutedEventArgs e)
        {
            var contact = DG_Contact.SelectedItem as Contact;
            dAO_Contact.SupprimerContact(contact.Idcontact);

        }

        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            //ajouter un contact quand je clique sur le bouton ajouter
            AjouterPage ajouterPage = new AjouterPage();
            this.Content = ajouterPage;

        }
    }
}
