/***********************************************************************
 * Module:  HolidayRequest.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Doctor.HolidayRequest
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class HolidayRequest
   {
      public Doctor doctor;
      
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
               oldDoctor.RemoveHolidayRequests(this);
            }
            if (newDoctor != null)
            {
               this.doctor = newDoctor;
               this.doctor.AddHolidayRequests(this);
            }
         }
      }
   
      private String RequestID;
      private String Description;
      private DateTime StartDate;
      private DateTime EndDate;
      private DateTime RequestDate;
      private HolidayRequestStatus Status = 0;
   
   }
}