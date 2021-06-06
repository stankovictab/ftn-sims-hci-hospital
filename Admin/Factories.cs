using Classes;
using ftn_sims_hci_hospital.Classes;
using System;

namespace ftn_sims_hci_hospital.Admin
{
    // Ne moze da se koristi Abstract Factory ako metode za kreiranje konkretnih objekata imaju razlicite parametre
    // Dakle, moramo imati odvojene fabrike koje ne nasledjuju jednu apstraktnu sa odredjenom predefinisanom metodom

    /*public abstract class AbstractFactory
    {
        protected abstract Object getObject();
    }*/

    public class FactoryProducer
    {
        public FactoryProducer() { }

        public RequestFactory getRequestFactory()
        {
            return new RequestFactory();
        }
        public OrderFactory getOrderFactory()
        {
            return new OrderFactory();
        }

        public PollFactory getPollFactory()
        {
            return new PollFactory();
        }
    }

    public class RequestFactory
    {
        public Request getRequest(RequestType type)
        {
            switch (type)
            {
                case RequestType.Holiday:
                    return new HolidayRequest();
                case RequestType.DynamicEquipment:
                    return new DynamicEquipmentRequest();
                default: throw new Exception("Invalid Request Type!");
            }
        }
    }
    public class OrderFactory
    {
        public Order getOrder(OrderType type)
        {
            switch (type)
            {
                case OrderType.DynamicEquipment:
                    return new DynamicEquipmentOrder();
                // Mozda ce imati i case za StaticEquipmentOrder
                default: throw new Exception("Invalid Order Type!");
            }
        }
    }
    public class PollFactory
    {
        public Poll getPoll(PollType type)
        {
            switch (type)
            {
                case PollType.Hospital:
                    return new HospitalPoll();
                case PollType.Doctor:
                    return new DoctorPoll();
                default: throw new Exception("Invalid Poll Type!");
            }
        }
    }

    public enum RequestType
    {
        Holiday,
        DynamicEquipment
    }
    public enum OrderType
    {
        DynamicEquipment // Mozda ce imati i StaticEquipment
    }
    public enum PollType
    {
        Hospital,
        Doctor
    }
}
