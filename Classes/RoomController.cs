/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.EquipmentService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class RoomController
    {
        public static RoomRepository repo = new RoomRepository();
        public RoomService roomService = new RoomService(repo);
        public bool Create(Room newRoom)
        {
            return roomService.Create(newRoom);
        }

        public bool Update(Room toUpdate)
        {
            return roomService.Update(toUpdate);
        }

        public List<Room> GetAll()
        {
            return roomService.getAll();
        }

        public bool Delete(String id)
        {
            return roomService.Delete(id);
        }

        public bool UpdateFile(List<Room> rif)
        {
            return roomService.UpdateFile(rif);
        }

        public Room GetById(String id)
        {
            return roomService.GetById(id);
        }
    }
}