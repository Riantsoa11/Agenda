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
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }
        public void SupprimerContact(int id)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                var contact = context.Contacts.Find(id);
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
        }
    }
}
