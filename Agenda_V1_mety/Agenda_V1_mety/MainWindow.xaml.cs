using Agenda_V1_mety.Service.DAO;
using Agenda_V1_mety.View;
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

namespace Agenda_V1_mety
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DAO_cantact dAO_Cantact;
        public MainWindow()
        {
            InitializeComponent();

            dAO_Cantact = new DAO_cantact();

            if (dAO_Cantact.CheckDatabase())
            {
                MessageBox.Show("Database Connected");
            }
            else
            {
                MessageBox.Show("DatabaseNotConnected");
                BoutonStatut(false); 
            }

        }
        private void BoutonStatut(bool estActif)
        {
            BTN_Contact.IsEnabled = estActif;
            BTN_Calendrier.IsEnabled = estActif;
            BTN_ToDoList.IsEnabled = estActif;
        }       

        private void BTN_Contact_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            ContacPage contact = new ContacPage();
            Window_Container.Children.Add(contact);
        }

        private void BTN_Retour_Click_1(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
        }

        private void BTN_Calendrier_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            Calendrier calendrier = new Calendrier();
            Window_Container.Children.Add(calendrier);
        }

        private void BTN_ToDoList_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            ToDoList toDoList = new ToDoList();
            Window_Container.Children.Add(toDoList);
        }
    }
}
