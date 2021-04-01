/***********************************************************************
 * Module:  SecretaryPatientManagement.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class SecretaryPatientManagement
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class PatientFileStorage
   {
      public Boolean Create(Patient p)
      {
         // TODO: implement
         return false;
      }
      
      public Patient GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public List<Patient> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(Patient p)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean UpdateAll(List<Patient> pif)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean Delete(String id)
      {
         // TODO: implement
         return false;
      }
   
      private String FileLocation;
      private List<Patient> PatientsInFile;
   
   }
}