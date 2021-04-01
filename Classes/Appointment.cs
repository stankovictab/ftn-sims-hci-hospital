/***********************************************************************
 * Module:  Appointment.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Appointment
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class Appointment
   {
      public Patient patient;
      public Doctor doctor;
      private String AppointmentID;
      private DateTime StartTime;
      private DateTime EndTime;
      private AppointmentType Type;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Doctor GetDoctor()
      {
         return doctor;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newDoctor</param>
      public void SetDoctor(Doctor newDoctor)
      {
         if (this.doctor != newDoctor)
         {
            if (this.doctor != null)
            {
               Doctor oldDoctor = this.doctor;
               this.doctor = null;
               oldDoctor.RemoveAppointments(this);
            }
            if (newDoctor != null)
            {
               this.doctor = newDoctor;
               this.doctor.AddAppointments(this);
            }
         }
      }
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Patient GetPatient()
      {
         return patient;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newPatient</param>
      public void SetPatient(Patient newPatient)
      {
         if (this.patient != newPatient)
         {
            if (this.patient != null)
            {
               Patient oldPatient = this.patient;
               this.patient = null;
               oldPatient.RemoveAppointments(this);
            }
            if (newPatient != null)
            {
               this.patient = newPatient;
               this.patient.AddAppointments(this);
            }
         }
      }
   
   
   }
}