using System;
using System.Collections.Generic;

namespace Classes
{
    public class DoctorController
    {
        private static DoctorRepository dr = new DoctorRepository();
        public DoctorService ds = new DoctorService(dr);

        public Boolean Create(Doctor d)
        {
            return ds.Create(d);
        }

        public Doctor GetByID(String id)
        {
            return ds.GetByID(id);
        }

        public List<Doctor> GetAll()
        {
            return ds.GetAll();
        }

        public Boolean Update(Doctor d)
        {
            return ds.Update(d);
        }

        public Boolean UpdateFile()
        {
            return ds.UpdateFile();
        }

        public Boolean Delete(String id)
        {
            return ds.Delete(id);
        }
    }
}