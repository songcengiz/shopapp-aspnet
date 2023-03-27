using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class ProductPublisher
    {
         public int PublisherId { get; set; }
        
        public Publisher Publisher { get; set; }
        
        public int  ProductId { get; set; }
        
        public Product Product { get; set; }
        
    }
}