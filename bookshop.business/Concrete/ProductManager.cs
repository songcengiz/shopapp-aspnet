using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.data.Abstract;
using bookshop.entity;

namespace bookshop.business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitofwork;

        public ProductManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public string ErrorMessage { get; set; }

        public bool Create(Product entity)
        {
            if (Validation(entity))
            {
                _unitofwork.Products.Create (entity);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public async Task<Product> CreateAsync(Product entity)
        {
           await _unitofwork.Products.CreateAsync(entity);
           await _unitofwork.SaveAsync();
           return entity;
        }

        public void Delete(Product entity)
        {
            // iş kurallarını uygula
            _unitofwork.Products.Delete (entity);
        }

        public async Task DeleteAsync(Product entity)
        {
            _unitofwork.Products.Delete(entity);
            await _unitofwork.SaveAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _unitofwork.Products.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitofwork.Products.GetById(id);
        }

        public Product GetByIdWithAuthors(int id)
        {
            return _unitofwork.Products.GetByIdWithAuthors(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _unitofwork.Products.GetByIdWithCategories(id);
        }

        public Product GetByIdWithPublishers(int id)
        {
            return _unitofwork.Products.GetByIdWithPublishers(id);
        }

        public Product GetByIdWithTranslators(int id)
        {
            return _unitofwork.Products.GetByIdWithTranslators(id);
        }

        public int GetCountByAuthor(string author)
        {
            return _unitofwork.Products.GetCountByAuthor(author);
        }

        public int GetCountByCategory(string category)
        {
            return _unitofwork.Products.GetCountByCategory(category);
        }

        public int GetCountByPublisher(string publisher)
        {
             return _unitofwork.Products.GetCountByPublisher(publisher);
        }

        public int GetCountByTranslator(string translator)
        {
             return _unitofwork.Products.GetCountByTranslator(translator);
        }

        public List<Product> GetHomePageProduct()
        {
            return _unitofwork.Products.GetHomePageProducts();
        }

        public Product GetProductDetails(string url)
        {
            return _unitofwork.Products.GetProductDetails(url);
        }

        public List<Product> GetProductsByAuthor(string name)
        {
            return _unitofwork
                .Products
                .GetProductsByAuthor(name);
        }

       

        public List<Product>
        GetProductsByCategory(string name, int page, int pageSize)
        {
            return _unitofwork
                .Products
                .GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetProductsByPublisher(string name, int page, int pageSize)
        {
            return _unitofwork
                .Products
                .GetProductsByPublisher(name, page, pageSize);
        }


        public List<Product> GetProductsByTranslator(string name, int page, int pageSize)
        {
            return _unitofwork
                .Products
                .GetProductsByTranslator(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _unitofwork.Products.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            _unitofwork.Products.Update (entity);
            _unitofwork.Save();
        }

        public bool Update(Product entity, int[] categoryIds,int[] authorIds,int[] publisherIds,int[] translatorIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage +=
                        "Ürün için en az bir kategori seçmelisiniz.";
                    return false;
                }
                if (authorIds.Length == 0)
                {
                    ErrorMessage +=
                        "Ürün için en az bir yazar seçmelisiniz.";
                    return false;
                }
                if (publisherIds.Length == 0)
                {
                    ErrorMessage +=
                        "Ürün için en az bir yayınevi seçmelisiniz.";
                    return false;
                }
             
                _unitofwork.Products.Update (entity, categoryIds,authorIds,publisherIds,translatorIds);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Product entityToUpdate, Product entity)
        {
           entityToUpdate.Name=entity.Name;
           entityToUpdate.Price=entity.Price;
           entityToUpdate.Description=entity.Description;

           await _unitofwork.SaveAsync();
        }

        public bool Validation(Product entity)
        {
            var IsValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz.\n";
            }

            if (entity.Price < 0)
            {
                ErrorMessage += "ürün fiyatı negatif olamaz.\n";
                IsValid = false;
            }
            return IsValid;
        }
    }
}
