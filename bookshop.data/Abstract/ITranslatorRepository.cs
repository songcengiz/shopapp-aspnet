using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.data.Abstract
{
    public interface ITranslatorRepository : IRepository<Translator>
    {
        Translator GetByIdWithProducts(int translatorId);
        void DeleteFromTranslator(int productId, int translatorId);

         Translator GetTranslatorDetails(string url);

         void Update(Translator entity, int[] productIds);
    }
}