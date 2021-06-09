using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class UpdateRoomCommand : Command
    {
        public Room room;

        public UpdateRoomCommand(Room toUpdateRoom)
        {
            room = toUpdateRoom;
        }

        public void Execute()
        {
            room.Update();
        }
    }
}
