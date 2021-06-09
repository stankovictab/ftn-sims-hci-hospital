using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class DoctorRepository : IDoctorRepository
    {
        private String FileLocation = "../../Text Files/doctors.txt";
        public List<Doctor> DoctorsInFile { get; set; }
        private HolidayRequestRepository hrr=new HolidayRequestRepository();
        private DynamicEquipmentRequestRepository derr=new DynamicEquipmentRequestRepository();
        private NotificationRepository nr = new NotificationRepository();
        private AppointmentRepository ar = new AppointmentRepository();

        // public List<Doctor> DoctorsInFile1 { get => DoctorsInFile; set => DoctorsInFile = value; }
        //radili i djota i ziksa

        public Boolean Create(Doctor d)
        {
            GetAll(); // Update liste
            if (DoctorsInFile.Contains(d))
            {
                return false;
            }
            else
            {
                DoctorsInFile.Add(d); // Update liste
                UpdateFile(); // Update fajla
                return true;
            }
        }

        public Doctor GetByID(String id)
        {
            GetAll(); // Update liste
            foreach (Doctor d in DoctorsInFile)
            {
                if (d.user.Jmbg1.Equals(id))
                {
                    return d;
                }
            }
            return null;
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(','); // Po defaultu su svi componenti stringovi, pa za neke mora convert
                string id = components[0];
                string doctorName = components[1];
                string doctorLastName = components[2];
                string doctorRoom = components[3];
                DoctorSpecialization specialization = (DoctorSpecialization)Convert.ToInt32(components[4]);
                Shift shift = (Shift)Convert.ToInt32(components[5]);

                // TODO: Ovo sa ovim konstruktorima nije bas dobro, tu treba da budu neki geteri, ali za sada je ok, valjda
                User user = new User(doctorName, doctorLastName, "", "", "", id, "", 'N', false, Roles.Doctor);
                Room room = new Room(doctorRoom, 0, "", RoomType.Checkup);


                // TODO: Rest
                


                Doctor doc = new Doctor(user, room, specialization, null,null,null,null);
                doc.shift = shift;
                doctors.Add(doc);
                text = tr.ReadLine();
            }
            tr.Close();
            DoctorsInFile = doctors; // Update liste
            return doctors;
        }

        public Boolean Update(Doctor prosledjeni)
        {
            GetAll(); // Update liste
            foreach (Doctor nadjeni in DoctorsInFile)
            {
                if (prosledjeni.user.Jmbg1.Equals(nadjeni.user.Jmbg1))
                {
                    // Mozda moze samo nadjeni.user = prosledjeni.user?
                    // Neke od ovih stvari mozda nemaju smisla da se update-uju, kao npr Gender
                    nadjeni.user.Name1 = prosledjeni.user.Name1;
                    nadjeni.user.LastName1 = prosledjeni.user.LastName1;
                    nadjeni.user.Username1 = prosledjeni.user.Username1;
                    nadjeni.user.Password1 = prosledjeni.user.Password1;
                    nadjeni.user.Email1 = prosledjeni.user.Email1;
                    nadjeni.user.Gender1 = prosledjeni.user.Gender1;
                    nadjeni.user.Address1 = prosledjeni.user.Address1;
                    nadjeni.user.Active1 = prosledjeni.user.Active1;
                    nadjeni.user.Role1 = prosledjeni.user.Role1;
                    nadjeni.room = prosledjeni.room;
                    nadjeni.appointments = prosledjeni.appointments;
                    nadjeni.holidayRequests = prosledjeni.holidayRequests;
                    nadjeni.shift = prosledjeni.shift;
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateFile()
        {
            // Ovde se ne radi GetAll();
            TextWriter tw = new StreamWriter(FileLocation);
            if (DoctorsInFile == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                foreach (Doctor item in DoctorsInFile)
                {  
                    tw.WriteLine(item.user.Jmbg1 + "," + item.user.Name1 + "," + item.user.LastName1 + "," + item.room.RoomNumber1 + "," + Convert.ToInt32(item.specialization)+","+ Convert.ToInt32(item.shift));

                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(String id)
        {
            GetAll(); // Update liste
            foreach (Doctor doc in DoctorsInFile)
            {
                if (doc.user.Jmbg1.Equals(id))
                {
                    DoctorsInFile.Remove(doc);
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }
    }
}