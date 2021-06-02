using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class ReminderController
    {
        private ReminderService reminderService;
        public ReminderController()
        {
            reminderService = new ReminderService();
        }
        public Boolean Create(Reminder r)
        {
            return reminderService.Create(r);
        }

        public Reminder GetByID(String id)
        {
            return reminderService.GetByID(id);
        }

        public List<Reminder> GetAllByPatientID(String id, Boolean getHighlighted)
        {
            return reminderService.GetAllByPatientID(id, getHighlighted);
        }
        public Boolean Update(Reminder r)
        {
            return reminderService.Update(r);
        }

        public Boolean Delete(String id)
        {
            return reminderService.Delete(id);
        }
    }
}
