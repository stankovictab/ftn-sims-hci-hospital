using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class HospitalizedPatientDTO
    {
        public String name { get; set; }
        public String lastname { get; set; }
        public String jmbg { get; set; }
        public String description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public HospitalizedPatientDTO(string name, string lastname, string jmbg, string description, DateTime startDate, DateTime endDate)
        {
            this.name = name;
            this.lastname = lastname;
            this.jmbg = jmbg;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public HospitalizedPatientDTO()
        { }
    }
}
