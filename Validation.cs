using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ftn_sims_hci_hospital
{
    public class StringToIntegerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                /*MessageBox.Show(int.Parse(s).GetType().ToString());


                if (int.Parse(s).GetType().ToString() == "System.Int32")
                {
                    MessageBox.Show("CORRECT!");
                }*/

                int r;
                if (int.TryParse(s, out r))
                {
                    // AdminManagerDynamicEquipmentOrderCreation.validationIntFlag = true;
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Enter an integer value.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured (INTEXC).");
            }
        }
    }
}
