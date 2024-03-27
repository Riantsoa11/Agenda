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

using Agenda_V1_mety.Service.DAO;
using Agenda_V1_mety.Agenda_tsiory;




namespace Agenda_V1_mety.View
{

    public partial class ContacPage : UserControl
    {
        // Déclaration d'un objet DAO_cantact
        DAO_cantact dAO_Contact; 

        // Constructeur de la classe ContacPage
        public ContacPage()
        {
            InitializeComponent();
            // Instanciation de l'objet DAO_cantact
            dAO_Contact = new DAO_cantact(); 
            // Définition de la source de données pour le DataGrid
            DG_Contact.ItemsSource = dAO_Contact.GetContacts();
        }

        // Boutton ajouter
        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterPage ajouterPage = new AjouterPage();
            this.Content = ajouterPage; 
        }

        // Boutton supprimer
        private void BTN_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            // Récupération du contact sélectionné dans le DataGrid
            Contact contact = (Contact)DG_Contact.SelectedItem;
            // Appel de la méthode de suppression du contact
            dAO_Contact.SupprimerContact(contact);
            // Actualisation de la source de données du DataGrid
            DG_Contact.ItemsSource = dAO_Contact.GetContacts(); 
            MessageBox.Show("Contact supprimé avec succès");
        }

        // Boutton modifier
        private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
        {
            // Récupération du contact sélectionné dans le DataGrid
            Contact contact = DG_Contact.SelectedItem as Contact;
            // Appel de la méthode de modification du contact
            dAO_Contact.modifieContact(contact);
            // Actualisation de la source de données du DataGrid
            DG_Contact.ItemsSource = dAO_Contact.GetContacts();
            MessageBox.Show("Contact modifié avec succès"); 
        }

        // Méthode appelée lors du clic sur le bouton "Famille"
        private void BTN_Famille_Click(object sender, RoutedEventArgs e)
        {
            // Filtrage des contacts par statut "Famille"
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Famille").ToList(); 
        }

        // Méthode appelée lors du clic sur le bouton "Amis"
        private void BTN_Amis_Click(object sender, RoutedEventArgs e)
        {
            // Filtrage des contacts par statut "Amis"
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Amis").ToList(); 
        }

        // Méthode appelée lors du clic sur le bouton "Collegue"
        private void BTN_College_Click(object sender, RoutedEventArgs e)
        {
            // Filtrage des contacts par statut "Collegue"
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Collegue").ToList(); 
        }

        // Boutton recherche
        private void BTN_Recherche_Click(object sender, RoutedEventArgs e)
        {
            // Recherche par nom
            var contactsParNom = dAO_Contact.RechercherContactParNom(TB_Recherche.Text); 

            // Si aucun contact n'est trouvé par nom, recherche par prénom
            if (contactsParNom.Any())
            {
                // Affichage des contacts trouvés par nom
                DG_Contact.ItemsSource = contactsParNom; 
            }
            else
            {
                // Recherche des contacts par prénom
                var contactsParPrenom = dAO_Contact.RechercherContactParPrenom(TB_Recherche.Text);
                // Affichage des contacts trouvés par prénom
                DG_Contact.ItemsSource = contactsParPrenom;
            }
        }

        private void BTN_Reseau_Click(object sender, RoutedEventArgs e)
        {
            // Récupération du contact sélectionné dans le DataGrid
            Contact contact = DG_Contact.SelectedItem as Contact;
            // Instanciation de la page ReseauContact
            ReseauContact reseauContact = new ReseauContact(contact);
            this.Content = reseauContact;

        }

    }
}
