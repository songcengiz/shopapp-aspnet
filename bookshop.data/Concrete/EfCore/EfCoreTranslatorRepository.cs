using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.data.Abstract;
using bookshop.entity;
using Microsoft.EntityFrameworkCore;

namespace bookshop.data.Concrete.EfCore
{
    public class EfCoreTranslatorRepository:EfCoreGenericRepository<Translator>, ITranslatorRepository
    {
         public EfCoreTranslatorRepository(ShopContext context):base(context)
        {
            
        }
        private ShopContext ShopContext
        {
            get{return context as ShopContext;}
        }

        public void DeleteFromTranslator(int productId, int translatorId)
        {
            var cmd="delete from producttranslator where ProductId=@p0 and TranslatorId=@p1";
              ShopContext.Database.ExecuteSqlRaw(cmd,productId,translatorId);
        }

        public Translator GetTranslatorDetails(string url)
        {
           return ShopContext
                    .Translators
                    .Where(i => i.Url == url)
                    .Include(i => i.ProductTranslators)
                    .ThenInclude(i => i.Translator)
                    .FirstOrDefault();
            
        }

        public Translator GetByIdWithProducts(int translatorId)
        {
            return ShopContext.Translators.Where(i=>i.TranslatorId==translatorId).Include(i=>i.ProductTranslators).ThenInclude(i=>i.Product).FirstOrDefault();
        }

         public void Update(Translator entity, int[] productIds)
        {
            var translator =
                ShopContext
                    .Translators
                    .Include(i => i.ProductTranslators)
                    .FirstOrDefault(i => i.TranslatorId == entity.TranslatorId);

            if (translator != null)
            {
               translator.Name = entity.Name;
          
               translator.Description = entity.Description;
                translator.Url = entity.Url;
               translator.ImageTranslator = entity.ImageTranslator;
             
              
              translator.ProductTranslators =
                    productIds
                        .Select(prodid =>
                            new ProductTranslator()
                            {
                                TranslatorId = entity.TranslatorId,
                                ProductId = prodid
                            })
                        .ToList();
            }
        }
    }
}