using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class DeleteRoomCommand : Command
    {
        public Room room;

        public DeleteRoomCommand(Room toDeleteRoom)
        {
            room = toDeleteRoom;
        }

        public void Execute()
        {
            room.Delete();
        }
    }
}
