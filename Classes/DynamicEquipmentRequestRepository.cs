using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class DynamicEquipmentRequestRepository
    {
        private String FileLocation = "../../Text Files/dynamicequipmentrequests.txt";
        private List<DynamicEquipmentRequest> DynamicEquipmentRequestsInFile = new List<DynamicEquipmentRequest>();

        public Boolean Create(DynamicEquipmentRequest req)
        {
            GetAll(); // Update liste
            if (DynamicEquipmentRequestsInFile.Contains(req))
            {
                return false;
            }
            else
            {
                DynamicEquipmentRequestsInFile.Add(req); // Update liste
                UpdateFile(); // Update fajla
                return true;
            }
        }

        public DynamicEquipmentRequest GetByID(String id)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentRequest req in DynamicEquipmentRequestsInFile)
            {
                if (req.RequestID1.Equals(id))
                {
                    return req;
                }
            }
            return null;
        }

        // Update liste u memoriji skeniranjem fajla, vraca tu istu listu
        public List<DynamicEquipmentRequest> GetAll()
        {
            List<DynamicEquipmentRequest> requests = new List<DynamicEquipmentRequest>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(','); // Po defaultu su svi componenti stringovi, pa za neke mora convert
                string id = components[0];
                string equipmentName = components[1];
                string equipmentAmount = components[2];
                DateTime requestDate = Convert.ToDateTime(components[3]);
                DynamicEquipmentRequestStatus status = (DynamicEquipmentRequestStatus)Convert.ToInt32(components[4]);
                bool ordered = bool.Parse(components[5]);

                // Loadovanje lekara u memoriju da bi im pristupili
                DoctorRepository drrep = new DoctorRepository();
                // drrep.DoctorsInFile = drrep.GetAll(); ? Da li GetByID ima u sebi GetAll()?
                Doctor doctor = drrep.GetByID(components[6]);

                string commentary = components[7];
                DynamicEquipmentRequest request = new DynamicEquipmentRequest(id, equipmentName, equipmentAmount, requestDate, status, ordered, doctor, commentary);
                requests.Add(request);
                text = tr.ReadLine();
            }
            tr.Close();
            DynamicEquipmentRequestsInFile = requests; // Update liste
            return requests;
        }

        public List<DynamicEquipmentRequest> GetAllByDoctorID(String id)
        {
            GetAll(); // Update liste
            List<DynamicEquipmentRequest> requests = new List<DynamicEquipmentRequest>();
            int flag = 0;
            foreach (DynamicEquipmentRequest req in DynamicEquipmentRequestsInFile)
            {
                // Ako nadje Request za prosledjenog lekara, stavi ga u listu, i vrati listu
                // Ako lekar sa datim JMBG-om ne postoji u doctors.txt, vratice null
                if (req.doctor.user.Jmbg1.Equals(id))
                {
                    flag = 1;
                    requests.Add(req);
                }
            }
            if (flag == 0) return null;
            return requests;
        }

        public List<DynamicEquipmentRequest> GetAllOnHold()
        {
            GetAll(); // Update liste
            List<DynamicEquipmentRequest> requests = new List<DynamicEquipmentRequest>();
            foreach (DynamicEquipmentRequest req in DynamicEquipmentRequestsInFile)
            {
                // Ako nadje Request za prosledjenog lekara, stavi ga u listu, i vrati listu
                // Ako lekar sa datim JMBG-om ne postoji u doctors.txt, vratice null
                if (req.Status1.Equals(DynamicEquipmentRequestStatus.OnHold))
                {
                    requests.Add(req);
                }
            }
            return requests;
        }

        public Boolean Update(DynamicEquipmentRequest prosledjeni)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentRequest nadjeni in DynamicEquipmentRequestsInFile)
            {
                if (prosledjeni.RequestID1.Equals(nadjeni.RequestID1))
                // Uslov && nadjeni.Status1 == DynamicEquipmentRequestStatus.OnHold nije potreban jer se ta provera vec radi u WPF-u, bolje je korisnik tamo da vidi da ne moze da update-uje tako nego odavde
                {
                    nadjeni.EquipmentName1 = prosledjeni.EquipmentName1;
                    nadjeni.EquipmentAmount1 = prosledjeni.EquipmentAmount1;
                    nadjeni.RequestDate1 = prosledjeni.RequestDate1; // Ovo se ipak menja
                    // Status i doktor se ne menjaju
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
            if (DynamicEquipmentRequestsInFile == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                // Za svaki Request pise liniju, i to mora da bude u istom formatu kao kada i cita
                foreach (DynamicEquipmentRequest item in DynamicEquipmentRequestsInFile)
                {
                    tw.WriteLine(item.RequestID1 + "," + item.EquipmentName1 + "," + item.EquipmentAmount1 + "," + item.RequestDate1 + "," + (int)item.Status1 + "," + item.Ordered1 + "," + item.doctor.user.Jmbg1 + "," + item.Commentary1);
                    // Datumi se ne ispisuju po onom mom formatu ali izgleda da je i ovako ok, parsira se isto
                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(String id)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentRequest hr in DynamicEquipmentRequestsInFile)
            {
                if (hr.RequestID1.Equals(id))
                {
                    DynamicEquipmentRequestsInFile.Remove(hr);
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean Approve(String id, String commentary)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentRequest hr in DynamicEquipmentRequestsInFile)
            {
                if (hr.RequestID1.Equals(id))
                {
                    hr.Status1 = DynamicEquipmentRequestStatus.Approved;
                    hr.Commentary1 = commentary;
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean Deny(String id, String commentary)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentRequest hr in DynamicEquipmentRequestsInFile)
            {
                if (hr.RequestID1.Equals(id))
                {
                    hr.Status1 = DynamicEquipmentRequestStatus.Denied;
                    hr.Commentary1 = commentary;
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean SetAllApprovedToOrdered()
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentRequest hr in DynamicEquipmentRequestsInFile)
                if (hr.Status1.Equals(DynamicEquipmentRequestStatus.Approved))
                    hr.Ordered1 = true;
            UpdateFile(); // Update fajla
            return true;
        }
    }
}