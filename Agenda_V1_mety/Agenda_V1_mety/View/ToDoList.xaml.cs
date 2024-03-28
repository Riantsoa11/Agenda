using Agenda_V1_mety.Agenda_tsiory;
using Agenda_V1_mety.Service.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour ToDoList.xaml
    /// </summary>
    public partial class ToDoList : UserControl
    {
        // Déclaration d'un objet DAO_Task
        private DAO_Task dAO_Task;
        public ToDoList()
        {
            InitializeComponent();
            // Instanciation de l'objet DAO_Task
            dAO_Task = new DAO_Task();
        }

        private void BTN_Task_Click(object sender, RoutedEventArgs e)
        {
            // Afficher le popup
            popup1.IsOpen = true;
        }

        private void ValideTask_Click(object sender, RoutedEventArgs e)
        {
            // Traiter les données du TextBox
            string nomTask = TB_nomTask.Text;
            string descriptionTask = TB_nomDescription.Text;
            Task task = new Task
            {
                Nomtask = TB_nomTask.Text,
                Description = TB_nomDescription.Text
            };
            dAO_Task.AddTask(task);
            // Fermer le popup
            popup1.IsOpen = false;
            
        }

        private void BTN_Todolist_Click(object sender, RoutedEventArgs e)
        {
            popup2.IsOpen = true;
        }

        private void ValideTodolisk_Click(object sender, RoutedEventArgs e)
        {
            // Traiter les données du TextBox
            string nomTask = TB_nomTask.Text;
            string descriptionTask = TB_nomDescription.Text;
            Task task = new Task
            {
                Nomtask = TB_nomTask.Text,
                Description = TB_nomDescription.Text
            };
            dAO_Task.AddTask(task);
            // Fermer le popup
            popup1.IsOpen = false;

        }
    }
}
