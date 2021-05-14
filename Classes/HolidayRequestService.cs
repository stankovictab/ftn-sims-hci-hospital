using System;
using System.Collections.Generic;

namespace Classes
{
    public class HolidayRequestService
    {
        public HolidayRequestRepository hrr = new HolidayRequestRepository();

        public Boolean AreDatesValid(DateTime start, DateTime end)
        {
            // Moze da se popravi ali radi
            if (start < end) return true;
            else return false;
        }

        public Boolean Create(HolidayRequest req)
        {
            // Mora da dobavi sledeci slobodan id iz repo-a pre nego sto ga napravi u repo
            if (AreDatesValid(req.StartDate1, req.EndDate1) == false)
            {
                throw new Exception("Dates invalid!"); // Ili samo return false?
            }

            List<HolidayRequest> temp = hrr.GetAll();
            int newid = 0;
            foreach (HolidayRequest r in temp)
            {
                newid = Int32.Parse(r.RequestID1);
            }
            newid++;
            String newidstring = newid.ToString();

            req.RequestID1 = newidstring;
            return hrr.Create(req);
        }

        public HolidayRequest GetByID(String id)
        {
            return hrr.GetByID(id);
        }

        public List<HolidayRequest> GetAll()
        {
            return hrr.GetAll();
        }

        public List<HolidayRequest> GetAllByDoctorID(String doctorID)
        {
            return hrr.GetAllByDoctorID(doctorID);
        }

        public List<HolidayRequest> GetAllOnHold()
        {
            return hrr.GetAllOnHold();
        }

        public Boolean Update(HolidayRequest req)
        {
            if (AreDatesValid(req.StartDate1, req.EndDate1) == false)
            {
                throw new Exception("Dates invalid!"); // Ili samo return false?
            }
            return hrr.Update(req); // Provera da li postoji vec u listi se radi u repozitorijumu
        }

        public Boolean UpdateFile()
        {
            return hrr.UpdateFile();
        }

        public Boolean Delete(String id)
        {
            return hrr.Delete(id);
        }

        public Boolean Approve(String id, String commentary)
        {
            return hrr.Approve(id, commentary);
        }

        public Boolean Deny(String id, String commentary)
        {
            return hrr.Deny(id, commentary);
        }
    }
}