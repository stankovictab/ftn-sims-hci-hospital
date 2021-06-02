using System;
using System.Collections.Generic;

namespace Classes
{
    public class HolidayRequestService
    {
        public HolidayRequestRepository hrr = new HolidayRequestRepository();

        public Boolean Create(HolidayRequest req)
        {
            // Mora da dobavi sledeci slobodan id iz repo-a pre nego sto ga napravi u repo
            CheckDates(req);
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

        public List<HolidayRequest> GetAllNotOnHold()
        {
            return hrr.GetAllNotOnHold();
        }

        public Boolean Update(HolidayRequest req)
        {
            CheckDates(req);
            // Posto se doktor nece menjati pri update-u, nalazi se po ID-u request-a
            List<HolidayRequest> list = hrr.GetAll();
            Doctor doctor = new Doctor();
            foreach (HolidayRequest r in list)
            {
                if (r.RequestID1 == req.RequestID1)
                {
                    doctor = r.doctor;
                }
            }
            req.doctor = doctor;
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

        // Clean Code

        public void CheckDates(HolidayRequest req)
        {
            if (req.StartDate1 > req.EndDate1)
            {
                throw new Exception("Dates invalid!"); // Ili samo return false?
            }
        }
    }
}