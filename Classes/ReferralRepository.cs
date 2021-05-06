using System;
using System.Collections.Generic;

namespace ftn_sims_hci_hospital.Classes
{
    class ReferralRepository
    {
        private String FileLocation;
        public ReferralRepository()
        {
            FileLocation = "../../Text Files/referrals.txt";
        }

        public Boolean Create(Referral r)
        {
            string newLine = r.id + ";" + r.doctor.user.Jmbg1 + ";" + r.patient.user.Jmbg1 + ";" + r.description + ";" + r.endDate.ToString("yyyy,MM,dd,hh,mm,ss") + ";" + r.used + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public Referral GetById(String refId)
        {
            Referral referral;
            String[] rows = System.IO.File.ReadAllLines(FileLocation);

            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[0].Equals(refId))
                {
                    String id = data[0];
                    String doctorId = data[1];
                    String patientId = data[2];
                    String description = data[3];
                    String[] endDateParts = data[4].Split(',');
                    DateTime endDate = new DateTime(int.Parse(endDateParts[0]), int.Parse(endDateParts[1]), int.Parse(endDateParts[2]), int.Parse(endDateParts[3]), int.Parse(endDateParts[4]), int.Parse(endDateParts[5]));
                    Boolean used = Boolean.Parse(data[5]);
                    referral = new Referral(id, doctorId, patientId, description, endDate, used);
                    return referral;
                }
            }
            return null;
        }

        public List<Referral> GetAllByPatientId(String patientID)
        {
            List<Referral> referrals = new List<Referral>();
            String[] rows = System.IO.File.ReadAllLines(FileLocation);

            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[2].Equals(patientID) && data[5].Equals("False"))
                {
                    String id = data[0];
                    String doctorId = data[1];
                    String patientId = data[2];
                    String description = data[3];
                    String[] endDateParts = data[4].Split(',');
                    DateTime endDate = new DateTime(int.Parse(endDateParts[0]), int.Parse(endDateParts[1]), int.Parse(endDateParts[2]), int.Parse(endDateParts[3]), int.Parse(endDateParts[4]), int.Parse(endDateParts[5]));
                    Boolean used = Boolean.Parse(data[5]);
                    Referral r = new Referral(id, doctorId, patientId, description, endDate, used);
                    referrals.Add(r);
                }
            }
            return referrals;
        }
        public Boolean Delete(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<Referral> appointments = new List<Referral>();
            List<String> novi = new List<string>();
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (!data[0].Equals(id))
                {
                    String r = String.Join(";", data);
                    novi.Add(r);
                }
            }
            System.IO.File.WriteAllLines(FileLocation, novi);
            return true;
        }

        public Boolean Update(Referral r)
        {
            if (Delete(r.id))
            {
                Create(r);
                return true;
            }

            return false;
        }
    }
}
