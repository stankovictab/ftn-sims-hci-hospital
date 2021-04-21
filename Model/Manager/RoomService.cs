/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.EquipmentService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Manager
{
    public class RoomService
    {
        public RoomRepository roomRepository = new RoomRepository();

        public bool Create(Room newRoom)
        {
            return roomRepository.Create(newRoom);
        }

        public bool Update(Room toUpdate)
        {
            return roomRepository.Update(toUpdate);
        }

        public List<Room> getAll()
        {
            return roomRepository.GetAll();
        }

        public bool Delete(String id)
        {
            return roomRepository.Delete(id);
        }

        public bool UpdateAll(List<Room> rif)
        {
            return roomRepository.UpdateAll(rif);
        }

        public Room GetById(String id)
        {
            return roomRepository.GetById(id);
        }


    }
}