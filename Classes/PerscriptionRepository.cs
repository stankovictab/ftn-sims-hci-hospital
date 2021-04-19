using System;
using System.Collections.Generic;

namespace Classes
{
    public class PerscriptionRepository
    {
        private String FileLocation;
        private List<Perscription> PerscriptionsInFile;

        public Boolean Create(Perscription per)
        {
            // TODO: implement
            return false;
        }

        public Perscription GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public List<Perscription> GetAll()
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(Perscription per)
        {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<Perscription> perscriptionsInFile)
        {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id)
        {
            // TODO: implement
            return false;
        }
    }
}