/***********************************************************************
 * Module:  Medicine.cs
 * Author:  Igor
 * Purpose: Definition of the Class Manager.Medicine
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Classes
{
    public class Medicine
    {
        public string Id;
        public string Name;
        public string Description;
        public string Ingredients;
        public string Alternatives;
        public string DenialReason;
        List<Allergy> Allergies;
        public MedicineStatus Status;

        public Medicine()
        {
        }

        public Medicine(string id, string name, string description, string ingredients, string alternatives, MedicineStatus status, string denialReason)
        {
            Id = id;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Alternatives = alternatives;
            Status = status;
            DenialReason = denialReason;
        }
    }
}