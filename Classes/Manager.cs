namespace Classes
{
    public class Manager
    {
        public User user;
        public System.Collections.ArrayList rooms;

        public System.Collections.ArrayList GetRooms()
        {
            if (rooms == null)
                rooms = new System.Collections.ArrayList();
            return rooms;
        }

        public void SetRooms(System.Collections.ArrayList newRooms)
        {
            RemoveAllRooms();
            foreach (Room oRoom in newRooms)
                AddRooms(oRoom);
        }

        public void AddRooms(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (this.rooms == null)
                this.rooms = new System.Collections.ArrayList();
            if (!this.rooms.Contains(newRoom))
                this.rooms.Add(newRoom);
        }

        public void RemoveRooms(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (this.rooms != null)
                if (this.rooms.Contains(oldRoom))
                    this.rooms.Remove(oldRoom);
        }

        public void RemoveAllRooms()
        {
            if (rooms != null)
                rooms.Clear();
        }

    }
}