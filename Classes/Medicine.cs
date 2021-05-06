/***********************************************************************
 * Module:  Medicine.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.Medicine
 ***********************************************************************/

using System;

namespace Classes
{
    public class Medicine
    {
        public string Name;
        public string Description;
        public string Ingredients;
        public string Alternatives;
        public MedicineStatus Status;

        public Medicine()
        {
        }

        public Medicine(string name, string description, string ingredients, string alternatives, MedicineStatus status)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Alternatives = alternatives;
            Status = status;
        }
    }
}