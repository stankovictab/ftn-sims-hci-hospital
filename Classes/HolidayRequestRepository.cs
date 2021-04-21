using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class HolidayRequestRepository
    {
        // TODO: U MainWindow cemo imati JEDINE instance kontrolera svega, da ne bismo imali vise puta iste stvari po razlicitim prozorima
        // TODO: drrep.GetByID mozda treba da ima GetAll() iz drrep iznad njega

        private String FileLocation = "../../Text Files/holidayrequests.txt";
        public List<HolidayRequest> HolidayRequestsInFile = new List<HolidayRequest>();

        // Kreira HR u listi i update-uje fajl
        public Boolean Create(HolidayRequest req)
        {
            GetAll(); // Update liste
            if (HolidayRequestsInFile.Contains(req))
            {
                return false;
            }
            else
            {
                HolidayRequestsInFile.Add(req); // Update liste
                UpdateFile(); // Update fajla
                return true;
            }
        }

        // Vraca HR iz liste
        public HolidayRequest GetByID(String id)
        {
            GetAll(); // Update liste
            foreach (HolidayRequest req in HolidayRequestsInFile)
            {
                if (req.RequestID1.Equals(id))
                {
                    return req;
                }
            }
            return null;
        }

        // Update liste u memoriji skeniranjem fajla, vraca tu istu listu
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
                DateTime requestDate = Convert.ToDateTime(components[4]);
                HolidayRequestStatus status = (HolidayRequestStatus)Convert.ToInt32(components[5]);

                // Loadovanje lekara u memoriju da bi im pristupili
                DoctorRepository drrep = new DoctorRepository();
                // drrep.DoctorsInFile = drrep.GetAll(); ? Da li GetByID ima u sebi GetAll()?
                Doctor doctor = drrep.GetByID(components[6]);

                HolidayRequest request = new HolidayRequest(id, description, startDate, endDate, requestDate, status, doctor);
                requests.Add(request);
                text = tr.ReadLine();
            }
            tr.Close();
            HolidayRequestsInFile = requests; // Update liste
            return requests;
        }

        // Vraca odredjenu listu HR iz cele liste
        public List<HolidayRequest> GetAllByDoctorID(String id)
        {
            GetAll(); // Update liste
            List<HolidayRequest> requests = new List<HolidayRequest>();
            int flag = 0;
            foreach (HolidayRequest req in HolidayRequestsInFile)
            {
                // Ako nadje Request za prosledjenog lekara, stavi ga u listu, i vrati listu
                // Ako lekar sa datim JMBG-om ne postoji u doctors.txt, vratice null
                if (req.doctor.user.Jmbg1.Equals(id))
                {
                    flag = 1;
                    requests.Add(req);
                }
            }
            if (flag == 1) return null;
            return requests;
        }

        public List<HolidayRequest> GetAllOnHold()
        {
            GetAll(); // Update liste
            List<HolidayRequest> requests = new List<HolidayRequest>();
            foreach (HolidayRequest req in HolidayRequestsInFile)
            {
                if (req.Status1.Equals(HolidayRequestStatus.OnHold))
                {
                    requests.Add(req);
                }
            }
            return requests;
        }

        // Update elementa u listi i u memoriji i u fajlu
        public Boolean Update(HolidayRequest prosledjeni)
        {
            GetAll(); // Update liste
            foreach (HolidayRequest nadjeni in HolidayRequestsInFile)
            {
                if (prosledjeni.RequestID1.Equals(nadjeni.RequestID1) && nadjeni.Status1 == HolidayRequestStatus.OnHold)
                {
                    nadjeni.Description1 = prosledjeni.Description1;
                    nadjeni.StartDate1 = prosledjeni.StartDate1;
                    nadjeni.EndDate1 = prosledjeni.EndDate1;
                    nadjeni.RequestDate1 = prosledjeni.RequestDate1; // Ovo se ipak menja
                    // Status se ne menja
                    nadjeni.doctor = prosledjeni.doctor; // Ovo se tehnicki ne menja
                    UpdateFile(); // Update fajla
                    return true;
                }
                else throw new Exception("Zahtev je vec odobren ili odbijen!");
            }
            return false;
        }

        // Lista u memoriji se upisuje u fajl
        public Boolean UpdateFile()
        {
            // Ovde se ne radi GetAll();
            TextWriter tw = new StreamWriter(FileLocation);
            if (HolidayRequestsInFile == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                // Za svaki Request pise liniju, i to mora da bude u istom formatu kao kada i cita
                foreach (HolidayRequest item in HolidayRequestsInFile)
                {
                    tw.WriteLine(item.RequestID1 + "," + item.Description1 + "," + item.StartDate1 + "," + item.EndDate1 + "," + item.RequestDate1 + "," + (int)item.Status1 + "," + item.doctor.user.Jmbg1);
                    // Datumi se ne ispisuju po onom mom formatu ali izgleda da je i ovako ok, parsira se isto
                }
                tw.Close();
                return true;
            }
        }

        // Brisanje i iz liste u memoriji, i iz fajla
        public Boolean Delete(String id)
        {
            GetAll();
            foreach (HolidayRequest hr in HolidayRequestsInFile)
            {
                if (hr.RequestID1.Equals(id))
                {
                    HolidayRequestsInFile.Remove(hr);
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean Approve(String id)
        {
            GetAll();
            foreach (HolidayRequest hr in HolidayRequestsInFile)
            {
                if (hr.RequestID1.Equals(id))
                {
                    hr.Status1 = HolidayRequestStatus.Approved;
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean Deny(String id)
        {
            GetAll();
            foreach (HolidayRequest hr in HolidayRequestsInFile)
            {
                if (hr.RequestID1.Equals(id))
                {
                    hr.Status1 = HolidayRequestStatus.Denied;
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }
    }
}