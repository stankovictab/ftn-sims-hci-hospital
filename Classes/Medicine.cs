using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Medicine
    {
        public String id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public Boolean verified { get; set; }

        public Medicine(String id, String name, String description, Boolean verified)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.verified = verified;
        }

    }
}
