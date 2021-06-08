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
        public IEnschedulementRepository enschedulementRepository;

        public EnschedulementService(/*IEnschedulementRepository repo*/)
        {
            //this.enschedulementRepository = repo;
        }

        public List<StaticEnschedulement> DateCheck(DateTime date)
        {
            List<StaticEnschedulement> enschedulements = enschedulementRepository.GetAll();
            List<StaticEnschedulement> ret = new List<StaticEnschedulement>();
            foreach(StaticEnschedulement e in enschedulements)
            {
                if (DateTime.Compare(e.Time, date) < 0)
                    ret.Add(e);
            }

            return ret;
        }

        public bool CreateEnschedulement(StaticEnschedulement newEnschedulement)
        {
            if (!CheckAvailable(newEnschedulement))
                return false;

            enschedulementRepository.Create(newEnschedulement);
            return true;
        }

        public void UpdateTime(DateTime currentTime)
        {
            enschedulementRepository.UpdateTime(currentTime);
        }

        public Boolean Delete(StaticEnschedulement enschedulement)
        {
            return enschedulementRepository.Delete(enschedulement);
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

        public List<StaticEnschedulement> GetAll()
        {
            return enschedulementRepository.GetAll();
        }

        public List<StaticEnschedulement> GetAllFinished()
        {
            return enschedulementRepository.GetAllFinished();
        }
    }
}