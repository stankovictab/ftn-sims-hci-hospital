using System;
using System.Collections.Generic;

namespace Classes
{
    public class HolidayRequestController
    {
        public HolidayRequestService holidayRequestService;

        public Boolean Create(String desc, DateTime start, DateTime end)
        {
            // TODO: implement
            return false;
        }

        public HolidayRequest GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public List<HolidayRequest> GetAll()
        {
            // TODO: implement
            return null;
        }

        public List<HolidayRequest> GetAllByDoctorID(String doctorID)
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(String id, String desc, DateTime start, DateTime end)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {
            // TODO: implement
            return false;
        }

        public Boolean Approve(String id)
        {
            // TODO: implement
            return false;
        }

        public Boolean Deny(String id)
        {
            // TODO: implement
            return false;
        }
    }
}