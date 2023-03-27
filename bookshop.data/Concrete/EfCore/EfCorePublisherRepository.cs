using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.data.Abstract;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;

namespace bookshop.data.Concrete.EfCore
{
    public class EfCorePublisherRepository : EfCoreGenericRepository<Publisher>, IPublisherRepository
    {
        public EfCorePublisherRepository(ShopContext context):base(context)
        {
            
        }
        private ShopContext ShopContext
        {
            get{return context as ShopContext;}
        }

        public void DeleteFromPublisher(int productId, int publisherId)
        {
            var cmd="delete from productpublisher where ProductId=@p0 and PublisherId=@p1";
              ShopContext.Database.ExecuteSqlRaw(cmd,productId,publisherId);
        }

        public Publisher GetPublisherDetails(string url)
        {
           return ShopContext
                    .Publishers
                    .Where(i => i.Url == url)
                    .Include(i => i.ProductPublishers)
                    .ThenInclude(i => i.Publisher)
                    .Include(i=>i.ProductPublishers)
                    .ThenInclude(i=>i.Product)
                    .FirstOrDefault();
            
        }

        public Publisher GetByIdWithProducts(int publisherId)
        {
              return ShopContext.Publishers.Where(i=>i.PublisherId==publisherId).Include(i=>i.ProductPublishers).ThenInclude(i=>i.Product).FirstOrDefault();
        }
        public List<Publisher> GetSearchResult(string searchString)
        {
             
                var publishers =
                    ShopContext.Publishers.Where(i => i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower()))
                    .AsQueryable();
                
                return publishers.ToList();
                    
            
        }

         public void Update(Publisher entity, int[] productIds)
        {
            var publisher =
                ShopContext
                    .Publishers
                    .Include(i => i.ProductPublishers)
                    .FirstOrDefault(i => i.PublisherId == entity.PublisherId);

            if (publisher != null)
            {
               publisher.Name = entity.Name;
          
               publisher.Description = entity.Description;
                publisher.Url = entity.Url;
                publisher.ImageLogo = entity.ImageLogo;
                publisher.Address=entity.Address;
                publisher.Appellation=entity.Appellation;
                publisher.Email=entity.Email;
                publisher.Phone=entity.Phone;
                publisher.Website=entity.Website;
              
              publisher.ProductPublishers =
                    productIds
                        .Select(prodid =>
                            new ProductPublisher()
                            {
                                PublisherId = entity.PublisherId,
                                ProductId = prodid
                            })
                        .ToList();
            }
        }
    }
}