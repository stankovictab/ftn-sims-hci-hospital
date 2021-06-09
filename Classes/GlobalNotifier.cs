using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class GlobalNotifier
    {
        private INotifyStrategy notifyStrategy;

        public GlobalNotifier(INotifyStrategy strategy)
        {
            notifyStrategy = strategy;
        }
        
        public void Notify(Appointment app)
        {
            notifyStrategy.Notify(app);
        }
    }
}
