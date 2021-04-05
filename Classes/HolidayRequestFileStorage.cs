using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class HolidayRequestFileStorage
    {
        private String FileLocation = "../../Text Files/holidayrequests.txt"; // U jednom fajlu ce biti Request-ovi za sve lekare, pa ce se filtrirati po ID-u lekara, ovo je u \bin\Debug folderu
        private List<HolidayRequest> HolidayRequestsInFile = new List<HolidayRequest>(); // Lista u memoriji, ona ce preko updateAll() overwrite-ovati fajl

        // Property (geter i seter) za HolidayRequestsInFile
        public List<HolidayRequest> HolidayRequestsInFile1 { get => HolidayRequestsInFile; set => HolidayRequestsInFile = value; }

        // Dodavanje Request-a i u memoriju i u fajl
        public Boolean Create(HolidayRequest req)
        {
            if (HolidayRequestsInFile.Contains(req))
            {
                return false;
            }
            else
            {
                HolidayRequestsInFile.Add(req);
                return true;
            }
        }

        public HolidayRequest GetByID(String id)
        {
            foreach (HolidayRequest req in HolidayRequestsInFile)
            {
                if (req.RequestID1.Equals(id))
                {
                    return req;
                }
            }
            return null;
        }

        // Univerzalna metoda za skeniranje fajla i vracanje liste sa svim elementima, ta lista koja se odavde vraca ce uvek biti dodeljena atributu NestoInFile kada se elementi budu loadovali kada to bude bilo potrebno (kao na primer ovde dole sa lekarima)
        public List<HolidayRequest> GetAll()
        {
            List<HolidayRequest> requests = new List<HolidayRequest>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(','); // Po defaultu su svi componenti stringovi, pa za neke mora convert
                string id = components[0];
                string description = components[1];
                DateTime startDate = Convert.ToDateTime(components[2]);
                DateTime endDate = Convert.ToDateTime(components[3]);
                // Loadovanje lekara u memoriju da bi im pristupili
                DoctorFileStorage dfs = new DoctorFileStorage();
                dfs.DoctorsInFile1 = dfs.GetAll();
                // Mora prvo GetAll pa onda GetByID jer ByID trazi u vec ucitanoj listi u memoriji, ne po fajlu, isto kao u ovoj klasi
                Doctor doctor = dfs.GetByID(components[4]);
                HolidayRequest request = new HolidayRequest(id, description, startDate, endDate, doctor);
                requests.Add(request);
                text = tr.ReadLine();
            }
            tr.Close();
            return requests;
        }

        // Ovo ne mora da se prepravlja da bude kao gore, jer metoda radi tako sto uzima iz vec napunjenu listu u memoriji, nema potrebe ponovo da skenira fajl, nego se samo jednom radi GetAll() na pocetku, da se loaduje lista, i onda odatle ovo i ostale metode
        public List<HolidayRequest> GetAllByDoctorID(String id)
        {
            List<HolidayRequest> requests = new List<HolidayRequest>();
            foreach (HolidayRequest req in HolidayRequestsInFile)
            {
                // Ako nadje Request za prosledjenog lekara, stavi ga u listu, i vrati listu
                // Ako lekar sa datim JMBG-om ne postoji u doctors.txt, bacice exception
                if (req.doctor.user.Jmbg1.Equals(id))
                {
                    requests.Add(req);
                }
            }
            return requests;
        }

        // Update jednog elementa u listi u memoriji
        public Boolean Update(HolidayRequest prosledjeni)
        {
            foreach (HolidayRequest nadjeni in HolidayRequestsInFile)
            {
                if (prosledjeni.RequestID1.Equals(nadjeni.RequestID1))
                {
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
        public Boolean UpdateAll(List<HolidayRequest> hrif)
        {
            TextWriter tw = new StreamWriter(FileLocation);
            if (hrif == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                // Za svaki Request pise liniju, i to mora da bude u istom formatu kao kada i cita
                foreach (HolidayRequest item in hrif)
                {
                    tw.WriteLine(item.RequestID1 + "," + item.Description1 + "," + item.StartDate1 + "," + item.EndDate1 + "," + item.doctor.user.Jmbg1);
                    // Mozda i item.RequestDate1 i item.Status1?
                    // Datumi se ne ispisuju po onom mom formatu ali izgleda da je i ovako ok
                }
                tw.Close();
                return true;
            }
        }

        // Brisanje samo iz liste u memoriji, vraca false ako ne nadje da obrise
        public Boolean Delete(String id)
        {
            foreach (HolidayRequest hr in HolidayRequestsInFile)
            {
                if (hr.RequestID1.Equals(id))
                {
                    HolidayRequestsInFile.Remove(hr);
                    return true;
                }
            }
            return false;
        }
    }
}