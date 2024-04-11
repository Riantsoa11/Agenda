using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Agenda_V1_mety.View
{
    /// <summary>
    /// Logique d'interaction pour Calendrier.xaml
    /// </summary>
    public partial class Calendrier : UserControl
    {
        
        public ObservableCollection<Event> Events { get; set; }

        public Calendrier()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            DataContext = this;

            LoadEvents();
        }

        private void LoadEvents()
        {
            // Récupérer les événements du calendrier
            var events = DAO_Calendrier.GetEvents();
            foreach (var evt in events)
            {
                Events.Add(evt);
            }
        }

        private void RefreshButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //rafraichir les evenements
            Events.Clear();
            LoadEvents();
        }
    }

}
