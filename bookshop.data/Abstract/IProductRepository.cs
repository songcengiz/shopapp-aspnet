using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(string url);

        Product GetByIdWithCategories(int id);

        List<Product>
        GetProductsByCategory(
            string name, int page, int pageSize
        );

        List<Product> GetSearchResult(string searchString);

        List<Product> GetHomePageProducts();

        int GetCountByCategory(string category);

        void Update(Product entity, int[] categoryId,int[] authorIds,int[] publisherIds,int[] translatorIds);
     
        Product GetByIdWithPublishers(int id);
        Product GetByIdWithTranslators(int id);
        int GetCountByPublisher(string publisher);
        int GetCountByTranslator(string translator);
        int GetCountByAuthor(string author);
        List<Product> GetProductsByPublisher(string name, int page, int pageSize);
        List<Product> GetProductsByTranslator(string name, int page, object pageSize);
        List<Product> GetProductsByAuthor(string name);
        Product GetByIdWithAuthors(int id);
    }
}
