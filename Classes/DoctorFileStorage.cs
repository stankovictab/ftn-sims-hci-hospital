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
         return null;
      }
      
      public Doctor GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(Doctor d)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean UpdateAll(List<Doctor> dif)
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
      private List<Doctor> DoctorsInFile;
   
   }
}