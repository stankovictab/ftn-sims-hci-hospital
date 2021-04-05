using System;
using System.Collections.Generic;

namespace Classes
{
    public class SecretaryFileStorage
    {
        private String FileLocation = "../../Text Files/secretaries.txt";
        private List<Secretary> SecretariesInFile;

        public Boolean Create(Secretary s)
        {
            // TODO: implement
            return false;
        }

        public Secretary GetByID(String id)
        {
            // TODO: implement
            return null;
        }

        public Boolean Update(Secretary s)
        {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<Secretary> sif)
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