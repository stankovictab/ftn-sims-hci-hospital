/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.EquipmentService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Windows;

namespace Classes
{
    public class EquipmentController
    {
        public static StaticEquipmentRepository repo1 = new StaticEquipmentRepository();
        public static DynamicEquipmentRepository repo2 = new DynamicEquipmentRepository();
        public EquipmentService equipmentService = new EquipmentService(repo1, repo2);

        public bool AddStatic(StaticEquipment newStatic)
        {
            return equipmentService.AddStatic(newStatic);
        }

        public bool AddDynamic(DynamicEquipment newDynamic)
        {
            return equipmentService.AddDynamic(newDynamic);
        }

        public StaticEquipment GetStaticByName(string name)
        {
            return equipmentService.GetStaticByName(name);
        }

        public StaticEquipment GetStaticById(string id)
        {
            return equipmentService.GetStaticById(id);
        }

        public DynamicEquipment GetDynamicById(string id)
        {
            return equipmentService.GetDynamicById(id);
        }

        public bool UpdateDynamic(DynamicEquipment dynamic)
        {
            return equipmentService.UpdateDynamic(dynamic);
        }

        public bool UpdateStatic(StaticEquipment staticc)
        {
            return equipmentService.UpdateStatic(staticc);
        }

        public bool UpdateAllStatic(List<StaticEquipment> staticInFile)
        {
            return equipmentService.UpdateFileStatic(staticInFile);
        }

        public bool UpdateAllDynamic(List<DynamicEquipment> dynamicInFile)
        {
            return equipmentService.UpdateFileDynamic(dynamicInFile);
        }

        public List<StaticEquipment> GetAllStatic()
        {
            return equipmentService.GetAllStatic();
        }

        public List<DynamicEquipment> GetAllDynamic()
        {
            return equipmentService.GetAllDynamic();
        }

        public bool DeleteStatic(string toDelete)
        {
            return equipmentService.DeleteStatic(toDelete);
        }

        public bool DeleteDynamic(string toDelete)
        {
            return equipmentService.DeleteDynamic(toDelete);
        }
    }
}