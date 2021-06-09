using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SecretaryNotifyStrategy : INotifyStrategy
    {
        private NotificationRepository notificationRepository = new NotificationRepository();
        private PatientRepository patientRepository = new PatientRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();
        public void Notify(Appointment app)
        {
            Doctor d = doctorRepository.GetByID(app.doctor.user.Jmbg1);
            Patient p = patientRepository.GetByID(app.patient.user.Jmbg1);
            d.notifications =notificationRepository.GetByDoctorID(app.doctor.user.Jmbg1);
            p.notifications = notificationRepository.GetByPatientID(app.patient.user.Jmbg1);
            String id = (notificationRepository.GetAll().Count() + 1).ToString();
            Notification notification = new Notification(id, "Alert", "You have a new appointment on  " + app.StartTime.ToString(), DateTime.Now, false, app.patient.user.Jmbg1, app.doctor.user.Jmbg1);
            d.notifications.Add(notification);
            p.notifications.Add(notification);
            notificationRepository.Create(notification);
        }
    }
}
