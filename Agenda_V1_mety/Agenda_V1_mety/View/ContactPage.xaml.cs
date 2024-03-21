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
            Contact contact = DG_Contact.SelectedItem as Contact;
            dAO_Contact.modifieContact(contact);
            DG_Contact.ItemsSource = dAO_Contact.GetContacts();
        }

        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterPage ajouterPage = new AjouterPage();
            this.Content = ajouterPage;

        }

        private void BTN_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = (Contact)DG_Contact.SelectedItem;
            dAO_Contact.SupprimerContact(contact);
            DG_Contact.ItemsSource = dAO_Contact.GetContacts();
        }

        private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = DG_Contact.SelectedItem as Contact;
            dAO_Contact.modifieContact(contact);
            DG_Contact.ItemsSource = dAO_Contact.GetContacts();
            MessageBox.Show("Contact modifié avec succès");
        }

        private void BTN_Famille_Click(object sender, RoutedEventArgs e)
        {
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Famille").ToList();
        }

        private void BTN_Amis_Click(object sender, RoutedEventArgs e)
        {
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Amis").ToList();
        }

        private void BTN_College_Click(object sender, RoutedEventArgs e)
        {
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Collegue").ToList();
        }

        private void BTN_Recherche_Click(object sender, RoutedEventArgs e)
        {
            DG_Contact.ItemsSource = dAO_Contact.RechercherContactParNom(TB_Recherche.Text);
            DG_Contact.ItemsSource = dAO_Contact.RechercherContactParPrenom(TB_Recherche.Text);
        }
        
    }
}
