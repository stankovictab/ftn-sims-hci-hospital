namespace Classes
{
    public class Manager
    {
        public DynamicEquipment[] dynamicEquipment;
        public StaticEquipment[] staticEquipment;
        public System.Collections.ArrayList staticEnschedulements;
        public System.Collections.ArrayList dynamicAssignments;
        public System.Collections.ArrayList rooms;
        public User user;

        public System.Collections.ArrayList GetStaticEnschedulements()
        {
            if (staticEnschedulements == null)
                staticEnschedulements = new System.Collections.ArrayList();
            return staticEnschedulements;
        }

        public void SetStaticEnschedulements(System.Collections.ArrayList newStaticEnschedulements)
        {
            RemoveAllStaticEnschedulements();
            foreach (StaticEnschedulement oStaticEnschedulement in newStaticEnschedulements)
                AddStaticEnschedulements(oStaticEnschedulement);
        }

        public void AddStaticEnschedulements(StaticEnschedulement newStaticEnschedulement)
        {
            if (newStaticEnschedulement == null)
                return;
            if (this.staticEnschedulements == null)
                this.staticEnschedulements = new System.Collections.ArrayList();
            if (!this.staticEnschedulements.Contains(newStaticEnschedulement))
                this.staticEnschedulements.Add(newStaticEnschedulement);
        }

        public void RemoveStaticEnschedulements(StaticEnschedulement oldStaticEnschedulement)
        {
            if (oldStaticEnschedulement == null)
                return;
            if (this.staticEnschedulements != null)
                if (this.staticEnschedulements.Contains(oldStaticEnschedulement))
                    this.staticEnschedulements.Remove(oldStaticEnschedulement);
        }

        public void RemoveAllStaticEnschedulements()
        {
            if (staticEnschedulements != null)
                staticEnschedulements.Clear();
        }

        public System.Collections.ArrayList GetDynamicAssignments()
        {
            if (dynamicAssignments == null)
                dynamicAssignments = new System.Collections.ArrayList();
            return dynamicAssignments;
        }

        public void SetDynamicAssignments(System.Collections.ArrayList newDynamicAssignments)
        {
            RemoveAllDynamicAssignments();
            foreach (DynamicAssignment oDynamicAssignment in newDynamicAssignments)
                AddDynamicAssignments(oDynamicAssignment);
        }

        public void AddDynamicAssignments(DynamicAssignment newDynamicAssignment)
        {
            if (newDynamicAssignment == null)
                return;
            if (this.dynamicAssignments == null)
                this.dynamicAssignments = new System.Collections.ArrayList();
            if (!this.dynamicAssignments.Contains(newDynamicAssignment))
                this.dynamicAssignments.Add(newDynamicAssignment);
        }

        public void RemoveDynamicAssignments(DynamicAssignment oldDynamicAssignment)
        {
            if (oldDynamicAssignment == null)
                return;
            if (this.dynamicAssignments != null)
                if (this.dynamicAssignments.Contains(oldDynamicAssignment))
                    this.dynamicAssignments.Remove(oldDynamicAssignment);
        }

        public void RemoveAllDynamicAssignments()
        {
            if (dynamicAssignments != null)
                dynamicAssignments.Clear();
        }

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