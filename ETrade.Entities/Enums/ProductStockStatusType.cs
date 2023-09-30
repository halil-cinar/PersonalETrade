using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Enums
{
    public enum ProductStockStatusType
    {
        Unknown=0,
        InStock,        // Stokta
        OutOfStock,     // Tükendi
        PreOrder,       // Ön Siparişte
        AboutToRunOut,   // Tükenmek Üzere 
        LimitedQuantity,    // Sınırlı Sayıda

    }
}
