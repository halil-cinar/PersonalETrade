using ETrade.Dto.Dtos.OrderDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Dto.Dtos.Order
{
    public class OrderListDetailDto
    {
        /// <summary>
        /// Customer
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }

        [JsonProperty(PropertyName = "orderNo")]
        public long OrderNo { get; set; }

        [JsonProperty(PropertyName = "orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty(PropertyName = "billingAddressId")]
        public long BillingAddressId { get; set; }

        [JsonProperty(PropertyName = "deliveryAddressId")]
        public long DeliveryAddressId { get; set; }



        [JsonProperty(PropertyName = "discountAmount")]
        public Decimal DiscountAmount { get; set; }

        [JsonProperty(PropertyName ="orderDetails")]
        public List<OrderDetailListDto> OrderDetailLists { get; set; }

    }
}
