using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.Classes
{
    public class Reminder
    {
        private String id;
        private Patient patient;
        private String name;
        private String description;
        private DateTime date;
        private Boolean highlighted;
        private Boolean seen;
        private int frequencyInHours;
        public Reminder(Patient patient, String name, String description, DateTime date, Boolean highlighted, Boolean seen, int freq)
        {
            this.patient = patient;
            this.name = name;
            this.description = description;
            this.date = date;
            this.highlighted = highlighted;
            this.seen = seen;
            this.frequencyInHours = freq;
        }
        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        public Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Boolean Highlighted
        {
            get { return highlighted; }
            set { highlighted = value; }
        }
        public Boolean Seen
        {
            get { return seen; }
            set { seen = value; }
        }
        public int FrequencyInHours
        {
            get { return frequencyInHours; }
            set { frequencyInHours = value; }
        }
    }
}
