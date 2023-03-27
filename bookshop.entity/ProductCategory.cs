using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class ProductCategory
    {
        // Model kısımları
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
        
        public int  ProductId { get; set; }
        
        public Product Product { get; set; }

        public int PublisherId{get;set;}

        
        
    }
}
