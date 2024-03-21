using Agenda_V1_mety.Agenda_tsiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_V1_mety.Service.DAO
{
    class DAO_cantact
    {
        public bool CheckDatabase()
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Database.CanConnect();
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Contacts.ToList();
            }
        }
        public void AjouterContact(Contact contact)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }
        public void modifieContact(Contact contact)
        {
            //modifier un contact
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Contacts.Update(contact);
                context.SaveChanges();
            }

        }

        public void SupprimerContact(Contact contact)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
        }
        
        public IEnumerable<Contact> RechercherContactParNom(string nom)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Contacts.Where(c => c.Nom.Contains(nom)).ToList();
            }
        }
        public IEnumerable<Contact> RechercherContactParPrenom(string prenom)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Contacts.Where(c => c.Prenom.Contains(prenom)).ToList();
            }
        }
        
        //rechercher les contacts qui sont des amis
        public IEnumerable<Contact> RechercherContactStatut(string statut)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Contacts.Where(c => c.Statut == statut).ToList();
            }
        }
    }
}
