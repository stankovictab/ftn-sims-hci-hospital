using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes
{
    class HospitalizationReferalRepository
    {
        private String FileLocation;
        private PatientRepository patientRepository = new PatientRepository();
        private RoomRepository roomRepository = new RoomRepository();
        public HospitalizationReferalRepository()
        {
            FileLocation = "../../Text Files/hospitalizationreferals.txt";
        }

        public Boolean Create(HospitalizationReferal hr)
        {
            string newLine = hr.id + ";" + hr.patient.user.Jmbg1 + ";" + hr.description + ";" + hr.startDate.Year.ToString() + "," + hr.startDate.Month.ToString() + "," + hr.startDate.Day.ToString()
               + "," + hr.startDate.Hour.ToString() + "," + hr.startDate.Minute.ToString() + "," + hr.startDate.Second.ToString()
               + ";" + hr.endDate.Year.ToString() + "," + hr.endDate.Month.ToString() + "," + hr.endDate.Day.ToString()
               + "," + hr.endDate.Hour.ToString() + "," + hr.endDate.Minute.ToString() + "," + hr.endDate.Second.ToString() + ";" + hr.room.RoomNumber + ";" + hr.bed.statId + "\n";
            System.IO.File.AppendAllText(FileLocation, newLine);
            return true;
        }

        public HospitalizationReferal GetById(String HrefId)
        {
            HospitalizationReferal hospitalizationReferral;
            String[] rows = System.IO.File.ReadAllLines(FileLocation);

            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[0].Equals(HrefId))
                {
                    String id = data[0];
                    String patientId = data[1];
                    Patient patient = patientRepository.GetByID(patientId);
                    String description = data[2];
                    String[] startDateParts = data[3].Split(',');
                    DateTime startDate = new DateTime(int.Parse(startDateParts[0]), int.Parse(startDateParts[1]), int.Parse(startDateParts[2]), int.Parse(startDateParts[3]), int.Parse(startDateParts[4]), int.Parse(startDateParts[5]));
                    String[] endDateParts = data[4].Split(',');
                    DateTime endDate = new DateTime(int.Parse(startDateParts[0]), int.Parse(startDateParts[1]), int.Parse(startDateParts[2]), int.Parse(startDateParts[3]), int.Parse(startDateParts[4]), int.Parse(startDateParts[5]));
                    String roomId = data[5];
                    int bedId = int.Parse(data[6]);
                    Room room = roomRepository.GetById(roomId);
                    hospitalizationReferral = new HospitalizationReferal(id, patient, description, startDate, endDate, room, bedId);
                    return hospitalizationReferral;
                }
            }
            return null;
        }

        public List<HospitalizationReferal> GetAllByPatientId(String patientID)
        {
            List<HospitalizationReferal> referrals = new List<HospitalizationReferal>();
            String[] rows = System.IO.File.ReadAllLines(FileLocation);

            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                if (data[1].Equals(patientID))
                {
                    String id = data[0];
                    String patientId = data[1];
                    Patient patient = patientRepository.GetByID(patientId);
                    String description = data[2];
                    String[] startDateParts = data[3].Split(',');
                    DateTime startDate = new DateTime(int.Parse(startDateParts[0]), int.Parse(startDateParts[1]), int.Parse(startDateParts[2]), int.Parse(startDateParts[3]), int.Parse(startDateParts[4]), int.Parse(startDateParts[5]));
                    String[] endDateParts = data[4].Split(',');
                    DateTime endDate = new DateTime(int.Parse(endDateParts[0]), int.Parse(endDateParts[1]), int.Parse(endDateParts[2]), int.Parse(endDateParts[3]), int.Parse(endDateParts[4]), int.Parse(endDateParts[5]));
                    String roomId = data[5];
                    StaticEquipment bed = new StaticEquipment();
                    int bedId = int.Parse(data[6]);
                    Room room = roomRepository.GetById(roomId);
                    HospitalizationReferal hospitalizationReferral = new HospitalizationReferal(id, patient, description, startDate, endDate, room, bedId);
                    referrals.Add(hospitalizationReferral);
                }
            }
            return referrals;
        }
        public Boolean Delete(String id)
        {
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            List<HospitalizationReferal> referrals = new List<HospitalizationReferal>();
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

        public Boolean Update(HospitalizationReferal hr)
        {
            if (Delete(hr.id))
            {
                Create(hr);
                return true;
            }

            return false;
        }
        public List<HospitalizationReferal> getAllByEndDate(DateTime requestedEndDate)
        {
            List<HospitalizationReferal> referralsByEndDate = new List<HospitalizationReferal>();
            String[] rows = System.IO.File.ReadAllLines(FileLocation);
            foreach (String row in rows)
            {
                String[] data = row.Split(';');
                String[] endDateParts = data[4].Split(',');
                if (endDateParts[0].Equals(requestedEndDate.Year.ToString()) && Convert.ToInt32(endDateParts[1]).ToString().Equals(requestedEndDate.Month.ToString()) && Convert.ToInt32(endDateParts[2]).ToString().Equals(requestedEndDate.Day.ToString()))
                {
                    String id = data[0];
                    String patientId = data[1];
                    Patient patient = patientRepository.GetByID(patientId);
                    String description = data[2];
                    String[] startDateParts = data[3].Split(',');
                    DateTime startDate = new DateTime(int.Parse(startDateParts[0]), int.Parse(startDateParts[1]), int.Parse(startDateParts[2]), int.Parse(startDateParts[3]), int.Parse(startDateParts[4]), int.Parse(startDateParts[5]));
                    DateTime endDate = new DateTime(int.Parse(endDateParts[0]), int.Parse(endDateParts[1]), int.Parse(endDateParts[2]), int.Parse(endDateParts[3]), int.Parse(endDateParts[4]), int.Parse(endDateParts[5]));
                    String roomId = data[5];
                    Room room = roomRepository.GetById(roomId);
                    HospitalizationReferal hospitalizationReferral = new HospitalizationReferal(id, patient, description, startDate, endDate, room);
                    referralsByEndDate.Add(hospitalizationReferral);
                }
            }
            return referralsByEndDate;
        }
    }
}