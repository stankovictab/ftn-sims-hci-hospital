using System;

namespace Classes
{
    public class Perscription
    {
        public Medicine Medicine { get; set; }
        public int Amount { get; set; }
        public String Description { get; set; }
        public String Id { get; set; }

        public Perscription(String id,Medicine medicine,int amount,String description)
        {
            Medicine = medicine;
            Amount = amount;
            Description = description;
            Id = id;
        }
        public Perscription(String id, String medicine, int amount, String description)
        {
            Medicine = new Medicine();
            Medicine.Name = medicine;
            Amount = amount;
            Description = description;
            Id = id;
        }

    }
}