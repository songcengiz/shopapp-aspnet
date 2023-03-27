using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class ProductAuthor
    {
         public int AuthorId { get; set; }
        
        public Author Author { get; set; }
        
        public int  ProductId { get; set; }
        
        public Product Product { get; set; }
        
        
    }
}