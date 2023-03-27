using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class Author
    {
        public int AuthorId { get; set; }
        
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageAuthor { get; set; }
         public string Url { get; set; }

         public List<ProductAuthor> ProductAuthors { get; set; }
    }
       
        
}