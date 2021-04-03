using System;
using System.Collections.Generic;

namespace CupcakeShop.Web.Entities
{
    public class Order
    {
        public enum StatusType
        {
            Comfirmed,
            Canceled,
            OnHold,
            Processing
        }
        public int  Id { get; private  set; }
        public DateTime DateOrder { get; private  set; }
        public DateTime DateDelivery { get; private  set; }
        public StatusType StatusOrder { get; private set; }
        public int  ClientId { get; private set; }
        public Client Client { get; private set; }
        public bool Emergency { get; private set; }
        public int ShopId { get; private set; }
        public Shop Shop { get; private set; }

        public ICollection<CupcakeOrder> OrderCupcakes { get; private set; }

        public Order(DateTime dateOrder, DateTime dateDelivery,int clientId, StatusType statusOrder, bool emergency,
            int shopId)
        {
            DateOrder = dateOrder;
            DateDelivery = dateDelivery;
            StatusOrder = statusOrder;
            Emergency = emergency;
            ClientId = clientId;
            ShopId = shopId;
        }

        public void Upgrade_Proprieties(DateTime dateDelivery, StatusType statusOrder, bool emerngency)
        {
            DateDelivery = dateDelivery;
            StatusOrder = statusOrder;
            Emergency = emerngency;
        }


    }
}
