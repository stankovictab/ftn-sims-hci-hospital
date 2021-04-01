/***********************************************************************
 * Module:  AppointmentFileStorage.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Patient.AppointmentFileStorage
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class AppointmentFileStorage
   {
      private String FileLocation;
      private List<Appointment> AppointmentsInFile;

      public Boolean Create(Appointment app)
      {
         // TODO: implement
         return false;
      }
      
      public Appointment GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public Appointment GetByStartTime(DateTime startTime)
      {
         // TODO: implement
         return null;
      }
      
      public List<Appointment> GetAllByDoctorID(String doctorID)
      {
         // TODO: implement
         return null;
      }
      
      public List<Appointment> GetAllByPatientID(String patientID)
      {
         // TODO: implement
         return null;
      }
      
      public List<Appointment> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(Appointment app)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean UpdateAll(List<Appointment> aif)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean Delete(String id)
      {
         // TODO: implement
         return false;
      }
   
   
   }
}