using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda_V1_mety.Agenda_tsiory;
namespace Agenda_V1_mety.Service.DAO
{
    public class DAO_Todolist
    {
        //recuperer la liste des taches
        public IEnumerable<Todolist> GetTodolists()
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Todolists.ToList();
            }
        }
        //ajouter une tache
        public void AjouterTodolist(Todolist todolist)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Todolists.Add(todolist);
                context.SaveChanges();
            }
        }

        //modifier une tache
        public void modifieTodolist(Todolist todolist)
        {
            if (todolist != null)
            {
                using (var context = new AgendaAndrianasoloharisonContext())
                {
                    context.Todolists.Update(todolist);
                    context.SaveChanges();
                }
            }
        }

        //supprimer une tache
        public void SupprimerTodolist(Todolist todolist)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Todolists.Remove(todolist);
                context.SaveChanges();
            }
        }
    }
}
