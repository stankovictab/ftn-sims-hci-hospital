using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ViewModels
{
    class RoomEquipmentViewModel : ViewModel
    {
        private DynamicEquipmentRepository dynamicEquipmentRepository;
        private ObservableCollection<DynamicEquipment> equipment;

        public ObservableCollection<DynamicEquipment> Equipment
        {
            get { return equipment; }
            set
            {
                equipment = value;
                OnPropertyChanged();
            }
        }
    }
}
