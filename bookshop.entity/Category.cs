using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookshop.entity
{
    public class Category
    {
        // Model kısımları
        public int CategoryId { get; set; }

        public string Name { get; set; }
        
        public string Url { get; set; }

       public List<ProductCategory> ProductCategories { get; set; }
        // (her bir ürünün birçok kategorisi olabilir. aynı zamanda bir kategoride bir çok ürün de olabilir. bu ilişkiyi sağlamak için list metodunu kullanıyoruz.)
    }
}
