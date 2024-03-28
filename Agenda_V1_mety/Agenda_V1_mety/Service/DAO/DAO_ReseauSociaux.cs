using Agenda_V1_mety.Agenda_tsiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_V1_mety.Service.DAO
{
     class DAO_ReseauSociaux
    {
        public bool CheckDatabase()
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Database.CanConnect();
            }
        }
        public IEnumerable<ReseauSociaux> GetReseauSociaux()
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.ReseauSociauxes.ToList();
            }
        }
        
        public void AjouterReseauSociaux(ReseauSociaux reseauSociaux)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                context.ReseauSociauxes.Add(reseauSociaux);
                context.SaveChanges();
            }
        }

        public ReseauSociaux GetReseauSociauxByIdcontact(int idContact)
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.ReseauSociauxes.Where(r => r.ContactIdcontact == idContact).FirstOrDefault();
            }
        }


        //modifier un reseau social
        public void modifieReseauSociaux(ReseauSociaux reseauSociaux)
        {
            if (reseauSociaux != null)
            {
                using (var context = new AgendaAndrianasoloharisonContext())
                {
                    context.ReseauSociauxes.Update(reseauSociaux);
                    context.SaveChanges();
                }
            }

        }

    }
}
