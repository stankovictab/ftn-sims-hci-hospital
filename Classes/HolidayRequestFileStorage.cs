/***********************************************************************
 * Module:  RoomFileStorage.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Manager.RoomFileStorage
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class HolidayRequestFileStorage
   {
      public Boolean Create(HolidayRequest req)
      {
         // TODO: implement
         return null;
      }
      
      public HolidayRequest GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public List<HolidayRequest> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public List<HolidayRequest> GetAllByDoctorID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(HolidayRequest req)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean UpdateAll(List<HolidayRequest> hrif)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Delete(String id)
      {
         // TODO: implement
         return null;
      }
   
      private String FileLocation;
      private List<HolidayRequest> HolidayRequestsInFile;
   
   }
}