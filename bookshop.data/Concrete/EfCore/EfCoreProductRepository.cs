using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bookshop.data.Abstract;
using bookshop.data.Concrete.EfCore;
using bookshop.entity;

namespace bookshop.data.Concrete.EfCore
{
    public class
    EfCoreProductRepository
    : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(ShopContext context) :
            base(context)
        {
        }

        private ShopContext ShopContext
        {
            get
            {
                return context as ShopContext;
            }
        }

        public Product GetByIdWithCategories(int id)
        {
            return ShopContext
                .Products
                .Where(i => i.ProductId == id)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefault();
        }

        public Product GetByIdWithPublishers(int id)
        {
            return ShopContext
                .Products
                .Where(i => i.ProductId == id)
                .Include(i => i.ProductPublishers)
                .ThenInclude(i => i.Publisher)
                .FirstOrDefault();
        }

        public Product GetByIdWithTranslators(int id)
        {
            return ShopContext
                .Products
                .Where(i => i.ProductId == id)
                .Include(i => i.ProductTranslators)
                .ThenInclude(i => i.Translator)
                .FirstOrDefault();
        }

        public Product GetByIdWithAuthors(int id)
        {
            return ShopContext
                .Products
                .Where(i => i.ProductId == id)
                .Include(i => i.ProductAuthors)
                .ThenInclude(i => i.Author)
                .FirstOrDefault();
        }

        public int GetCountByCategory(string category)
        {
            var products =
                ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                products =
                    products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i =>
                            i
                                .ProductCategories
                                .Any(a => a.Category.Url == category));
            }
            return products.Count();
        }

        public List<Product> GetHomePageProducts()
        {
            return ShopContext
                .Products
                .Where(i => i.IsApproved && i.IsHome)
                .ToList();
        }

        public List<Product> GetPopularProducts()
        {
            return ShopContext.Products.ToList();
        }

        public Product GetProductDetails(string url)
        {
            return ShopContext
                .Products
                .Where(i => i.Url == url)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .Include(İ=>İ.ProductPublishers)
                .ThenInclude(i=>i.Publisher)
                .Include(i=>i.ProductAuthors)
                .ThenInclude(i=>i.Author)
                .Include(i=>i.ProductTranslators)
                .ThenInclude(i=>i.Translator)
                
                .FirstOrDefault();
        }

        public List<Product>
        GetProductsByCategory(string name, int page, int pageSize)
        {
            var products =
                ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                products =
                    products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i =>
                            i
                                .ProductCategories
                                .Any(a => a.Category.Url == name));
            }
            return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Product> GetSearchResult(string searchString)
        {
            var products =
                ShopContext
                    .Products
                    .Where(i =>
                        i.IsApproved &&
                        (
                        i.Name.ToLower().Contains(searchString.ToLower()) ||
                        i.Description.ToLower().Contains(searchString.ToLower())
                        ))
                    .AsQueryable();

            return products.ToList();
        }

        public void Update(Product entity, int[] categoryIds,int[] authorIds,int[] publisherIds,int[] translatorIds)
        {
            var product =
                ShopContext
                    .Products
                    .Include(i => i.ProductCategories)
                    .Include(i=>i.ProductAuthors)
                    .Include(i=>i.ProductPublishers)
                    .Include(i=>i.ProductTranslators)
                    .FirstOrDefault(i => i.ProductId == entity.ProductId);

            if (product != null)
            {
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.Description = entity.Description;
                product.Url = entity.Url;
                product.ImageUrl = entity.ImageUrl;
                product.IsApproved = entity.IsApproved;
                product.IsHome = entity.IsHome;
                product.DateAdded = entity.DateAdded;
                product.Language = entity.Language;
                product.ISBN = entity.ISBN;
                product.NumberOfPage = entity.NumberOfPage;
                product.PaperType = entity.PaperType;

                product.ProductCategories =
                    categoryIds
                        .Select(catid =>
                            new ProductCategory()
                            {
                                ProductId = entity.ProductId,
                                CategoryId = catid
                            })
                        .ToList();

                product.ProductAuthors =
                    authorIds
                        .Select(autid =>
                            new ProductAuthor()
                            {
                                ProductId = entity.ProductId,
                                AuthorId = autid
                            })
                        .ToList();
                 product.ProductPublishers =
                    publisherIds
                        .Select(publid =>
                            new ProductPublisher()
                            {
                                ProductId = entity.ProductId,
                               PublisherId = publid
                            })
                        .ToList();
                 product.ProductTranslators =
                    translatorIds
                        .Select(transid =>
                            new ProductTranslator()
                            {
                                ProductId = entity.ProductId,
                                TranslatorId = transid
                            })
                        .ToList();
            }
        }

        public int GetCountByPublisher(string publisher)
        {
            var products =
                ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(publisher))
            {
                products =
                    products
                        .Include(i => i.ProductPublishers)
                        .ThenInclude(i => i.Publisher)
                        .Where(i =>
                            i
                                .ProductPublishers
                                .Any(a => a.Publisher.Url == publisher));
            }
            return products.Count();
        }

        public int GetCountByTranslator(string translator)
        {
            var products =
                ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(translator))
            {
                products =
                    products
                        .Include(i => i.ProductTranslators)
                        .ThenInclude(i => i.Translator)
                        .Where(i =>
                            i
                                .ProductTranslators
                                .Any(a => a.Translator.Url == translator));
            }
            return products.Count();
        }

        public int GetCountByAuthor(string author)
        {
            var products =
                ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(author))
            {
                products =
                    products
                        .Include(i => i.ProductAuthors)
                        .ThenInclude(i => i.Author)
                        .Where(i =>
                            i.ProductAuthors.Any(a => a.Author.Url == author));
            }
            return products.Count();
        }

        public List<Product>
        GetProductsByPublisher(string name, int page, int pageSize)
        {
            var products =
                ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                products =
                    products
                        .Include(i => i.ProductPublishers)
                        .ThenInclude(i => i.Publisher)
                        .Where(i =>
                            i
                                .ProductPublishers
                                .Any(a => a.Publisher.Url == name));
            }
            return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        // public List<Product>
        // GetProductsByTranslator(string name, int page, object pageSize)
        // {
        //     var products =
        //         ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
        //     if (!string.IsNullOrEmpty(name))
        //     {
        //         products =
        //             products
        //                 .Include(i => i.ProductTranslators)
        //                 .ThenInclude(i => i.Translator)
        //                 .Where(i =>
        //                     i
        //                         .ProductTranslators
        //                         .Any(a => a.Translator.Url == name));
        //     }
        //      return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        // }
        public List<Product>
        GetProductsByAuthor(string name)
        {
            var products =
                ShopContext.Products.Where(i => i.IsApproved).AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                products =
                    products
                        .Include(i => i.ProductAuthors)
                        .ThenInclude(i => i.Author)
                        .Where(i =>
                            i.ProductAuthors.Any(a => a.Author.Url == name));
            }
            return products.ToList();
        }

        public List<Product>
        GetProductsByTranslator(string name, int page, object pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
