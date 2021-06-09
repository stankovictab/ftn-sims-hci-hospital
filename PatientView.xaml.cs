﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Classes;

namespace ftn_sims_hci_hospital
{
    public partial class PatientView : Window
    {
        public Patient currentPatient = new Patient();
        public PatientView(String id)
        {
            InitializeComponent();
            InitTextBoxes(id);
            InitPatientsAllergies();
            InitAllergiesComboBox();
        }

        private void InitAllergiesComboBox()
        {
            MainWindow.patientController.patientService.allergiesRepository.AllergiesInFile = MainWindow.patientController.patientService.allergiesRepository.GetAll();
            foreach (Allergy a in MainWindow.patientController.patientService.allergiesRepository.AllergiesInFile)
            {
                cballergy.Items.Add(a.Name1);
            }
        }

        private void InitPatientsAllergies()
        {
            List<PatientAllergy> patientAllergies = new List<PatientAllergy>();
            patientAllergies = MainWindow.patientController.patientService.patientallergyRepository.GetAllByPatientID(currentPatient.user.Jmbg1);
            List<Allergy> allergies = new List<Allergy>();
            allergies = MainWindow.patientController.patientService.allergiesRepository.GetAll();
            foreach (PatientAllergy patientAllergy in patientAllergies)
            {
                foreach (Allergy allergy in allergies)
                {
                    if (patientAllergy.allergy.Id1 == allergy.Id1)
                    {
                        currentPatient.medicalRecord.allergies.Add(allergy);
                    }
                }
            }
            foreach (Allergy allergy in currentPatient.medicalRecord.allergies)
            {
                if (tballergies.Text != "")
                    tballergies.Text += "," + allergy.Name1;
                else
                    tballergies.Text += allergy.Name1;
            }
        }

        private void InitTextBoxes(string id)
        {
            currentPatient = MainWindow.patientController.GetByID(id);
            tbfirstname.Text = currentPatient.user.Name1;
            tblastname.Text = currentPatient.user.LastName1;
            tbjmbg.Text = currentPatient.user.Jmbg1;
            tbphonenumber.Text = "0600233479";
            tbbloodtype.Text = "A+";
            tbgender.Text = currentPatient.user.Gender1.ToString();
            tballergies.Text = "";
        }

        private void btnaddallergy_Click(object sender, RoutedEventArgs e)
        {
            if (cballergy.SelectedItem == null)
            {
                MessageBox.Show("You can't add an empty allergy!");
            }
            else
            {
                AddAllergy();
            }
        }

        private void AddAllergy()
        {
            string name = cballergy.SelectedItem.ToString();
            foreach (Allergy a in MainWindow.patientController.patientService.allergiesRepository.AllergiesInFile)
            {
                if (a.Name1.Equals(name))
                {
                    bool flag = false;
                    foreach (Allergy all in currentPatient.medicalRecord.allergies)
                    {
                        if (a.Id1 == all.Id1)
                        {
                            flag = true;
                            break;
                        }

                    }
                    if (!flag)
                    {
                        currentPatient.medicalRecord.allergies.Add(a);
                        if (tballergies.Text != "")
                            tballergies.Text += "," + a.Name1;
                        else
                            tballergies.Text += a.Name1;
                    }
                }
            }
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            String name = tbfirstname.Text;
            String lastname = tblastname.Text;
            User user = new User(name, lastname, currentPatient.user.Username1, currentPatient.user.Password1, currentPatient.user.Email1, currentPatient.user.Jmbg1, currentPatient.user.Address1, currentPatient.user.Gender1, currentPatient.user.Active1, currentPatient.user.Role1);
            Patient patient = new Patient(user, null, null, null);
            MainWindow.patientController.Update(patient);
            foreach(Allergy a in currentPatient.medicalRecord.allergies)
            {
                PatientAllergy pa = new PatientAllergy(currentPatient.user.Jmbg1, a);
                MainWindow.patientController.patientService.patientallergyRepository.Create(pa);
            }
            

            MessageBox.Show("You have successfully updated this patients' data!");
            this.Close();
        }
    }
}
