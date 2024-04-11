using Agenda_V1_mety.Agenda_tsiory;
using Agenda_V1_mety.Service.DAO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Agenda_V1_mety.View
{
    /// <summary>
    /// Logique d'interaction pour PageTask.xaml
    /// </summary>
    public partial class PageTask : UserControl
    {
        private Todolist todolist;
        private DAO_Task dAO_Task;

        

        public PageTask()
        {
            //InitializeComponent();
            //dAO_Task = new DAO_Task();  
            //DG_Task.ItemsSource = dAO_Task.GetTasks(todolist);
        }
        
        public PageTask(int TodolistId)
        {
            InitializeComponent();
            dAO_Task = new DAO_Task();
            DG_Task.ItemsSource = dAO_Task.GetTasksBytodolistId(TodolistId);
            TB_IdTodoList.Text = TodolistId.ToString();
        }


        public PageTask(Todolist todolist)
        {
            this.todolist = todolist;
        }

        private void BTN_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            //si aucune tache n'est selectionnée
            if (DG_Task.SelectedItem == null)
            {
                MessageBox.Show("Veuillez selectionner une tache");
                return;
            }

            //methode pour supprimer une tache selectionnée
            Agenda_tsiory.Task task = (Agenda_tsiory.Task)DG_Task.SelectedItem;
            dAO_Task.DeleteTask(task);
            DG_Task.ItemsSource = dAO_Task.GetTasksBytodolistId(int.Parse(TB_IdTodoList.Text));
            MessageBox.Show("Tache supprimée avec succès");

        }

        private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            //methode pour acceder a la page d'ajout de tache
            Container.Children.Clear();
            AjouterTask ajouterTask = new AjouterTask(int.Parse(TB_IdTodoList.Text));
            Container.Children.Add(ajouterTask);

        }
    }
}
