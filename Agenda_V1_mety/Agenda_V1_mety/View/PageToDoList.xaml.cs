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
    /// Logique d'interaction pour PageToDoList.xaml
    /// </summary>
    public partial class PageToDoList : UserControl
    {
        Todolist toDoList;
        public PageToDoList()
        {
            InitializeComponent();
            toDoList = new Todolist();
        }

        private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
        {

            toDoList.Descriptionl = TB_Description.Text;
            if (DP_Date.SelectedDate.HasValue) // Vérifiez si une date a été sélectionnée
            {
                DateTime selectedDateTime = DP_Date.SelectedDate.Value;
                toDoList.Date = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
            }

            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Todolists.Add(toDoList);
                context.SaveChanges();
            }
            MessageBox.Show("To do list ajouté avec succès");

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

    }
}
