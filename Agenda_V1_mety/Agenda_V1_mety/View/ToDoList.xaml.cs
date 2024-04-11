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
using Agenda_V1_mety.View;
using Agenda_V1_mety.Service.DAO;



namespace Agenda_V1_mety.View
{
    /// <summary>
    /// Logique d'interaction pour ToDoList.xaml
    /// </summary>
    public partial class ToDoList : UserControl
    {
        // Déclaration d'un objet DAO_Task
        private DAO_Todolist dAO_Todolist;
        private DAO_Task dAO_Task;
        public ToDoList()
        {
            InitializeComponent();
            dAO_Todolist = new DAO_Todolist();
            DG_Todolist.ItemsSource = dAO_Todolist.GetTodolists();
            
        }

        private void BTN_Task_Click(object sender, RoutedEventArgs e)
        {
            //Container.Children.Clear();
            //PageTask pageTask = new PageTask();
            //Container.Children.Add(pageTask);
            //si aucun todolist n'est selectionné on affiche un message d'erreur
            if (!dAO_Todolist.CheckTodolistSelectionne(DG_Todolist.SelectedItem))
            {
                MessageBox.Show("Veuillez selectionner une todolist");
                return;
            }
            // Récupération du todolist sélectionné dans le DataGrid
            Todolist todolist = (Todolist)DG_Todolist.SelectedItem;
            // Instanciation de la page PageTask
            PageTask pageTask = new PageTask(todolist);
            Container.Children.Add(pageTask);
            


        }

        private void BTN_Todolist_Click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
            PageToDoList pageToDoList = new PageToDoList();
            Container.Children.Add(pageToDoList);
        }

        private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
        {
            //si aucun todolist n'est selectionné on affiche un message d'erreur
            if (!dAO_Todolist.CheckTodolistSelectionne(DG_Todolist.SelectedItem))
            {
                MessageBox.Show("Veuillez selectionner une todolist");
                return;
            }


            // Récupération du todolist sélectionné dans le DataGrid
            Todolist todolist = (Todolist)DG_Todolist.SelectedItem;
            //modification de la todolist
            dAO_Todolist.modifieTodolist(todolist);
            // Mise à jour du DataGrid
            DG_Todolist.ItemsSource = dAO_Todolist.GetTodolists();

            //affichage reussi
            MessageBox.Show("Todolist modifié avec succès");
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            //si aucun todolist n'est selectionné on affiche un message d'erreur
            if (!dAO_Todolist.CheckTodolistSelectionne(DG_Todolist.SelectedItem))
            {
                MessageBox.Show("Veuillez selectionner une todolist");
                return;
            }

            // Récupération du todolist sélectionné dans le DataGrid
            Todolist todolist = (Todolist)DG_Todolist.SelectedItem;
            // Suppression du todolist
            dAO_Todolist.SupprimerTodolist(todolist);
            // Mise à jour du DataGrid
            DG_Todolist.ItemsSource = dAO_Todolist.GetTodolists();

            MessageBox.Show("Todolist supprimé avec succès");
        }
    }
}
