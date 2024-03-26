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
        public ReseauContact()
        {
            InitializeComponent();
        }

        private void BTN_Retor_Click(object sender, RoutedEventArgs e)
        {
            ContacPage contact = new ContacPage();
            this.Content = contact;
        }
    }
}
