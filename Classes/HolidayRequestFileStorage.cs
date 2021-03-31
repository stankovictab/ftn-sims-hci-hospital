/***********************************************************************
 * Module:  RoomFileStorage.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Manager.RoomFileStorage
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes {
    public class HolidayRequestFileStorage {
        private String FileLocation = "holidayrequests.txt"; // U jednom fajlu ce biti Request-ovi za sve lekare
        private List<HolidayRequest> HolidayRequestsInFile = new List<HolidayRequest>(); // Lista u memoriji, ona ce preko updateAll() overwrite-ovati fajl

        // Property (geter i seter) za HolidayRequestsInFile
        public List<HolidayRequest> HolidayRequestsInFile1 { get => HolidayRequestsInFile; set => HolidayRequestsInFile = value; }

        // Dodavanje Request-a i u memoriju i u fajl
        public Boolean Create(HolidayRequest req) {
            if (HolidayRequestsInFile.Contains(req)) {
                return false;
            } else {
                HolidayRequestsInFile.Add(req);
                return true;
            }
        }

        public HolidayRequest GetByID(String id) {
            foreach (HolidayRequest req in HolidayRequestsInFile) {
                if (req.RequestID1.Equals(id)) {
                    return req;
                }
            }
            return null;
        }

        // Prebacivanje iz fajla u listu u memoriji
        public List<HolidayRequest> GetAll() {
            List<HolidayRequest> requests = new List<HolidayRequest>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n") {
                string[] components = text.Split(','); // Po defaultu su svi componenti stringovi, pa za neke mora convert
                string id = components[0];
                string description = components[1];
                DateTime startDate = Convert.ToDateTime(components[2]);
                DateTime endDate = Convert.ToDateTime(components[3]);
                // TODO:
                // components[4] je id doktora, pa moramo da nadjemo tog iz liste (GetAll) da bi ga prosledili konstruktoru HR-a
                // ovo je pseudodoktor
                User u = new User("A","","","","",components[4]);
                Doctor doc = new Doctor(u, null, null, null);


                HolidayRequest request = new HolidayRequest(id, description, startDate, endDate, doc);
                requests.Add(request);
                text = tr.ReadLine();
            }
            tr.Close();
            return requests;
        }

        // Ovo ne mora da se prepravlja da bude kao gore 
        public List<HolidayRequest> GetAllByDoctorID(String id) {
            List<HolidayRequest> requests = new List<HolidayRequest>();
            foreach (HolidayRequest req in HolidayRequestsInFile) {
                // Ako nadje Request za prosledjenog lekara, stavi ga u listu, i vrati listu
                if (req.doctor.user.Jmbg1.Equals(id)) {
                    requests.Add(req);
                }
            }
            return requests;
        }

        // Update jednog elementa u listi u memoriji
        public Boolean Update(HolidayRequest prosledjeni) {
            foreach (HolidayRequest nadjeni in HolidayRequestsInFile) {
                if (prosledjeni.RequestID1.Equals(nadjeni.RequestID1)) {
                    nadjeni.Description1 = prosledjeni.Description1;
                    nadjeni.StartDate1 = prosledjeni.StartDate1;
                    nadjeni.EndDate1 = prosledjeni.EndDate1;
                    nadjeni.RequestDate1 = prosledjeni.RequestDate1;
                    nadjeni.Status1 = prosledjeni.Status1;
                    nadjeni.doctor = prosledjeni.doctor;
                    return true;
                }
            }
            return false;
        }

        // Univerzalna metoda za overwrite-ovanje liste koja je u memoriji u fajl
        public Boolean UpdateAll(List<HolidayRequest> hrif) {
            TextWriter tw = new StreamWriter(FileLocation);
            if (hrif == null) {
                tw.Close();
                return false;
            } else {
                // Za svaki Request pise liniju
                foreach (HolidayRequest item in hrif) {
                    tw.WriteLine(String.Format("RequestID: {0}, Description: {1}, Start Date: {2}, End Date: {3}, Request Date: {4}, Status: {5}, Doctor: {6}"), item.RequestID1, item.Description1, item.StartDate1, item.EndDate1, item.RequestDate1, item.Status1, item.doctor);
                }
                tw.Close();
                return true;
            }
        }

        // Brisanje samo iz liste u memoriji, vraca false ako ne nadje da obrise
        public Boolean Delete(String id) {
            foreach (HolidayRequest hr in HolidayRequestsInFile) {
                if (hr.RequestID1.Equals(id)) {
                    HolidayRequestsInFile.Remove(hr);
                    return true;
                }
            }
            return false;
        }
    }
}