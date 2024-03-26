using Agenda_V1_mety.Agenda_tsiory;
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
    /// Logique d'interaction pour ReseauContact.xaml
    /// </summary>
    public partial class ReseauContact : UserControl
    {

       
        private Contact contact; // Ajoutez un champ pour stocker le contact

        // Créez un constructeur prenant un argument de type Contact
        public ReseauContact(Contact contact)
        {
            InitializeComponent();
            this.contact = contact; // Enregistrez le contact passé en argument
            AfficherInfosContact();
        }

        // Méthode pour afficher les informations du contact dans votre page
        private void AfficherInfosContact()
        {
            TB_Name.Text = contact.Nom;
            TB_Prenom.Text = contact.Prenom;
            TB_Reseausociaux.Text = contact.Reseau;
            
  
        }
        private void BTN_Retor_Click(object sender, RoutedEventArgs e)
        {
            ContacPage contact = new ContacPage();
            this.Content = contact;
        }
    }
}
