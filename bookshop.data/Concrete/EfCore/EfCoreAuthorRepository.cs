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
    public class EfCoreAuthorRepository:EfCoreGenericRepository<Author>, IAuthorRepository
    {
         public EfCoreAuthorRepository(ShopContext context):base(context)
        {
            
        }
        private ShopContext ShopContext
        {
            get{return context as ShopContext;}
        }

        public void DeleteFromAuthor(int productId, int authorId)
        {
            var cmd="delete from productauthor where ProductId=@p0 and AuthorId=@p1";
              ShopContext.Database.ExecuteSqlRaw(cmd,productId,authorId);
        }

        public Author GetAuthorDetails(string url)
        {
           return ShopContext
                    .Authors
                    .Where(i => i.Url == url)
                    .Include(i => i.ProductAuthors)
                    .ThenInclude(i => i.Author)
                    .FirstOrDefault();
            
        }

        public Author GetByIdWithProducts(int authorId)
        {
              return ShopContext.Authors.Where(i=>i.AuthorId==authorId).Include(i=>i.ProductAuthors).ThenInclude(i=>i.Product).FirstOrDefault();
        }
        public List<Author> GetSearchResult(string searchString)
        {
             
                var authors =
                    ShopContext.Authors.Where(i => i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower()))
                    .AsQueryable();
                
                return authors.ToList();
                    
            
        }

         public void Update(Author entity, int[] productIds)
        {
            var author =
                ShopContext
                    .Authors
                    .Include(i => i.ProductAuthors)
                    .FirstOrDefault(i => i.AuthorId == entity.AuthorId);

            if (author != null)
            {
               author.Name = entity.Name;
          
                author.Description = entity.Description;
                author.Url = entity.Url;
                author.ImageAuthor = entity.ImageAuthor;

               author.ProductAuthors =
                    productIds
                        .Select(prodid =>
                            new ProductAuthor()
                            {
                                AuthorId = entity.AuthorId,
                                ProductId = prodid
                            })
                        .ToList();
            }
        }

    }
}