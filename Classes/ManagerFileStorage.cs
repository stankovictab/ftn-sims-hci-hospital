/***********************************************************************
 * Module:  ManagerFileStorage.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Manager.ManagerFileStorage
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
   public class ManagerFileStorage
   {
      public Boolean Create(Manager m)
      {
         // TODO: implement
         return null;
      }
      
      public Manager GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(Manager m)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean UpdateAll(List<Manager> mif)
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
      private List<Manager> ManagersInFile;
   
   }
}