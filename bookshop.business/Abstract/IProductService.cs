using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.business.Abstract
{
    public interface IProductService : IValidator<Product>
    {
        Product GetProductDetails(string url);

        Product GetByIdWithCategories(int id);

        Product GetByIdWithAuthors(int id);

        Product GetByIdWithPublishers(int id);

        Product GetByIdWithTranslators(int id);
        Task<Product> GetById(int id);

        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetProductsByPublisher(string name, int page, int pageSize);

        List<Product> GetProductsByAuthor(string name);
        List<Product> GetProductsByTranslator(string name,int page,int pagesize);
        List<Product> GetHomePageProduct();

        List<Product> GetSearchResult(string searchString);

        Task<List<Product>> GetAll();

        bool Create(Product entity);
       Task<Product> CreateAsync(Product entity);

        void Update(Product entity);
        Task UpdateAsync(Product entityToUpdate,Product entity);

        void Delete(Product entity);

       Task DeleteAsync(Product entity);

        int GetCountByCategory(string category);

        int GetCountByPublisher(string publisher);

        int GetCountByAuthor(string author);

        int GetCountByTranslator(string translator);
        bool Update(Product entity, int[] categoryIds,int[] authorIds,int[] publisherIds,int[] translatorIds);

        
    }
}
