using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class IRoomRepository
    {
        RoomRepository roomRepository;
        public IRoomRepository(RoomRepository repo)
        {
            this.roomRepository = repo;
        }

        public List<Room> AccessRooms { get => roomRepository.Rooms; set => roomRepository.Rooms = value; }


        public void Renovate(Room room)
        {
            this.roomRepository.Renovate(room);
        }

        public void Reorder(Room room)
        {
            this.roomRepository.Reorder(room);
        }

        public void Free(Room room)
        {
            this.roomRepository.Free(room);
        }

        public Boolean Create(Room room)
        {
            return this.roomRepository.Create(room);
        }

        public Room GetByNumber(String roomNumber)
        {
            return this.roomRepository.GetByNumber(roomNumber);
        }

        public List<Room> GetAll()
        {
            return this.roomRepository.GetAll();
        }

        public Boolean Update(Room oldRoom)
        {
            return this.roomRepository.Update(oldRoom);
        }

        public Boolean UpdateFile(List<Room> roomsInFile)
        {
            return this.roomRepository.UpdateFile(roomsInFile);
        }

        public Boolean Delete(String roomNumber)
        {
            return this.roomRepository.Delete(roomNumber);
        }
    }
}
