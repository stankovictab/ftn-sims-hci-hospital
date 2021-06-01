/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.EquipmentService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
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

        public bool UpdateFile(List<Room> rif)
        {
            return roomRepository.UpdateFile(rif);
        }

        public Room GetById(String roomNumber)
        {
            return roomRepository.GetByNumber(roomNumber);
        }


    }
}