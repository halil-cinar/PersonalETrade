using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Enums
{
    
    public enum EntityType
    {
        Unknown=0,
        Address=1,
        Brand=2,
        CarouselItem=3,
        Category=4,
        Chat=5,
        Comment=6,
        Country=7,
        Currency=8,
        DeliveryOption=9,
        Gender=10,
        Identity=11,
        Message=12,
        OrderDetail=13,
        Order=14,
        ProductComment=15,
        Product=16,
        Role=17,
        SellerAddress=18,
        SellerComment=19,
        Seller=20,
        UserAddress=21,
        UserChat=22,
        User=23,
        UserRole=24
    }
}
