using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.webui.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageAuthor { get; set; }
        public string Url { get; set; }

        public List<ProductAuthor> ProductAuthors { get; set; }
        public List<Product> SelectedProducts { get; internal set; }
    }
    public class AuthorDetailModel
    {
        public Author Author { get; set; }
        public List<Product> Products { get; set; }


    }
    public class AuthorListViewModel
    {
        public List<Author> Authors { get; set; }

        public List<Product> Products { get; set; }
    }
}