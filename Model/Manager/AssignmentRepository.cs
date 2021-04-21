/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

namespace Manager
{
    public class AssignmentRepository
    {
        private String FileLocation = @"C:\Users\Igor\Desktop\ManagerKT3\ManagerKT3\Text Files\assignments.txt";
        public List<DynamicAssignment> AssignmentsInFile = new List<DynamicAssignment>();
        public DynamicEquipmentRepository dynamicEquipmentRepository = new DynamicEquipmentRepository();

        public Boolean Create(DynamicAssignment newAssignment)
        {
            AssignmentsInFile = GetAll();
            AssignmentsInFile.Add(newAssignment);
            TextWriter tw = new StreamWriter(FileLocation);

            foreach (var item in AssignmentsInFile)
            {
                tw.WriteLine(string.Format("{0},{1},{2}",item.IdAssign, item.EquipmentAssigned.dynamicName , item.AmountAssigned));
            }
            tw.Close();

            return true;
        }

        public DynamicAssignment GetById(int id)
        {
            // TODO: implement
            return null;
        }

        

        public List<DynamicAssignment> GetAll()
        {
            List<DynamicAssignment> da = new List<DynamicAssignment>();
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
                da.Add(newAssignment);
                text = tr.ReadLine();
            }
            tr.Close();
            return da;
        }

        public Boolean Update(DynamicAssignment updateAssign)
        {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<DynamicAssignment> aif)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(int id)
        {
            // TODO: implement
            return false;
        }

    }
}