namespace Classes
{
    public class MedicalRecord
    {
        public Patient patient;
        public System.Collections.ArrayList perscription;
        public System.Collections.ArrayList anamnesis;
        public System.Collections.ArrayList allergies;

        public System.Collections.ArrayList GetPerscription()
        {
            if (perscription == null)
                perscription = new System.Collections.ArrayList();
            return perscription;
        }

        public void SetPerscription(System.Collections.ArrayList newPerscription)
        {
            RemoveAllPerscription();
            foreach (Perscription oPerscription in newPerscription)
                AddPerscription(oPerscription);
        }

        public void AddPerscription(Perscription newPerscription)
        {
            if (newPerscription == null)
                return;
            if (this.perscription == null)
                this.perscription = new System.Collections.ArrayList();
            if (!this.perscription.Contains(newPerscription))
                this.perscription.Add(newPerscription);
        }

        public void RemovePerscription(Perscription oldPerscription)
        {
            if (oldPerscription == null)
                return;
            if (this.perscription != null)
                if (this.perscription.Contains(oldPerscription))
                    this.perscription.Remove(oldPerscription);
        }

        public void RemoveAllPerscription()
        {
            if (perscription != null)
                perscription.Clear();
        }

        public System.Collections.ArrayList GetAnamnesis()
        {
            if (anamnesis == null)
                anamnesis = new System.Collections.ArrayList();
            return anamnesis;
        }

        public void SetAnamnesis(System.Collections.ArrayList newAnamnesis)
        {
            RemoveAllAnamnesis();
            foreach (Anamnesis oAnamnesis in newAnamnesis)
                AddAnamnesis(oAnamnesis);
        }

        public void AddAnamnesis(Anamnesis newAnamnesis)
        {
            if (newAnamnesis == null)
                return;
            if (this.anamnesis == null)
                this.anamnesis = new System.Collections.ArrayList();
            if (!this.anamnesis.Contains(newAnamnesis))
                this.anamnesis.Add(newAnamnesis);
        }

        public void RemoveAnamnesis(Anamnesis oldAnamnesis)
        {
            if (oldAnamnesis == null)
                return;
            if (this.anamnesis != null)
                if (this.anamnesis.Contains(oldAnamnesis))
                    this.anamnesis.Remove(oldAnamnesis);
        }

        public void RemoveAllAnamnesis()
        {
            if (anamnesis != null)
                anamnesis.Clear();
        }

        public System.Collections.ArrayList GetAllergies()
        {
            if (allergies == null)
                allergies = new System.Collections.ArrayList();
            return allergies;
        }

        public void SetAllergies(System.Collections.ArrayList newAllergies)
        {
            RemoveAllAllergies();
            foreach (Allergy oAllergy in newAllergies)
                AddAllergies(oAllergy);
        }

        public void AddAllergies(Allergy newAllergy)
        {
            if (newAllergy == null)
                return;
            if (this.allergies == null)
                this.allergies = new System.Collections.ArrayList();
            if (!this.allergies.Contains(newAllergy))
                this.allergies.Add(newAllergy);
        }

        public void RemoveAllergies(Allergy oldAllergy)
        {
            if (oldAllergy == null)
                return;
            if (this.allergies != null)
                if (this.allergies.Contains(oldAllergy))
                    this.allergies.Remove(oldAllergy);
        }

        public void RemoveAllAllergies()
        {
            if (allergies != null)
                allergies.Clear();
        }
    }
}