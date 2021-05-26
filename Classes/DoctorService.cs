using System;
using System.Collections.Generic;

namespace Classes
{
    public class DoctorService
    {
        public DoctorRepository dr = new DoctorRepository();
        private HolidayRequestRepository hrr = new HolidayRequestRepository();
        private DynamicEquipmentRequestRepository derr = new DynamicEquipmentRequestRepository();
        private NotificationRepository nr = new NotificationRepository();
        private AppointmentRepository ar = new AppointmentRepository();

        public Boolean Create(Doctor d)
        {
            return dr.Create(d);
        }

        public Doctor GetByID(String id)
        {
            return dr.GetByID(id);
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = dr.GetAll();
            foreach(Doctor doctor in doctors)
            {
                doctor.holidayRequests = hrr.GetAllByDoctorID(doctor.user.Jmbg1);
                doctor.dynamicEquipmentRequests = derr.GetAllByDoctorID(doctor.user.Jmbg1);
                doctor.appointments = ar.GetAllByDoctorID(doctor.user.Jmbg1);
                doctor.notifications = nr.GetByDoctorID(doctor.user.Jmbg1);
            }
            return dr.GetAll();
        }

        public Boolean Update(Doctor d)
        {
            return dr.Update(d);
        }

        public Boolean UpdateFile()
        {
            return dr.UpdateFile();
        }

        public Boolean Delete(String id)
        {
            return dr.Delete(id);
        }
    }
}