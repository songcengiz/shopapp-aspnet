using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.webui.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        // [Display(Name="Name",Prompt ="Enter Product name")]
        // [Required(ErrorMessage ="Name zorunlu bir alan.")]
        // [StringLength(60,MinimumLength =5,ErrorMessage ="Ürün ismi 5-10 karakter arasında olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url zorunlu bir alan.")]
        [
            StringLength(
                100,
                MinimumLength = 5,
                ErrorMessage = "Url 5-100 karakter arasında olmalıdır.")
        ]
        public string Url { get; set; }

        //  [Required(ErrorMessage ="Price zorunlu bir alan.")]
        //  [Range(1,100000,ErrorMessage ="Price için 1-10000 arasında değer girmelisiniz")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "Description zorunlu bir alan.")]
        [
            StringLength(
                10000,
                MinimumLength = 5,
                ErrorMessage =
                    "Description 5-10000 karakter ararsında olmalıdır.")
        ]
        public string Description { get; set; }

        [Required(ErrorMessage = "ImageUrl zorunlu bir alan.")]
        public string ImageUrl { get; set; }

        public bool IsApproved { get; set; }

        public string Language { get; set; }

       
        public int ISBN { get; set; }

        public int NumberOfPage { get; set; }

        public string PaperType { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsHome { get; set; }

        public List<Category> SelectedCategories { get; set; }

        public List<Publisher> SelectedPublishers{get;set;}

        public List<Author> SelectedAuthors{get;set;}

        public List<Translator> SelectedTranslators{get;set;}
    }
}
