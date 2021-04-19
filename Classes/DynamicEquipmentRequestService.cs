using System;
using System.Collections.Generic;

namespace Classes
{
   public class DynamicEquipmentRequestService
   {
      public DynamicEquipmentRequestRepository dynamicEquipmentRequestRepository;
   
      public Boolean Create(String equipmentName)
      {
         // TODO: implement
         return false;
      }
      
      public DynamicEquipment GetByID(String id)
      {
         // TODO: implement
         return null;
      }
      
      public List<DynamicEquipment> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Update(String id, String equipmentName)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean Delete(String id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean Approve(String id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean Deny(String id)
      {
         // TODO: implement
         return false;
      }
      
      public int CheckQuantity(String equipmentID)
      {
         // TODO: implement
         return 0;
      }
   
   }
}