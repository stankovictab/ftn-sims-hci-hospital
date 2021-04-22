using System;
using System.Collections.Generic;

namespace Classes
{
    public class HolidayRequestController
    {
        public HolidayRequestService hrs = new HolidayRequestService();

        public Boolean Create(String desc, DateTime start, DateTime end, Doctor doctor)
        {
            return hrs.Create(desc, start, end, doctor);
        }

        public HolidayRequest GetByID(String id)
        {
            return hrs.GetByID(id);
        }

        public List<HolidayRequest> GetAll()
        {
            return hrs.GetAll();
        }

        public List<HolidayRequest> GetAllByDoctorID(String doctorID)
        {
            return hrs.GetAllByDoctorID(doctorID);
        }

        public List<HolidayRequest> GetAllOnHold()
        {
            return hrs.GetAllOnHold();
        }

        public Boolean Update(String id, String desc, DateTime start, DateTime end, Doctor doctor)
        {
            return hrs.Update(id, desc, start, end, doctor);
        }

        public Boolean UpdateFile()
        {
            return hrs.UpdateFile();
        }

        public Boolean Delete(String id)
        {
            return hrs.Delete(id);
        }

        public Boolean Approve(String id)
        {
            return hrs.Approve(id);
        }

        public Boolean Deny(String id)
        {
            return hrs.Deny(id);
        }
    }
}