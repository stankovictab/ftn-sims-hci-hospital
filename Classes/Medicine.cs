using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public List<Allergy> Allergies;
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

            public Medicine(string id, string name, string description, string ingredients, string alternatives, MedicineStatus status, string denialReason, List<Allergy> allergies)
            {
                Id = id;
                Name = name;
                Description = description;
                Ingredients = ingredients;
                Alternatives = alternatives;
                Status = status;
                DenialReason = denialReason;
                Allergies = allergies;
            }


            public override string ToString()
            {
                return string.Format("{0}-{1}", Id, Name);
            }

    }
}
