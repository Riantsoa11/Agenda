using Agenda_V1_mety.Agenda_tsiory;
using System.Windows;
using System.Windows.Controls;




namespace Agenda_V1_mety.View
{
    /// <summary>
    /// Logique d'interaction pour AjouterTask.xaml
    /// </summary>
    public partial class AjouterTask : UserControl
    {
        Task task;
        int id;
        public AjouterTask()
        {
            InitializeComponent();
            task = new Task();
        }

        public AjouterTask(int idtodolist)
        {
            InitializeComponent();
            task = new Task();
            id = idtodolist;
        }

        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            //recuperer les elements saisis
            task.Nomtask = TB_taskDesc.Text;
            task.Description = TB_Description.Text; 
            task.TodolistIdtodolist = id;

            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
            MessageBox.Show("Task ajouté avec succès");

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
