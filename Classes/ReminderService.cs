using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class ReminderService
    {
        private ReminderRepository reminderRepository;
        public ReminderService()
        {
            reminderRepository = new ReminderRepository();
        }
        public Boolean Create(Reminder r)
        {
            String id = generateId();
            r.Id = id;
            return reminderRepository.Create(r);
        }

        public Reminder GetByID(String id)
        {
            return reminderRepository.GetByID(id);
        }

        public List<Reminder> GetAllByPatientID(String id, Boolean getHighlighted)
        {
            return reminderRepository.GetAllByPatientID(id, getHighlighted);
        }
        public Boolean Update(Reminder r)
        {
            return reminderRepository.Update(r);
        }

        public Boolean Delete(String id)
        {
            return reminderRepository.Delete(id);
        }

        private String generateId()
        {
            List<Reminder> reminders = reminderRepository.GetAll();
            int currentlyLargestId = 0;
            if (reminders.Count > 0)
            {
                currentlyLargestId = int.Parse(reminders[reminders.Count - 1].Id);
            }
            return (++currentlyLargestId).ToString();
        }
    }
}
