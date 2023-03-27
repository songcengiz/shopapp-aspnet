using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.webui.Models
{
    public class ProductDetailModel
    {
        public Product Product { get; set; }
      
        public List<Category> Categories { get; set; }

        public List<Publisher> Publishers { get;set; }

        public List<Author> Authors{get;set;}

        public List<Translator> Translators{get;set;}
     
    }
}