using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IRoomRepository
    {



        List<Room> Rooms { get; set; }
        void Renovate(Room room);


        void Reorder(Room room);


        void Free(Room room);

        Boolean Create(Room room);


        Room GetByNumber(String roomNumber);


        List<Room> GetAll();


        Boolean Update(Room oldRoom);


        Boolean UpdateFile(List<Room> roomsInFile);


        Boolean Delete(String roomNumber);
        
    }
}
