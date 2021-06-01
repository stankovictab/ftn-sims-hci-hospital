/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class AssignmentRepository
    {
        private String FileLocation = "../../Text Files/assignments.txt";
        public List<DynamicAssignment> Assignments = new List<DynamicAssignment>();
        public DynamicEquipmentRepository dynamicEquipmentRepository = new DynamicEquipmentRepository();


        public void WriteToFile(List<DynamicAssignment> assignmentsInFile)
        {
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in assignmentsInFile)
            {
                tw.WriteLine(string.Format("{0},{1},{2}", item.IdAssign, item.EquipmentAssigned.Name, item.AmountAssigned));
            }
            tw.Close();
        }
        public Boolean Create(DynamicAssignment newAssignment)
        {
            Assignments = GetAll();

            Assignments.Add(newAssignment);

            WriteToFile(Assignments);

            return true;
        }
      
        public List<DynamicAssignment> PullFromFile()
        {
            List<DynamicAssignment> dynamicAssignments= new List<DynamicAssignment>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();

            while (text != null && text != "\n")
            {
                string[] components = text.Split(',');
                int assignmentId = Convert.ToInt32(components[0]);
                string equipmentName = components[1];
                int assignmentAmount = Convert.ToInt32(components[2]);
                DynamicEquipment assignedEquipment = dynamicEquipmentRepository.GetByName(equipmentName);
                DynamicAssignment newAssignment = new DynamicAssignment(assignmentAmount, assignedEquipment, assignmentId);
                dynamicAssignments.Add(newAssignment);
                text = tr.ReadLine();
            }
            tr.Close();
            return dynamicAssignments;
        }

        public List<DynamicAssignment> GetAll()
        {
            List<DynamicAssignment> dynamicAssignments = new List<DynamicAssignment>();

            dynamicAssignments = PullFromFile();
            
            return dynamicAssignments;
        }

        public Boolean Delete(DynamicAssignment assignment)
        {
            Assignments = GetAll();
            foreach (DynamicAssignment da in Assignments)
            {
                if (da.IdAssign.Equals(assignment.IdAssign))
                {
                    Assignments.Remove(da);
                    WriteToFile(Assignments);
                    return true;
                }
            }
            return false;
        }

    }
}