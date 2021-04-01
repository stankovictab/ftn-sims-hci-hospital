/***********************************************************************
 * Module:  SecretaryPatientManagement.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class SecretaryPatientManagement
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Classes
{
   public class PatientFileStorage
   {
        private String FileLocation = "patients.txt";
        private List<Patient> PatientsInFile=new List<Patient>();

        public List<Patient> PatientsInFile1 { get => PatientsInFile; set => PatientsInFile = value; }

        public Boolean Create(Patient p)
      {
            if (PatientsInFile.Contains(p))
            {
                return false;
            }
            else
            {
                PatientsInFile.Add(p);
                return true;
            }

      }

      public Patient GetByID(String id)
      {
         foreach(Patient patient in PatientsInFile)
         {
                if(patient.user.Jmbg1.Equals(id))
                {
                    return patient;
                }
         }
         return null;
      }

      public List<Patient> GetAll()
      {
            List<Patient> patients = new List<Patient>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while(text!=null&&text!="\n")
            {
                string[] components = text.Split(',');
                string name = components[0];
                string lastname = components[1];
                string username = components[2];
                string password = components[3];
                string email = components[4];
                string jmbg = components[5];
                string address = components[6];
                char gender = Convert.ToChar(components[7]);
                User user = new User(name, lastname, username, password, email, jmbg, address, gender, false, Roles.Patient);
                Patient patient = new Patient(user, null, null);
                patients.Add(patient);
                text = tr.ReadLine();
            }
            tr.Close();
            return patients;
      }

      public Boolean Update(Patient p)
      {
         foreach(Patient patient in PatientsInFile)
         {
                if(p.user.Jmbg1.Equals(patient.user.Jmbg1))
                {
                    patient.user.Password1 = p.user.Password1;
                    patient.user.Username1 = p.user.Username1;
                    patient.user.Email1 = p.user.Email1;
                    patient.user.Name1 = p.user.Name1;
                    patient.user.LastName1 = p.user.LastName1;
                    patient.user.Address1 = p.user.Address1;
                    patient.user.Gender1= p.user.Gender1;
                    return true;
                }
         }
         return false;
      }

      public Boolean UpdateAll(List<Patient> pif)
      {
            TextWriter tw = new StreamWriter(FileLocation);
            if (pif == null)
            {
                tw.Close();
                return false;

            }
            else
            {
                foreach (Patient p in pif)
                {
                    tw.WriteLine(p.user.Name1 + "," + p.user.LastName1 + "," + p.user.Username1 + "," + p.user.Password1 + "," + p.user.Email1 + "," + p.user.Jmbg1 + "," + p.user.Address1 + "," + p.user.Gender1);
                }
                tw.Close();
                return true;
            }
      }

      public Boolean Delete(String id)
      {
            foreach (Patient patient in PatientsInFile)
            {
                if (patient.user.Jmbg1.Equals(id))
                {
                    PatientsInFile.Remove(patient);
                    return true;
                }
            }
            return false;
      }



   }
}