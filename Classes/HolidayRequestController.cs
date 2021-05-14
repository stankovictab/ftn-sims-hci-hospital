using System;
using System.Collections.Generic;

namespace Classes
{
    public class HolidayRequestController
    {
        public HolidayRequestService hrs = new HolidayRequestService();

        public Boolean Create(HolidayRequest req)
        {
            return hrs.Create(req);
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

        public Boolean Update(HolidayRequest req)
        {
            return hrs.Update(req);
        }

        public Boolean UpdateFile()
        {
            return hrs.UpdateFile();
        }

        public Boolean Delete(String id)
        {
            return hrs.Delete(id);
        }

        public Boolean Approve(String id, String commentary)
        {
            return hrs.Approve(id, commentary);
        }

        public Boolean Deny(String id, String commentary)
        {
            return hrs.Deny(id, commentary);
        }
    }
}