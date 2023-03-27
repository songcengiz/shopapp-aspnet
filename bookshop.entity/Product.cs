using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class Product
    {
        // Model kısımları
        // Product ile ilgili özellikleri eklemek istiyorsam modele eklemem gerekiyor:yayınevi,yazar...
        public int ProductId { get; set; }

        
        public string Name { get; set; }

        public string Url { get; set; }
        
        
        public double? Price { get; set; }

        public string Description { get; set; }

    
        public string ImageUrl { get; set; }
        public bool IsHome{ get; set; }

        public bool IsApproved { get; set; }

        
        public string Language{ get; set; }
     
        public int ISBN{get;set;}
        public int NumberOfPage{get;set;}

        public string PaperType{get;set;}

        public DateTime DateAdded { get; set; }
        
        public List<ProductCategory> ProductCategories{get;set;}
        public List<ProductPublisher> ProductPublishers { get; set; }
        public List<ProductAuthor> ProductAuthors{ get; set; }
        public List<ProductTranslator> ProductTranslators { get; set; }
       
    }
}
