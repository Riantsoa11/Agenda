using Agenda_V1_mety.Model;
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
using Agenda_V1_mety.Model;

namespace Agenda_V1_mety.View
{
    /// <summary>
    /// Logique d'interaction pour Parametre.xaml
    /// </summary>
    public partial class Parametre : UserControl
    {
        ConnectionString_Manager connectionString_Manager;
        public Parametre()
        {
            InitializeComponent();
            connectionString_Manager = new ConnectionString_Manager();
        }

       

        private void BTN_valide_Click(object sender, RoutedEventArgs e)
        {
            connectionString_Manager.host = TB_NameDB.Text;
            connectionString_Manager.database = TB_AdressIP.Text;
            connectionString_Manager.user = TB_NomUtilisateur.Text;
            connectionString_Manager.password = TB_Mdp.Text;

            //save the new connection string
            connectionString_Manager.Save();
            MessageBox.Show("Changement effectué avec succès");

        }

        
    }
}
