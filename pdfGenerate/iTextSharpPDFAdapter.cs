using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Classes;
using ftn_sims_hci_hospital;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace ftn_sims_hci_hospital.pdfGenerate
{
    class iTextSharpPDFAdapter : IFileGenerator
    {
        private Document document;
        private String fileLocation = "../../pdfGenerate/Izvestaj.pdf";
        Font normal = FontFactory.GetFont("georgia", 11f);
        Font bold = new Font(FontFactory.GetFont(FontFactory.TIMES_BOLD, 11, Font.BOLD));


        public void addAnamesis(Anamnesis anamnesis)
        {
            Paragraph p1 = new Paragraph("Anamneza: ", bold);
            Paragraph p2 = new Paragraph(anamnesis.Description, normal);
            document.Add(p1);
            document.Add(p2);
            endParagraph();
        }

        public void addDoctor(User doctor)
        {
            Paragraph p1 = new Paragraph("Recept je  napisao doktor " + doctor.Name1 + " " + doctor.LastName1 + ".", normal);
            document.Add(p1);
            endParagraph();
        }

        public void addPatient(User patient)
        {
            Paragraph p1 = new Paragraph("Ime: " + patient.Name1, bold);
            Paragraph p2 = new Paragraph("Prezime: " + patient.LastName1, bold);
            Paragraph p3 = new Paragraph("JMBG: " + patient.Jmbg1, bold);
            document.Add(p1);
            document.Add(p2);
            document.Add(p3);
            endParagraph();
        }

        public void addPrescription(Perscription prescription)
        {
            Paragraph p1 = new Paragraph("Naziv leka: " + prescription.Medicine.Name, normal);
            Paragraph p2 = new Paragraph("Kolicina :" + prescription.Amount.ToString(), normal);
            Paragraph p3 = new Paragraph("Opis za uzimanje leka: " + prescription.Description, normal);
            Paragraph p4 = new Paragraph("Alternativni lekovi: " + prescription.Medicine.Alternatives, normal);
            document.Add(p1);
            document.Add(p2);
            document.Add(p3);
            document.Add(p4);
            endParagraph();
        }

        public Boolean generate()
        {
            endParagraph();
            iTextSharp.text.Image sig = iTextSharp.text.Image.GetInstance("../../Images/sigSmall.png");
            sig.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            document.Add(sig);
            document.Close();
            return true;
        }

        public void setup()
        {
            document = new Document();
            PdfWriter.GetInstance(document, new FileStream(fileLocation, FileMode.Create));
            document.Open();
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("../../Images/logoSmall.jpg");
            logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(logo);
            endParagraph();
        }

        private void endParagraph()
        {
            Paragraph paragraph = new Paragraph("\n\n");
            document.Add(paragraph);
        }
    }
}
