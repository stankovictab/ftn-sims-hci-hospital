/***********************************************************************
 * Module:  ManagerFileStorage.cs
 * Author:  stankovictab
 * Purpose: Definition of the Class Manager.ManagerFileStorage
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes {
    public class DoctorFileStorage {
        private String FileLocation = "doctors.txt";
        private List<Doctor> DoctorsInFile;

        public List<Doctor> DoctorsInFile1 { get => DoctorsInFile; set => DoctorsInFile = value; }

        public Boolean Create(Doctor d) {
            // TODO: implement
            return false;
        }

        public Doctor GetByID(String id) {
            // TODO: implement
            return null;
        }

        public List<Doctor> GetAll() {
            // TODO: implement
            return null;
        }

        public Boolean Update(Doctor d) {
            // TODO: implement
            return false;
        }

        public Boolean UpdateAll(List<Doctor> dif) {
            // TODO: implement
            return false;
        }

        public Boolean Delete(String id) {
            // TODO: implement
            return false;
        }


    }
}