using System;
namespace Classes
{
    public class DynamicEquipmentRequest
    {
        private String RequestID;
        private String EquipmentName;
        private DateTime RequestDate;
        //private String Status = 0; // hwat

        public Doctor doctor;

        public Doctor GetDoctor()
        {
            return doctor;
        }

        public void SetDoctor(Doctor newDoctor)
        {
            if (this.doctor != newDoctor)
            {
                if (this.doctor != null)
                {
                    Doctor oldDoctor = this.doctor;
                    this.doctor = null;
                    oldDoctor.RemoveDynamicEquipmentRequests(this);
                }
                if (newDoctor != null)
                {
                    this.doctor = newDoctor;
                    this.doctor.AddDynamicEquipmentRequests(this);
                }
            }
        }
    }
}