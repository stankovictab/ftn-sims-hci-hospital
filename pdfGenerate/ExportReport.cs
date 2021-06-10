using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ftn_sims_hci_hospital.pdfGenerate
{
    public class ExportReport
    {

        private IFileGenerator generator = new iTextSharpPDFAdapter();

        public ExportReport()
        {
            generator.setup();
        }

        public void addAnamesis(Anamnesis anamnesis)
        {
            generator.addAnamesis(anamnesis);
        }

        public void addPrescription(Perscription prescription)
        {
            generator.addPrescription(prescription);
        }

        public Boolean generate()
        {
            return generator.generate();
        }
        
        public void addPatient(User patient)
        {
            generator.addPatient(patient);
        }

        public void addDoctor(User doctor)
        {
            generator.addDoctor(doctor);
        }
    }
}
