/***********************************************************************
 * Module:  ManagerFileStorage.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Manager.ManagerFileStorage
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class DoctorFileStorage
   {
      public Boolean Create(Doctor d)
      {
         // TODO: implement
         return false;
      }
      
      public Doctor GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(Doctor d)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean UpdateAll(List<Doctor> dif)
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
      private List<Doctor> DoctorsInFile;
   
   }
}