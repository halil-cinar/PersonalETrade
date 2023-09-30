using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Enums
{
    public enum ProductStatusType
    {
        Unknown=0,
        AwaitingApproval, // Onay Bekleniyor
        Approved, // Onaylandı
        OnSale, // Satşta
        Suspended, //Duraklatıldı
        RemovedFromSale, //Satıştan Kaldırıldı
        Cancelled,          // İptal Edildi
        
        

    }
}
