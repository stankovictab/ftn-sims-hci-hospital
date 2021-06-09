using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class AddRoomCommand : Command
    {
        public Room room;

        public AddRoomCommand(Room newRoom)
        {
            room = newRoom;
        }

        public void Execute()
        {
            room.Add();
        }
    }
}
