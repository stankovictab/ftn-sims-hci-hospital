using System;

namespace Classes
{
   public class Manager
   {
      public DynamicEquipment[] dynamicEquipment;
      public StaticEquipment[] staticEquipment;
      public System.Collections.ArrayList staticEnschedulements;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetStaticEnschedulements()
      {
         if (staticEnschedulements == null)
            staticEnschedulements = new System.Collections.ArrayList();
         return staticEnschedulements;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetStaticEnschedulements(System.Collections.ArrayList newStaticEnschedulements)
      {
         RemoveAllStaticEnschedulements();
         foreach (StaticEnschedulement oStaticEnschedulement in newStaticEnschedulements)
            AddStaticEnschedulements(oStaticEnschedulement);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddStaticEnschedulements(StaticEnschedulement newStaticEnschedulement)
      {
         if (newStaticEnschedulement == null)
            return;
         if (this.staticEnschedulements == null)
            this.staticEnschedulements = new System.Collections.ArrayList();
         if (!this.staticEnschedulements.Contains(newStaticEnschedulement))
            this.staticEnschedulements.Add(newStaticEnschedulement);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveStaticEnschedulements(StaticEnschedulement oldStaticEnschedulement)
      {
         if (oldStaticEnschedulement == null)
            return;
         if (this.staticEnschedulements != null)
            if (this.staticEnschedulements.Contains(oldStaticEnschedulement))
               this.staticEnschedulements.Remove(oldStaticEnschedulement);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllStaticEnschedulements()
      {
         if (staticEnschedulements != null)
            staticEnschedulements.Clear();
      }
      public System.Collections.ArrayList dynamicAssignments;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetDynamicAssignments()
      {
         if (dynamicAssignments == null)
            dynamicAssignments = new System.Collections.ArrayList();
         return dynamicAssignments;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDynamicAssignments(System.Collections.ArrayList newDynamicAssignments)
      {
         RemoveAllDynamicAssignments();
         foreach (DynamicAssignment oDynamicAssignment in newDynamicAssignments)
            AddDynamicAssignments(oDynamicAssignment);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDynamicAssignments(DynamicAssignment newDynamicAssignment)
      {
         if (newDynamicAssignment == null)
            return;
         if (this.dynamicAssignments == null)
            this.dynamicAssignments = new System.Collections.ArrayList();
         if (!this.dynamicAssignments.Contains(newDynamicAssignment))
            this.dynamicAssignments.Add(newDynamicAssignment);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDynamicAssignments(DynamicAssignment oldDynamicAssignment)
      {
         if (oldDynamicAssignment == null)
            return;
         if (this.dynamicAssignments != null)
            if (this.dynamicAssignments.Contains(oldDynamicAssignment))
               this.dynamicAssignments.Remove(oldDynamicAssignment);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDynamicAssignments()
      {
         if (dynamicAssignments != null)
            dynamicAssignments.Clear();
      }
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