using Agenda.Service.DAO;
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

namespace Agenda.View
{
    /// <summary>
    /// Logique d'interaction pour Contact.xaml
    /// </summary>
    public partial class Contact : UserControl
    {
        DAO_contact dAO_Contact;
        public Contact()
        {
            InitializeComponent();
            dAO_Contact = new DAO_contact();
            DAO_contact.ItemsSource = dAO_Contact.GetContacts();
        }
    }
}
