using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.data.Abstract;
using bookshop.entity;

namespace bookshop.business.Concrete
{
  public class OrderManager : IOrderService
    {
       private readonly IUnitOfWork _unitofwork;
        public OrderManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void Create(Order entity)
        {
            _unitofwork.Orders.Create(entity);
            _unitofwork.Save();
        }

        public List<Order> GetOrders(string userId)
        {
            return _unitofwork.Orders.GetOrders(userId);
        }
    }
}