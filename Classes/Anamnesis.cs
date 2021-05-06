using System;
namespace Classes
{
    public class Anamnesis
    {
        public String Id { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }

        public Anamnesis(String id, String description, DateTime dateTime)
        {
            Id = id;
            Description = description;
            Date = dateTime;
        }
    }
}