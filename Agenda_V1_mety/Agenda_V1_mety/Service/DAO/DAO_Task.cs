using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agenda_V1_mety.Agenda_tsiory;

namespace Agenda_V1_mety.Service.DAO
{
    public class DAO_Task
    {
        //recuperer la liste des taches
        public IEnumerable<Task> GetTasks()
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Tasks.ToList();
            }
        }
        //ajouter une tache
        public void AddTask(Task task)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }



        //methode gettask by todolistid
        public IEnumerable<Task> GetTasksBytodolistId(int idtodolist)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Tasks.Where(t => t.TodolistIdtodolist == idtodolist).ToList();
            }
        }

        //modifier une tache
        public void ModifyTask(Task task)
        {
            if (task != null)
            {
                using (var context = new AgendaAndrianasoloharisonContext())
                {
                    context.Tasks.Update(task);
                    context.SaveChanges();
                }
            }
        }

        //supprimer une tache
        public void DeleteTask(Task task)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }
    }
}
