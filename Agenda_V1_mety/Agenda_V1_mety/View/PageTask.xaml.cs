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
    /// Logique d'interaction pour PageTask.xaml
    /// </summary>
    public partial class PageTask : UserControl
    {
        private Todolist todolist;

        public PageTask()
        {
            InitializeComponent();
        }

        public PageTask(Todolist todolist)
        {
            this.todolist = todolist;
        }

        private void BTN_Supprimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
