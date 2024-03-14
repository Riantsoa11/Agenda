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
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : UserControl
    {
        public Ajouter()
        {
            InitializeComponent();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            //bouton retour qui va vers la page contact
            Contact contact = new Contact();
            this.Content = contact;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();

            //contact.Nom = TB_Nom.Text;
            //contact.Prenom = TB_Prenom.Text;
            //contact.Age = int.Parse(TB_Age.Text);
            //contact.Sexe = TB_Sexe.Text;
            //contact.Datenaissance = DateOnly.FromDateTime(TB_DateNaissance.SelectedDate.Value);
            //contact.Email = TB_Email.Text;
            //contact.Phone = TB_Phone.Text;
            //contact.Ville = TB_Ville.Text;
            //contact.Statut = TB_Statut.Text;
            //contact.Reseau = TB_Reseau.Text;

            //using (var context = new AgendaAndrianasoloharisonContext())
            //{
            //    context.Contacts.Add(contact);
            //    context.SaveChanges();
            //}
            //MessageBox.Show("Contact ajouté avec succès");

            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //Window.GetWindow(this).Close();
        }
    }
}
