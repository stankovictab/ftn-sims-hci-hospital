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
   public class SecretaryFileStorage
   {
      public Boolean Create(Secretary s)
      {
         // TODO: implement
         return false;
      }
      
      public Secretary GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(Secretary s)
      {
            // TODO: implement
            return false;
      }
      
      public Boolean UpdateAll(List<Secretary> sif)
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
      private List<Secretary> SecretariesInFile;
   
   }
}