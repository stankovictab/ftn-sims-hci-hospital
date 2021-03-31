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
   public class RoomFileStorage
   {
      public Boolean Create(Room room)
      {
         // TODO: implement
         return false;
      }
      
      public Room GetById(String id)
      {
         //gde si sta ima
         return null;
      }
      
      public List<Room> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(Room room)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean UpdateAll(List<Room> rif)
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
      private List<Room> RoomsInFile;
   
   }
}