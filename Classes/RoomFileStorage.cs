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
        public static RoomType ParseType(string input)
        {
            if (input == "Operating")
                return RoomType.Operating;
            else if (input == "Checkup")
                return RoomType.Checkup;

            return RoomType.Therapy;
        }

        public Boolean Create(Room room)
        {
            RoomsInFile.Add(room);
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in RoomsInFile)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.RoomNumber, item.FloorNumber.ToString(), item.Description, item.Type.ToString(), item.Status.ToString()));
            }
            tw.Close();

            return true;
        }

        public Room GetById(String id)
        {
            foreach (Room room in RoomsInFile)
            {
                if (room.RoomNumber.Equals(id))
                {
                    return room;
                }
            }
            return null;
        }

        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                string roomNumber = components[0];
                int floorNumber = Convert.ToInt32(components[1]);
                string description = components[2];
                RoomType type = ParseType(components[3]);
                Room room = new Room(roomNumber, floorNumber, description, type);
                rooms.Add(room);
                text = tr.ReadLine();
            }
            tr.Close();
            return rooms;
        }

        public Boolean Update(Room oldRoom)
        {
            foreach (Room newRoom in RoomsInFile)
            {
                if (newRoom.RoomNumber.Equals(oldRoom.RoomNumber))
                {
                    newRoom.RoomNumber = oldRoom.RoomNumber;
                    newRoom.FloorNumber = oldRoom.FloorNumber;
                    newRoom.Description = oldRoom.Description;
                    newRoom.Type = oldRoom.Type;
                    newRoom.Status = oldRoom.Status;
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateAll(List<Room> rif)
        {
            TextWriter tw = new StreamWriter(FileLocation);
            if (rif == null)
            {
                tw.Close();
                return false;

            }
            else
            {
                foreach (var item in rif)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.RoomNumber, item.FloorNumber.ToString(), item.Description, item.Type.ToString(), item.Status.ToString()));
                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(String id)
        {
            foreach (Room room in RoomsInFile)
            {
                if (room.RoomNumber.Equals(id))
                {
                    RoomsInFile.Remove(room);
                    return true;
                }
            }
            return false;
        }

        private String FileLocation = @"C:\Users\Igor\Desktop\SIMSProjekat\rooms.txt";
        private List<Room> RoomsInFile = new List<Room>();

        public List<Room> AccessRoomsInFile { get => RoomsInFile; set => RoomsInFile = value; }

        private static RoomFileStorage RoomStorage = null;
        public static RoomFileStorage getRoomStorage()
        {
            if (RoomStorage == null)
            {
                RoomStorage = new RoomFileStorage();
            }
            return RoomStorage;
        }

    }
}