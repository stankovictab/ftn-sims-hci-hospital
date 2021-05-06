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
    public class EquipmentService
    {
        public StaticEquipmentRepository staticEquipmentRepository = new StaticEquipmentRepository();
        public DynamicEquipmentRepository dynamicEquipmentRepository = new DynamicEquipmentRepository();

        public bool AddStatic(StaticEquipment newStatic)
        {
            return staticEquipmentRepository.Create(newStatic);
        }

        public bool AddDynamic(DynamicEquipment newDynamic)
        {
            return dynamicEquipmentRepository.Create(newDynamic);
        }

        public StaticEquipment GetStaticByName(string name)
        {
            return staticEquipmentRepository.GetByName(name);
        }
        public bool DeleteStatic(string toDelete)
        {
            int idd = Convert.ToInt32(toDelete);
            return staticEquipmentRepository.Delete(idd);
        }

        public bool DeleteDynamic(string toDelete)
        {
            int idd = Convert.ToInt32(toDelete);
            return dynamicEquipmentRepository.Delete(idd);
        }

        public StaticEquipment GetStaticById(string id)
        {
            int idd = Convert.ToInt32(id);
            return staticEquipmentRepository.GetById(idd);
        }

        public DynamicEquipment GetDynamicById(string id)
        {
            int idd = Convert.ToInt32(id);
            return dynamicEquipmentRepository.GetById(idd);
        }

        public bool UpdateStatic(StaticEquipment staticc)
        {
            return staticEquipmentRepository.Update(staticc);
        }

        public bool UpdateDynamic(DynamicEquipment dynamic)
        {
            return dynamicEquipmentRepository.Update(dynamic);
        }

        public List<StaticEquipment> GetAllStatic()
        {
            return staticEquipmentRepository.GetAll();
        }

        public List<DynamicEquipment> GetAllDynamic()
        {
            return dynamicEquipmentRepository.GetAll();
        }

        public bool UpdateFileStatic(List<StaticEquipment> staticc)
        {
            return staticEquipmentRepository.UpdateAll(staticc);
        }

        public bool UpdateFileDynamic(List<DynamicEquipment> dynamic)
        {
            return dynamicEquipmentRepository.UpdateFile(dynamic);
        }
    }
}