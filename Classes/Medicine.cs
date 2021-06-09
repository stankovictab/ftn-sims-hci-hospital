using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Medicine
    {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Ingredients { get; set; }
            public string Alternatives { get; set; }
            public string DenialReason { get; set; }
            public List<Allergy> Allergies { get; set; }
            public MedicineStatus Status { get; set; }



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
