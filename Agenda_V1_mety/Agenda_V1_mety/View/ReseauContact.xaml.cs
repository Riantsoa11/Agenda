using Agenda_V1_mety.Agenda_tsiory;
using Agenda_V1_mety.Service.DAO;
using MaterialDesignColors;
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

    public partial class ReseauContact : UserControl
    {

        // Ajoutez un champ pour stocker le contact
        private Contact contact;
        private DAO_ReseauSociaux DAO_ReseauSociaux;
        private ReseauSociaux reseauSociaux;
        
        // Constructeur de type Contact pour initialiser le contact
        public ReseauContact(Contact contact)
        {
            InitializeComponent();
            this.contact = contact; // Enregistrez le contact passé en argument
            AfficherInfosContact();
            DAO_ReseauSociaux = new DAO_ReseauSociaux();
        }

        public ReseauContact(ReseauSociaux reseauSociaux)
        {
            InitializeComponent();
            this.reseauSociaux = reseauSociaux; // Enregistrez le contact passé en argument
            AfficherInfosContact();
        }

        //afficher les informations du contact et son reseau social
        private void AfficherInfosContact()
        {
            DAO_ReseauSociaux = new DAO_ReseauSociaux();
            var reseauSociaux = DAO_ReseauSociaux.GetReseauSociauxByIdcontact(contact.Idcontact);


            if (reseauSociaux == null)
            {
                TB_Liens.Text = "Aucune";
                TB_Profil.Text = "Aucune";
            }
            else
            {
                TB_Liens.Text = reseauSociaux.Liens;
                TB_Profil.Text = reseauSociaux.Profil;
            }

            TB_Name.Text = contact.Nom;
            TB_Prenom.Text = contact.Prenom;
            TB_Reseausociaux.Text = contact.Reseau;


        }


        //Bouton pour retourner à la page de contact
        private void BTN_Retour_Click(object sender, RoutedEventArgs e)
        {
            ContacPage contact = new ContacPage();
            this.Content = contact;
        }

        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            //Ajouter un reseau social au contact selectionné si son pfofil et son lien sont null
            if (TB_Liens.Text == null || TB_Profil.Text == null)
            {
                MessageBox.Show("Veuillez remplir les champs");
            }
            else
            {
                ReseauSociaux reseauSociaux = new ReseauSociaux
                {
                    Liens = TB_Liens.Text,
                    Profil = TB_Profil.Text,
                    ContactIdcontact = contact.Idcontact
                };
                DAO_ReseauSociaux.AjouterReseauSociaux(reseauSociaux);
                MessageBox.Show("Reseau social ajouté avec succès");
            }
        }

        private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
        {
            //modifier le profil et le lien du reseau social du contact selectionné
            if (TB_Liens.Text == null || TB_Profil.Text == null)
            {
                MessageBox.Show("Veuillez remplir les champs");
            }
            else
            {
                ReseauSociaux reseauSociaux = new ReseauSociaux
                {
                    Liens = TB_Liens.Text,
                    Profil = TB_Profil.Text,
                    ContactIdcontact = contact.Idcontact
                };
                DAO_ReseauSociaux.modifieReseauSociaux(reseauSociaux);
                MessageBox.Show("Reseau social modifié avec succès");
            }
        }
    }
}
