using System;
using System.Collections.Generic;
using System.IO;

namespace Classes
{
    public class DynamicEquipmentOrderRepository
    {
        private String FileLocation = "../../Text Files/dynamicequipmentorders.txt";
        private List<DynamicEquipmentOrder> DynamicEquipmentOrdersInFile = new List<DynamicEquipmentOrder>();

        public Boolean Create(DynamicEquipmentOrder req)
        {
            GetAll(); // Update liste
            if (DynamicEquipmentOrdersInFile.Contains(req))
            {
                return false;
            }
            else
            {
                DynamicEquipmentOrdersInFile.Add(req); // Update liste
                UpdateFile(); // Update fajla
                return true;
            }
        }

        public DynamicEquipmentOrder GetByID(String id)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentOrder req in DynamicEquipmentOrdersInFile)
            {
                if (req.OrderID1.Equals(id))
                {
                    return req;
                }
            }
            return null;
        }

        // Update liste u memoriji skeniranjem fajla, vraca tu istu listu
        public List<DynamicEquipmentOrder> GetAll()
        {
            List<DynamicEquipmentOrder> orders = new List<DynamicEquipmentOrder>();
            TextReader tr = new StreamReader(FileLocation);
            string text = tr.ReadLine();
            while (text != null && text != "\n")
            {
                string[] components = text.Split(','); // Po defaultu su svi componenti stringovi, pa za neke mora convert
                string id = components[0];
                string equipmentNames = components[1];
                string equipmentAmounts = components[2];
                DateTime OrderDate = Convert.ToDateTime(components[3]);
                DynamicEquipmentOrderStatus status = (DynamicEquipmentOrderStatus)Convert.ToInt32(components[4]);

                DynamicEquipmentOrder Order = new DynamicEquipmentOrder(id, equipmentNames, equipmentAmounts, OrderDate, status);
                orders.Add(Order);
                text = tr.ReadLine();
            }
            tr.Close();
            DynamicEquipmentOrdersInFile = orders; // Update liste
            return orders;
        }

        public Boolean Update(DynamicEquipmentOrder prosledjeni)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentOrder nadjeni in DynamicEquipmentOrdersInFile)
            {
                if (prosledjeni.OrderID1.Equals(nadjeni.OrderID1) && nadjeni.Status1 == DynamicEquipmentOrderStatus.Sent)
                {
                    nadjeni.EquipmentNames1 = prosledjeni.EquipmentNames1;
                    nadjeni.EquipmentAmounts1 = prosledjeni.EquipmentAmounts1;
                    nadjeni.OrderDate1 = prosledjeni.OrderDate1; // Ovo se ipak menja
                    // Status se ne menja
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateFile()
        {
            // Ovde se ne radi GetAll();
            TextWriter tw = new StreamWriter(FileLocation);
            if (DynamicEquipmentOrdersInFile == null)
            {
                tw.Close();
                return false;
            }
            else
            {
                // Za svaki Order pise liniju, i to mora da bude u istom formatu kao kada i cita
                foreach (DynamicEquipmentOrder item in DynamicEquipmentOrdersInFile)
                {
                    tw.WriteLine(item.OrderID1 + "," + item.EquipmentNames1 + "," + item.EquipmentAmounts1 + "," + item.OrderDate1 + "," + (int)item.Status1);
                    // Datumi se ne ispisuju po onom mom formatu ali izgleda da je i ovako ok, parsira se isto
                }
                tw.Close();
                return true;
            }
        }

        public Boolean Delete(String id)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentOrder hr in DynamicEquipmentOrdersInFile)
            {
                if (hr.OrderID1.Equals(id))
                {
                    DynamicEquipmentOrdersInFile.Remove(hr);
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean SetToWaiting(String id)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentOrder hr in DynamicEquipmentOrdersInFile)
            {
                if (hr.OrderID1.Equals(id))
                {
                    hr.Status1 = DynamicEquipmentOrderStatus.Waiting;
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }

        public Boolean SetToCompleted(String id)
        {
            GetAll(); // Update liste
            foreach (DynamicEquipmentOrder hr in DynamicEquipmentOrdersInFile)
            {
                if (hr.OrderID1.Equals(id))
                {
                    hr.Status1 = DynamicEquipmentOrderStatus.Completed;
                    UpdateFile(); // Update fajla
                    return true;
                }
            }
            return false;
        }
    }
}