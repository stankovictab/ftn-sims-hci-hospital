/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class EnschedulementService
    {
        public List<StaticEquipment> GetStaticEquipment()
        {
            // TODO: implement
            return null;
        }

        public bool CreateEnschedulement(StaticEnschedulement newEnschedulement)
        {
            if (!CheckAvailable(newEnschedulement))
                return false;

            enschedulementRepository.Create(newEnschedulement);
            return true;
        }

        public bool CheckAvailable(StaticEnschedulement newEnsch)
        {
            List<StaticEnschedulement> se = enschedulementRepository.GetAll();

            foreach(var s in se)
            {
                if (newEnsch.FromRoom.RoomNumber == s.FromRoom.RoomNumber && newEnsch.Time == s.Time && newEnsch.ToRoom.RoomNumber == s.ToRoom.RoomNumber)//unavailable ako pokusamo iz istih soba u iste sobe u isti dan
                    return false;
            }

            return true;
        }

        public bool Update()
        {
            // TODO: implement
            return false;
        }

        public bool Delete()
        {
            // TODO: implement
            return false;
        }

        public List<StaticEnschedulement> GetAll()
        {
            return enschedulementRepository.GetAll();
        }

        public EnschedulementRepository enschedulementRepository = new EnschedulementRepository();
        public System.Collections.ArrayList staticEquipmentRepository;



        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetStaticEquipmentRepository()
        {
            if (staticEquipmentRepository == null)
                staticEquipmentRepository = new System.Collections.ArrayList();
            return staticEquipmentRepository;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetStaticEquipmentRepository(System.Collections.ArrayList newStaticEquipmentRepository)
        {
            RemoveAllStaticEquipmentRepository();
            foreach (StaticEquipmentRepository oStaticEquipmentRepository in newStaticEquipmentRepository)
                AddStaticEquipmentRepository(oStaticEquipmentRepository);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddStaticEquipmentRepository(StaticEquipmentRepository newStaticEquipmentRepository)
        {
            if (newStaticEquipmentRepository == null)
                return;
            if (this.staticEquipmentRepository == null)
                this.staticEquipmentRepository = new System.Collections.ArrayList();
            if (!this.staticEquipmentRepository.Contains(newStaticEquipmentRepository))
                this.staticEquipmentRepository.Add(newStaticEquipmentRepository);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveStaticEquipmentRepository(StaticEquipmentRepository oldStaticEquipmentRepository)
        {
            if (oldStaticEquipmentRepository == null)
                return;
            if (this.staticEquipmentRepository != null)
                if (this.staticEquipmentRepository.Contains(oldStaticEquipmentRepository))
                    this.staticEquipmentRepository.Remove(oldStaticEquipmentRepository);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllStaticEquipmentRepository()
        {
            if (staticEquipmentRepository != null)
                staticEquipmentRepository.Clear();
        }

    }
}