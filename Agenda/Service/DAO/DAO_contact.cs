using Agenda.agenda_tsiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Service.DAO
{
    class DAO_contact
    {
        public IEnumerable<Contact>GetContacts()
        {
            using (var context = new AgendaTsioryContext())
            {
                return context.Contacts.ToList();
            }
        }
            
    }
}
