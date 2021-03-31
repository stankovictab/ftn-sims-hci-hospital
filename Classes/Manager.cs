using System;

namespace Classes
{
    public class Manager
    {
        public User user;
        public System.Collections.ArrayList rooms;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetRooms()
        {
            if (rooms == null)
                rooms = new System.Collections.ArrayList();
            return rooms;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetRooms(System.Collections.ArrayList newRooms)
        {
            RemoveAllRooms();
            foreach (Room oRoom in newRooms)
                AddRooms(oRoom);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddRooms(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (this.rooms == null)
                this.rooms = new System.Collections.ArrayList();
            if (!this.rooms.Contains(newRoom))
                this.rooms.Add(newRoom);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveRooms(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (this.rooms != null)
                if (this.rooms.Contains(oldRoom))
                    this.rooms.Remove(oldRoom);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllRooms()
        {
            if (rooms != null)
                rooms.Clear();
        }

    }
}