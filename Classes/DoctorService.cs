using System;
using System.Collections.Generic;

namespace Classes
{
    public class DoctorService
    {
        public DoctorRepository dr = new DoctorRepository();

        public Boolean Create(Doctor d)
        {
            return dr.Create(d);
        }

        public Doctor GetByID(String id)
        {
            return dr.GetByID(id);
        }

        public List<Doctor> GetAll()
        {
            return dr.GetAll();
        }

        public Boolean Update(Doctor d)
        {
            return dr.Update(d);
        }

        public Boolean UpdateFile()
        {
            return dr.UpdateFile();
        }

        public Boolean Delete(String id)
        {
            return dr.Delete(id);
        }
    }
}