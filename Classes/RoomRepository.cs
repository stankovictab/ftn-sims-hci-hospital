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
   public class RoomRepository : IRoomRepository
   {
        private String FileLocation = "../../Text Files/rooms.txt";
        public List<Room> Rooms { get; set; } = new List<Room>();
        public StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();

        

        public static RoomType ParseRoomType(string input)
        {
            if (input == "Operating")
                return RoomType.Operating;
            else if (input == "Checkup")
                return RoomType.Checkup;

            return RoomType.Therapy;
        }

        public void Renovate(Room room)
        { 
            room.Status = RoomStatus.Renovating;
            Update(room);
            UpdateFile(Rooms);
        }

        public void Reorder(Room room)
        { 
            room.Status = RoomStatus.Reordering;
            Update(room);
            UpdateFile(Rooms);
        }

        public void Free(Room room)
        { 
            room.Status = RoomStatus.Free;
            Update(room);
            UpdateFile(Rooms); ;
        }

        public static RoomStatus ParseRoomStatus(string input)
        {
            if (input == "Free")
                return RoomStatus.Free;
            else if (input == "Reordering")
                return RoomStatus.Reordering;
            else if (input == "Renovating")
                return RoomStatus.Renovating;

            return RoomStatus.Busy;
        }

        public void WriteToFile(List<Room> roomsInFile)
        { 
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in roomsInFile)
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
                RoomStatus status = ParseRoomStatus(components[4]);
                Room room = new Room(roomNumber, floorNumber, description, type, status);
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
            Rooms = GetAll();
            foreach (Room newRoom in Rooms)
            {
                if (newRoom.RoomNumber.Equals(oldRoom.RoomNumber))
                {
                    newRoom.RoomNumber = oldRoom.RoomNumber;
                    newRoom.FloorNumber = oldRoom.FloorNumber;
                    newRoom.Description = oldRoom.Description;
                    newRoom.Type = oldRoom.Type;
                    newRoom.Status = oldRoom.Status;
                    UpdateFile(Rooms);
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
            Rooms = GetAll();
            foreach (Room room in Rooms)
            {
                if (room.RoomNumber.Equals(roomNumber))
                {
                    Rooms.Remove(room);
                    staticEquipmentRepository.DeleteByLocation(room.RoomNumber);
                    UpdateFile(Rooms);
                    return true;
                }
            }
            return false;
        }


        public List<Room> AccessRooms { get => Rooms; set => Rooms = value; }

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
