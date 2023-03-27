using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class Translator
    {
        public int TranslatorId { get; set; }
        
        public string Url { get; set; }
        public string Name { get; set; }
        public string ImageTranslator { get; set; }
        
        public string Description { get; set; }
        
        
          public List<ProductTranslator> ProductTranslators { get; set; }
       
    }
}