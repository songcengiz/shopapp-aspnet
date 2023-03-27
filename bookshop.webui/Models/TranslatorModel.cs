using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.webui.Models
{
    public class TranslatorModel
    {
        public int TranslatorId { get; set; }
        
        public string Url { get; set; }
        public string Name { get; set; }
        public string ImageTranslator { get; set; }
        
        public string Description { get; set; }
        
        
        public List<ProductTranslator> ProductTranslators { get; set; }
        public List<Product> SelectedProducts { get; internal set; }
    }
    public class TranslatorDetailModel
    {
        public Translator Translator { get; set; }
        public List<Product> Products { get; set; }
        
        
        
        
    }
      public class TranslatorListViewModel
    {
        public List<Translator> Translators{get;set;}
    }
     
}