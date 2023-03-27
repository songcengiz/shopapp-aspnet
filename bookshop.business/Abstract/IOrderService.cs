using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);
    
    }
}