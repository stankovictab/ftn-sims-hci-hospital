/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
   public class RoomRepository
   {
        private String FileLocation = "../../Text Files/rooms.txt";
        public List<Room> Rooms = new List<Room>();
        public StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();

        public static RoomType ParseRoomType(string input)
        {
            if (input == "Operating")
                return RoomType.Operating;
            else if (input == "Checkup")
                return RoomType.Checkup;

            return RoomType.Therapy;
        }

        public void WriteToFile(List<Room> roomsInFile)
        {
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in Rooms)
            {
                tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.RoomNumber, item.FloorNumber.ToString(), item.Description, item.Type.ToString(), item.Status.ToString()));
            }
            tw.Close();
        }

        public Boolean Create(Room room)
        {
            Rooms = GetAll();
            Rooms.Add(room);
            WriteToFile(Rooms);

            return true;
        }

        public Room GetByNumber(String roomNumber)
        {
            Rooms = GetAll();
            foreach (Room room in Rooms)
            {
                if (room.RoomNumber.Equals(roomNumber))
                {
                    return room;
                }
            }
            return null;
        }

        public List<Room> PullFromFile()
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
                RoomType type = ParseRoomType(components[3]);
                Room room = new Room(roomNumber, floorNumber, description, type, RoomStatus.Free);
                rooms.Add(room);
                text = tr.ReadLine();
            }
            tr.Close();
            return rooms;
        }

        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            rooms = PullFromFile();
            return rooms;
        }

        public Boolean Update(Room oldRoom)
        {
            foreach (Room newRoom in Rooms)
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

        public Boolean UpdateFile(List<Room> roomsInFile)
        {
            if (roomsInFile == null)
            {
                return false;
            }
            else
            {
                WriteToFile(roomsInFile);
                return true;
            }
        }

        public Boolean Delete(String roomNumber)
        {
            foreach (Room room in Rooms)
            {
                if (room.RoomNumber.Equals(roomNumber))
                {
                    Rooms.Remove(room);
                    staticEquipmentRepository.DeleteByLocation(room.RoomNumber);
                    return true;
                }
            }
            return false;
        }


        public List<Room> AccessRoomsInFile { get => Rooms; set => Rooms = value; }

        private static RoomRepository repo = null;
        public static RoomRepository getRoomStorage()
        {
            if (repo == null)
            {
                repo = new RoomRepository();
            }
            return repo;
        }

    }

}
