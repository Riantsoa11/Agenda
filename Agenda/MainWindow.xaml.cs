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
using Agenda.View;
namespace Agenda
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_Calendrier_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            Calendrier calendrier = new Calendrier();
            Window_Container.Children.Add(calendrier);
        }

        private void BTN_Contact_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            Contact contact = new Contact();
            Window_Container.Children.Add(contact);
        }

        private void BTN_Reseau_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            Reseau reseau = new Reseau();
            Window_Container.Children.Add(reseau);
        }

        private void BTN_Retour_Click_1(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
        }
    }
}
