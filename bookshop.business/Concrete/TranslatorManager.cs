using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.data.Abstract;
using bookshop.entity;

namespace bookshop.business.Concrete
{
    public class TranslatorManager : ITranslatorService
    {
        private readonly IUnitOfWork _unitofwork;
        public TranslatorManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public string ErrorMessage { get;set; }
        

         public bool Create(Translator entity)
        {
            if (Validation(entity))
            {
                _unitofwork.Translators.Create (entity);
                _unitofwork.Save();
                return true;
            }
            return false;
        }
        
        public async Task<Translator> CreateAsync(Translator entity)
        {
           await _unitofwork.Translators.CreateAsync(entity);
           await _unitofwork.SaveAsync();
           return entity;
        }


        public void Delete(Translator entity)
        {
           _unitofwork.Translators.Delete(entity);
           _unitofwork.Save();
        }

        public void DeleteFromTranslator(int productId, int translatorId)
        {
           _unitofwork.Translators.DeleteFromTranslator(productId,translatorId);
        }

        public async Task< List<Translator>> GetAll()
        {
            return await _unitofwork.Translators.GetAll();
        }

        public async Task<Translator> GetById(int id)
        {
            return await _unitofwork.Translators.GetById(id);
        }
          public Translator GetByIdWithProducts(int translatorId)
        {
            return _unitofwork.Translators.GetByIdWithProducts(translatorId);
        }

        public Translator GetTranslatorDetails(string url)
        {
             return _unitofwork.Translators.GetTranslatorDetails(url);
        }

        public void Update(Translator entity)
        {
           _unitofwork.Translators.Update(entity);
           _unitofwork.Save();
        }

        public bool Update(Translator entity, int[] productIds)
        {
            if (Validation(entity))
            {
                if (productIds.Length == 0)
                {
                    ErrorMessage +=
                        "Ürün için en az bir product seçmelisiniz.";
                    return false;
                }
             _unitofwork.Translators.Update (entity, productIds);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(Translator entity)
        {
            var IsValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "translator ismi girmelisiniz.\n";
            }

             return IsValid;
        }
        
    }
}