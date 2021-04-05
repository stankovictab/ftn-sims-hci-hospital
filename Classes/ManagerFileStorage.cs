using System;
using System.Collections.Generic;

namespace Classes
{
    public class ManagerFileStorage
    {
        private String FileLocation = "../../Text Files/managers.txt";
        private List<Manager> ManagersInFile;

        public Boolean Create(Manager m)
        {
            // TODO: implement
            return false;
        }

        public Manager GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(Manager m)
        {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<Manager> mif)
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