using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class DoctorFileStorage
    {
        private String FileLocation = "../../Text Files/doctors.txt";
        private List<Doctor> DoctorsInFile;

        public List<Doctor> DoctorsInFile1 { get => DoctorsInFile; set => DoctorsInFile = value; }

        public Boolean Create(Doctor d)
        {
            if (DoctorsInFile.Contains(d))
            {
                return false;
            }
            else
            {
                DoctorsInFile.Add(d);
                return true;
            }
        }

        public Doctor GetByID(String id)
        {
            foreach (Doctor doc in DoctorsInFile)
            {
                if (doc.user.Jmbg1.Equals(id))
                {
                    return doc;
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
                string[] components = text.Split(',');
                string id = components[0];
                string name = components[1];
                string lastname = components[2];
                string RoomNumber = components[3];
                string AppointmentArray = components[4];
                string HolidayRequestArray = components[5];
                User docuser = new User(name, lastname, null, null, null, id, null, 'M', false, Roles.Doctor); // Promeniti argumente i txt fajl, ovo je samo za test
                Doctor doctor = new Doctor(docuser, null, null, null); // TODO: Izmeniti null-ove
                doctors.Add(doctor);
                text = tr.ReadLine();
            }
            tr.Close();
            return doctors;
        }

        public Boolean Update(Doctor prosledjeni)
        {
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
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAll(List<Doctor> dif)
        {
            TextWriter tw = new StreamWriter(FileLocation);
            if (dif == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                foreach (Doctor item in dif)
                {
                    tw.WriteLine(item.user.Jmbg1 + "," + item.user.Name1 + "," + item.user.LastName1 + "," + item.room.RoomNumber1 + "," + null + "," + null);
                    // Ostalo je item.appointments i item.holidayRequests da se formatira u istom obliku, kako? ne znam. verovatno da se prekine ovaj upis, pa neki for da prolazi kroz te dve liste i da ispisuje elemente u isti red, sa uglastim zagradama, i zarezom izmedju
                    // Nece da radi dobro preko WriteLine(String.Format("{0}..."), ...);
                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(String id)
        {
            foreach (Doctor doc in DoctorsInFile)
            {
                if (doc.user.Jmbg1.Equals(id))
                {
                    DoctorsInFile.Remove(doc);
                    return true;
                }
            }
            return false;
        }
    }
}