using Agenda_V1_mety.Service.DAO; // Importation des espaces de noms nécessaires
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

using Agenda_V1_mety.Agenda_tsiory; // Importation des espaces de noms nécessaires

namespace Agenda_V1_mety.View
{
    // Définition de la classe ContacPage
    public partial class ContacPage : UserControl
    {
        DAO_cantact dAO_Contact; // Déclaration d'un objet DAO_cantact

        // Constructeur de la classe ContacPage
        public ContacPage()
        {
            InitializeComponent();
            dAO_Contact = new DAO_cantact(); // Instanciation de l'objet DAO_cantact
            DG_Contact.ItemsSource = dAO_Contact.GetContacts(); // Définition de la source de données pour le DataGrid
        }

        // Méthode appelée lors du clic sur le bouton de modification
        public void Modifier_Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = DG_Contact.SelectedItem as Contact; // Récupération du contact sélectionné dans le DataGrid
            dAO_Contact.modifieContact(contact); // Appel de la méthode de modification du contact
            DG_Contact.ItemsSource = dAO_Contact.GetContacts(); // Actualisation de la source de données du DataGrid
        }

        // Méthode appelée lors du clic sur le bouton d'ajout
        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterPage ajouterPage = new AjouterPage(); // Instanciation de la page d'ajout
            this.Content = ajouterPage; // Affichage de la page d'ajout
        }

        // Méthode appelée lors du clic sur le bouton de suppression
        private void BTN_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = (Contact)DG_Contact.SelectedItem; // Récupération du contact sélectionné dans le DataGrid
            dAO_Contact.SupprimerContact(contact); // Appel de la méthode de suppression du contact
            DG_Contact.ItemsSource = dAO_Contact.GetContacts(); // Actualisation de la source de données du DataGrid
            MessageBox.Show("Contact supprimé avec succès"); // Affichage d'un message de succès
        }

        // Méthode appelée lors du clic sur le bouton de modification
        private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = DG_Contact.SelectedItem as Contact; // Récupération du contact sélectionné dans le DataGrid
            dAO_Contact.modifieContact(contact); // Appel de la méthode de modification du contact
            DG_Contact.ItemsSource = dAO_Contact.GetContacts(); // Actualisation de la source de données du DataGrid
            MessageBox.Show("Contact modifié avec succès"); // Affichage d'un message de succès
        }

        // Méthode appelée lors du clic sur le bouton "Famille"
        private void BTN_Famille_Click(object sender, RoutedEventArgs e)
        {
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Famille").ToList(); // Filtrage des contacts par statut "Famille"
        }

        // Méthode appelée lors du clic sur le bouton "Amis"
        private void BTN_Amis_Click(object sender, RoutedEventArgs e)
        {
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Amis").ToList(); // Filtrage des contacts par statut "Amis"
        }

        // Méthode appelée lors du clic sur le bouton "Collegue"
        private void BTN_College_Click(object sender, RoutedEventArgs e)
        {
            DG_Contact.ItemsSource = dAO_Contact.GetContacts().Where(c => c.Statut == "Collegue").ToList(); // Filtrage des contacts par statut "Collegue"
        }

        // Méthode appelée lors du clic sur le bouton de recherche
        private void BTN_Recherche_Click(object sender, RoutedEventArgs e)
        {
            // Recherche par nom
            var contactsParNom = dAO_Contact.RechercherContactParNom(TB_Recherche.Text); // Recherche des contacts par nom

            // Si aucun contact n'est trouvé par nom, recherche par prénom
            if (contactsParNom.Any())
            {
                DG_Contact.ItemsSource = contactsParNom; // Affichage des contacts trouvés par nom
            }
            else
            {
                var contactsParPrenom = dAO_Contact.RechercherContactParPrenom(TB_Recherche.Text); // Recherche des contacts par prénom
                DG_Contact.ItemsSource = contactsParPrenom; // Affichage des contacts trouvés par prénom
            }
        }

        private void BTN_Reseau_Click(object sender, RoutedEventArgs e)
        {
            //je veux afficher la reseau_sociaux du contact selectioner dans la liste des contacts dans la page ReseauContact
            Contact contact = DG_Contact.SelectedItem as Contact; // Récupération du contact sélectionné dans le DataGrid
            ReseauContact reseauContact = new ReseauContact(contact); // Instanciation de la page ReseauContact
            this.Content = reseauContact; // Affichage de la page ReseauContact

        }
    }
}
