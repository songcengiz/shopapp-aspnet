using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.webui.Models
{
    public class PublisherModel
    {
        public int PublisherId { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }


        public string Name { get; set; }
        public string Appellation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ImageLogo { get; set; }
        public string Url { get; set; }
        public List<ProductPublisher> ProductPublishers { get; set; }
        public List<Product> SelectedProducts { get; internal set; }
    }
    public class PublisherDetailModel
    {
        public Publisher Publisher { get; set; }
        public List<Product> Products { get; set; }
        
        
        
        
    }
     public class PublisherListViewModel
    {
        public List<Publisher> Publishers{get;set;}
        public PageInfo PageInfo { get; internal set; }
    }
}