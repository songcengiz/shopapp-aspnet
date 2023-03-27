//Aynı anda hem categori bilgisi hemde product bilgisi istiyorsam bu durumda ViewModel içeriğini kullanırım

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.webui.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public string CurrentCategory { get; set; }

        public string CurrentPublisher{get;set;}

        public string CurrentAuthor{get;set;}

        public string CurrentTranslator{get;set;}
        public string CurrentProduct { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
            // 10/3
        }
    }

    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }

        public List<Product> Products { get; set; }

        public List<Author> Authors{get;set;}

        public List<Publisher> Publishers{get;set;}

      

        
    }
}