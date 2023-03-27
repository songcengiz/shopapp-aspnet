using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;

namespace bookshop.data.Configurations
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
               new Product() { ProductId = 1, Name = "Mutlu Yaşlanmak", Url = "mutlu-yaslanmak", Price = 17, Description = "Ev-Aile-Toplum Serisi", IsApproved = true, ImageUrl = "7.jpg", Language = "Türkçe", ISBN = 123456776, NumberOfPage = 200, PaperType = "Kuşe Kağıt" },
               new Product() { ProductId = 2, Name = "Bülbülün Kırk Şarkısı", Url = "bulbulun-kırk-sarkısı", Price = 19, Description = "Deneme-İnceleme Serisi", IsApproved = true, ImageUrl = "5.jpg", Language = "Türkçe", ISBN = 1230066, NumberOfPage = 300, PaperType = "Kuşe Kağıt", },
               new Product() { ProductId = 3, Name = "Aziz İstanbul", Url = "aziz-istanbul", Price = 49, Description = "Deneme-İnceleme Serisi", IsApproved = true, ImageUrl = "3.jpg", Language = "Türkçe", ISBN = 12345666, NumberOfPage = 400, PaperType = "1.Hamur", },
               new Product() { ProductId = 4, Name = "Lüzumsuz Adam", Url = "luzumsuz-adam", Price = 33, Description = "Modern Türk Edebiyatı Serisi", IsApproved = false, ImageUrl = "8.jpg", Language = "Türkçe", ISBN = 1211300666, NumberOfPage = 500, PaperType = "2.Hamur", },
               new Product() { ProductId = 5, Name = "Toprak Ana", Url = "toprak-ana", Price = 17, Description = "Öykü Serisi", IsApproved = true, ImageUrl = "2.jpg", Language = "İngilizce", ISBN = 12344666, NumberOfPage = 600, PaperType = "1.Hamur", },
               new Product() { ProductId = 6, Name = "Falaka", Url = "falaka", Price = 49, Description = "Öykü Serisi", IsApproved = true, ImageUrl = "4.jpg", Language = "Türkçe", ISBN = 12345996, NumberOfPage = 800, PaperType = "3.Hamur", },
               new Product() { ProductId = 7, Name = "İnsan Ne İle Yaşar", Url = "insan-ne-ile-yasar", Price = 33, Description = "Öykü Serisi", IsApproved = false, ImageUrl = "6.jpg", Language = "Türkçe", ISBN = 1234331166, NumberOfPage = 900, PaperType = "Kuşe Kağıt", },
               new Product() { ProductId = 8, Name = "İstanbul İstanbul", Url = "istanbul-istanbul", Price = 17, Description = "Öykü Serisi", IsApproved = true, ImageUrl = "9.jpg", Language = "Almanca", ISBN = 1234533666, NumberOfPage = 250, PaperType = "3.Hamur", });

            builder.Entity<Category>().HasData(
               new Category() { CategoryId = 1, Name = "Ev-Aile-Toplum", Url = "ev-aile-toplum" },
               new Category() { CategoryId = 2, Name = "Deneme-İnceleme", Url = "deneme-inceleme" },
               new Category() { CategoryId = 3, Name = "Öykü", Url = "oyku" },
               new Category() { CategoryId = 4, Name = "Modern Türk Edebiyatı", Url = "modern-turk-edebiyatı" });

            builder.Entity<ProductCategory>().HasData(
                new ProductCategory() { ProductId = 1, CategoryId = 1 },
                new ProductCategory() { ProductId = 1, CategoryId = 4 },
                new ProductCategory() { ProductId = 2, CategoryId = 2 },
                new ProductCategory() { ProductId = 3, CategoryId = 2 },
                new ProductCategory() { ProductId = 4, CategoryId = 4 },
                new ProductCategory() { ProductId = 5, CategoryId = 3 },
                new ProductCategory() { ProductId = 6, CategoryId = 3 },
                new ProductCategory() { ProductId = 7, CategoryId = 3 },
                new ProductCategory() { ProductId = 8, CategoryId = 3 }
            );

            builder.Entity<Publisher>().HasData(
               new Publisher() { PublisherId = 1, Name = "Yapı Kredi Yayınları", Url = "yapi-kredi", Appellation = "Yapı Kredi Yayınları Ltd. Şti", Email = "iletisim@ykykultur.com.tr", Website = "www.yapikrediyayinlari.com.tr/iletisim",ImageLogo="4.jpg" },
               new Publisher() { PublisherId = 2, Name = "Can Yayınları", Url = "can", Appellation = "Can Sanat Yayınları Ltd. Şti", Website = "https://www.canyayinlari.com/",ImageLogo="1.jpg" },
               new Publisher() { PublisherId = 3, Name = "Doğan Yayınları", Url = "dogan", Appellation = "Doğan Yayınları Ltd. Şti", Website = "www.dogankitap.com.tr",ImageLogo="2.jpg"},
               new Publisher() { PublisherId = 4, Name = "Remzi Yayınları", Url = "remzi", Appellation = "Remzi Yayınları Ltd. Şti", Email = "post@remzi.com.tr", Website = "www.remzi.com.tr",ImageLogo="3.jpg", Phone = "212 - 282 - 20 - 80"});

            builder.Entity<ProductPublisher>().HasData(
                new ProductPublisher() { ProductId = 1, PublisherId = 1 },
                new ProductPublisher() { ProductId = 1, PublisherId = 4 },
                new ProductPublisher() { ProductId = 2, PublisherId = 2 },
                new ProductPublisher() { ProductId = 3, PublisherId = 2 },
                new ProductPublisher() { ProductId = 4, PublisherId = 4 },
                new ProductPublisher() { ProductId = 5, PublisherId = 3 },
                new ProductPublisher() { ProductId = 6, PublisherId = 3 },
                new ProductPublisher() { ProductId = 7, PublisherId = 3 },
                new ProductPublisher() { ProductId = 8, PublisherId = 3 }
            );

            builder.Entity<Author>().HasData(
                new Author() { AuthorId = 1, Name = "Haluk Yavuzer", Url = "haluk-yavuzer",ImageAuthor="7.jpg" },
                new Author() { AuthorId = 2, Name = "İskender Pala", Url = "iskender-pala",ImageAuthor="8.jpg" },
                new Author() { AuthorId = 3, Name = "Yahya Kemal", Url = "yahya-kemal",ImageAuthor="6.jpg"},
                new Author() { AuthorId = 4, Name = "Sait Faik Abasıyanık", Url = "sait-faik",ImageAuthor="2.jpg"},
                new Author() { AuthorId = 5, Name = "Cengiz Aytmatov", Url = "cengiz-aytmatov",ImageAuthor="1.jpg" },
                new Author() { AuthorId = 6, Name = "Ömer Seyfettin", Url = "ömer-seyfettin",ImageAuthor="3.jpg" },
                new Author() { AuthorId = 7, Name = "Tolstoy", Url = "tolstoy",ImageAuthor="5.jpg" },
                new Author() { AuthorId = 8, Name = "Orhan Kemal", Url = "orhan-kemal",ImageAuthor="4.jpg" }


            );
            builder.Entity<ProductAuthor>().HasData(
              new ProductAuthor() { ProductId = 1, AuthorId = 1 },
              new ProductAuthor() { ProductId = 2, AuthorId = 2 },
              new ProductAuthor() { ProductId = 3, AuthorId = 3 },
              new ProductAuthor() { ProductId = 4, AuthorId = 4 },
              new ProductAuthor() { ProductId = 5, AuthorId = 5 },
              new ProductAuthor() { ProductId = 6, AuthorId = 6 },
              new ProductAuthor() { ProductId = 7, AuthorId = 7 },
              new ProductAuthor() { ProductId = 8, AuthorId = 8 }
          );

             builder.Entity<Translator>().HasData(
                new Translator() { TranslatorId = 1,Url = "zeynep-arik", Name = "Zeynep Arık",ImageTranslator="3.jpg"},
                new Translator() { TranslatorId  = 2,Url = "veysel-ataman", Name = "Veysel Ataman",ImageTranslator="1.jpg"},
                new Translator() { TranslatorId = 3, Url = "ozgur-orhangazı",Name = "Özgür Orhangazi",ImageTranslator="2.jpg" }
            );

            builder.Entity<ProductTranslator>().HasData(
                new ProductTranslator(){ProductId=5,TranslatorId=1},
                new ProductTranslator(){ProductId=7,TranslatorId=2}
            );
        }
    }
}