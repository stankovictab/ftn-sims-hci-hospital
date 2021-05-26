using System;
namespace Classes
{
    public class Allergy
    {
        private String Name;
        private int Id;

        public int Id1 { get => Id; set => Id = value; }
        public string Name1 { get => Name; set => Name = value; }

        public Allergy(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public Allergy(string name)
        {
            Name = name;
        }
    }
}