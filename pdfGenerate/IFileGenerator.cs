using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftn_sims_hci_hospital.pdfGenerate
{
    interface IFileGenerator
    {
        void setup();
        void addPatient(User patient);
        void addDoctor(User doctor);
        void addAnamnesis(Anamnesis anamnesis);
        void addPrescription(Perscription prescription);
        Boolean generate();
    }
}
