using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IAppointmentRepository
    {
        List<Appointment> AppointmentsInFile { get; set; }

        Boolean Create(Appointment app);

        Appointment GetByID(String id);

        List<Appointment> GetAll();
        List<Appointment> GetAllByPatientID(String patientID);
        List<Appointment> GetAllByDoctorID(String doctorID);
        Boolean Update(Appointment app);

        Boolean Delete(String id);

        String GenerateNewId();
    }
}
