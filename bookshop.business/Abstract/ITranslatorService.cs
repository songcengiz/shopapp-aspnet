using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.business.Abstract
{
    public interface ITranslatorService:IValidator<Translator>
    {
        Translator GetTranslatorDetails(string url);
        
        Task<Translator> GetById(int id);

        Translator GetByIdWithProducts(int translatorId);

        Task<List<Translator>> GetAll();

        bool Create(Translator entity);
        Task<Translator> CreateAsync(Translator entity);

        void Update(Translator entity);

        bool Update(Translator entity, int[] productIds);

        void Delete(Translator entity);

        void DeleteFromTranslator(int productId,int translatorId);
    }
}