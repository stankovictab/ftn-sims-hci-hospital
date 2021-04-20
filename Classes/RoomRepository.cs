using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class RoomRepository
    {
        private String FileLocation;
        private List<Room> RoomsInFile = new List<Room>();

		public List<Room> AccessRoomsInFile { get => RoomsInFile; set => RoomsInFile = value; }

		public RoomRepository()
        {
            FileLocation = "../../Text Files/rooms.txt";
        }

		private static RoomRepository RoomStorage = null;
        public static RoomRepository getRoomStorage()
        {
            if (RoomStorage == null)
            {
                RoomStorage = new RoomRepository();
            }
            return RoomStorage;
        }

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
                tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.RoomNumber1, item.FloorNumber1.ToString(), item.Description1, item.Type1.ToString(), item.Status1.ToString()));
            }
            tw.Close();

            return true;
        }

        public Room GetById(String id)
        {
            foreach (Room room in RoomsInFile)
            {
                if (room.RoomNumber1.Equals(id))
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
                if (newRoom.RoomNumber1.Equals(oldRoom.RoomNumber1))
                {
                    newRoom.RoomNumber1 = oldRoom.RoomNumber1;
                    newRoom.FloorNumber1 = oldRoom.FloorNumber1;
                    newRoom.Description1 = oldRoom.Description1;
                    newRoom.Type1 = oldRoom.Type1;
                    newRoom.Status1 = oldRoom.Status1;
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
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.RoomNumber1, item.FloorNumber1.ToString(), item.Description1, item.Type1.ToString(), item.Status1.ToString()));
                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(String id)
        {
            foreach (Room room in RoomsInFile)
            {
                if (room.RoomNumber1.Equals(id))
                {
                    RoomsInFile.Remove(room);
                    return true;
                }
            }
            return false;
        }
    }
}