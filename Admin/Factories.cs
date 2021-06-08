using Classes;
using ftn_sims_hci_hospital.Classes;
using System;

namespace ftn_sims_hci_hospital.Admin
{
    public abstract class AbstractFactory
    {
        public abstract Object getConcreteObject(ConstructorType type);
    }

    public class RequestFactory : AbstractFactory
    {
        private String Description; // Iz HolidayRequest
        private DateTime StartDate; // Iz HolidayRequest
        private DateTime EndDate; // Iz HolidayRequest
        private String EquipmentName; // Iz DynamicEquipmentRequest
        private String EquipmentAmount; // Iz DynamicEquipmentRequest
        private bool Ordered; // Iz DynamicEquipmentRequest
        private string Commentary; // Iz Request
        private RequestStatus Status; // Iz Request
        public Doctor doctor; // Iz Request
        private String ID; // Iz Demand
        private DateTime CreationDate; // Iz Demand

        // HRFull
        public RequestFactory(String ID, String Description, DateTime StartDate, DateTime EndDate, DateTime CreationDate, RequestStatus Status, Doctor doctor, string commentary)
        {
            this.ID = ID;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreationDate = CreationDate;
            this.Status = Status;
            this.doctor = doctor;
            this.Commentary = commentary;
        }
        // HRCreation
        public RequestFactory(String Description, DateTime StartDate, DateTime EndDate, Doctor doctor)
        {
            this.ID = null;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreationDate = DateTime.Now;
            this.Status = RequestStatus.OnHold;
            this.doctor = doctor;
            this.Commentary = "/";
        }
        // HRUpdate
        public RequestFactory(String ID, String Description, DateTime StartDate, DateTime EndDate)
        {
            this.ID = ID;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CreationDate = DateTime.Now;
            this.Status = RequestStatus.OnHold;
            this.doctor = null;
            this.Commentary = "/";
        }
        // DERFull
        public RequestFactory(String ID, String EquipmentName, String EquipmentAmount, DateTime CreationDate, RequestStatus Status, bool ordered, Doctor doctor, string commentary)
        {
            this.ID = ID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = EquipmentAmount;
            this.CreationDate = CreationDate;
            this.Status = Status;
            this.Ordered = ordered; // Ne moze uvek false da bude
            this.doctor = doctor;
            this.Commentary = commentary;
        }
        // DERCreation
        public RequestFactory(String EquipmentName, Doctor Doctor)
        {
            this.ID = null;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = "0";
            this.CreationDate = DateTime.Now;
            this.Status = RequestStatus.OnHold;
            this.Ordered = false;
            this.doctor = Doctor;
            this.Commentary = "/";
        }
        // DERUpdate
        public RequestFactory(String ID, String EquipmentName, String EquipmentAmount)
        {
            this.ID = ID;
            this.EquipmentName = EquipmentName;
            this.EquipmentAmount = EquipmentAmount;
            this.CreationDate = DateTime.Now;
            this.Status = RequestStatus.OnHold;
            this.Ordered = false;
            this.doctor = null;
            this.Commentary = "/";
        }

        public override Object getConcreteObject(ConstructorType type)
        {
            switch (type)
            {
                case ConstructorType.HolidayRequestFull:
                    return new HolidayRequest(this.ID, this.Description, this.StartDate, this.EndDate, this.CreationDate, this.Status, this.doctor, this.Commentary);
                case ConstructorType.HolidayRequestCreation:
                    return new HolidayRequest(this.Description, this.StartDate, this.EndDate, this.doctor);
                case ConstructorType.HolidayRequestUpdate:
                    return new HolidayRequest(this.ID, this.Description, this.StartDate, this.EndDate);
                case ConstructorType.DynamicEquipmentRequestFull:
                    return new DynamicEquipmentRequest(this.ID, this.EquipmentName, this.EquipmentAmount, this.CreationDate, this.Status, this.Ordered, this.doctor, this.Commentary);
                case ConstructorType.DynamicEquipmentRequestCreation:
                    return new DynamicEquipmentRequest(this.EquipmentName, this.doctor);
                case ConstructorType.DynamicEquipmentRequestUpdate:
                    return new DynamicEquipmentRequest(this.ID, this.EquipmentName, this.EquipmentAmount);
                default: throw new Exception("Invalid Request Type!");
            }
        }
    }
    public class OrderFactory : AbstractFactory
    {
        private string EquipmentNames; // List<String>?
        private string EquipmentAmounts; // List<int>?
        private OrderStatus Status; // Iz Order
        private String ID; // Iz Demand
        private DateTime CreationDate; // Iz Demand

        // Full
        public OrderFactory(String ID, string equipmentNames, string equipmentAmounts, DateTime CreationDate, OrderStatus Status)
        {
            this.ID = ID;
            this.EquipmentNames = equipmentNames;
            this.EquipmentAmounts = equipmentAmounts;
            this.CreationDate = CreationDate;
            this.Status = Status;
        }

        // DEOCreation
        public OrderFactory(string equipmentNames, string equipmentAmounts)
        {
            this.ID = null;
            this.EquipmentNames = equipmentNames;
            this.EquipmentAmounts = equipmentAmounts;
            this.CreationDate = DateTime.Now;
            this.Status = OrderStatus.Sent;
        }

        public override Object getConcreteObject(ConstructorType type)
        {
            switch (type)
            {
                case ConstructorType.DynamicEquipmentOrderFull:
                    return new DynamicEquipmentOrder(this.ID, this.EquipmentNames, this.EquipmentAmounts, this.CreationDate, this.Status);
                case ConstructorType.DynamicEquipmentOrderCreation:
                    return new DynamicEquipmentOrder(this.EquipmentNames, this.EquipmentAmounts);
                // Mozda ce imati i case za StaticEquipmentOrder
                default: throw new Exception("Invalid Order Type!");
            }
        }
    }
    public class PollFactory : AbstractFactory
    {
        private Patient patient;
        private Doctor doctor;
        private int mark;
        private String comment;

        // Prazan konstruktor za oba tipa ankete, sve postavlja na null
        public PollFactory() {
            this.patient = null;
            this.doctor = null;
            this.mark = 0;
            this.comment = null;
        }

        // HospitalPoll Constructor
        public PollFactory(Patient patient, int mark, String comment) {
            this.patient = patient;
            this.doctor = null; // Mozda nepotrebno?
            this.mark = mark;
            this.comment = comment;
        }

        // DoctorPoll Constructor
        public PollFactory(Patient patient, Doctor doctor, int mark, String comment) {
            this.patient = patient;
            this.doctor = doctor;
            this.mark = mark;
            this.comment = comment;
        }

        public override Object getConcreteObject(ConstructorType type)
        {
            switch (type)
            {
                case ConstructorType.HospitalPoll:
                    return new HospitalPoll(this.patient, this.mark, this.comment);
                case ConstructorType.DoctorPoll:
                    return new DoctorPoll(this.patient, this.doctor, this.mark, this.comment);
                default: throw new Exception("Invalid Poll Type!");
            }
        }
    }

    public enum ConstructorType
    {
        // Prazni konstruktori nisu nigde korisceni
        HolidayRequestFull,
        HolidayRequestCreation,
        HolidayRequestUpdate,
        DynamicEquipmentRequestFull,
        DynamicEquipmentRequestCreation,
        DynamicEquipmentRequestUpdate,
        DynamicEquipmentOrderFull,
        DynamicEquipmentOrderCreation,
        HospitalPoll,
        DoctorPoll
    }

    /*public enum RequestType
    {
        Holiday,
        DynamicEquipment
    }
    public enum OrderType
    {
        DynamicEquipment 
        // Mozda ce imati i StaticEquipment
    }
    public enum PollType
    {
        Hospital,
        Doctor
    }*/
}
