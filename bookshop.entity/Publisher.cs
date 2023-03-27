using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class Publisher
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
       
    }
}