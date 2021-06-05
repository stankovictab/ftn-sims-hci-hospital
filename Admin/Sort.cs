using ftn_sims_hci_hospital.Classes;
using System.Collections.Generic;

namespace ftn_sims_hci_hospital.Admin
{
    class Sort
    {
        private int alternator = 0;
        public Sort() { }
        public List<Demand> sort(List<Demand> list)
        {
            // Bubble Sort
            for (int i = 0; i < list.Count - 1; i++) // list.Count == list.Length
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (alternator == 1) // Ascending
                    {
                        if (list[j].CreationDate1 > list[j + 1].CreationDate1)
                        {
                            // Swap temp and arr[i]
                            Demand temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                    else
                    {
                        if (list[j].CreationDate1 < list[j + 1].CreationDate1)
                        {
                            // Swap temp and arr[i]
                            Demand temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
            }
            alternator = alternator == 0 ? 1 : 0;
            return list;
        }
    }
}
