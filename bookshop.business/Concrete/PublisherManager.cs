using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.data.Abstract;
using bookshop.entity;

namespace bookshop.business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        private readonly IUnitOfWork _unitofwork;
        public PublisherManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public string ErrorMessage { get;set; }
        

        public bool Create(Publisher entity)
        {
            if (Validation(entity))
            {
                _unitofwork.Publishers.Create (entity);
                _unitofwork.Save();
                return true;
            }
            return false;
        }
        
        public async Task<Publisher> CreateAsync(Publisher entity)
        {
           await _unitofwork.Publishers.CreateAsync(entity);
           await _unitofwork.SaveAsync();
           return entity;
        }

        public void Delete(Publisher entity)
        {
           _unitofwork.Publishers.Delete(entity);
           _unitofwork.Save();
        }

        public void DeleteFromPublisher(int productId, int publisherId)
        {
           _unitofwork.Publishers.DeleteFromPublisher(productId,publisherId);
        }

        public async Task<List<Publisher>> GetAll()
        {
            return await _unitofwork.Publishers.GetAll();
        }

        public async Task<Publisher> GetById(int id)
        {
            return await _unitofwork.Publishers.GetById(id);
        }
          public Publisher GetByIdWithProducts(int publisherId)
        {
            return _unitofwork.Publishers.GetByIdWithProducts(publisherId);
        }

        public Publisher GetPublisherDetails(string url)
        {
             return _unitofwork.Publishers.GetPublisherDetails(url);
        }

        public List<Publisher> GetSearchResult(string searchString)
        {
             return _unitofwork.Publishers.GetSearchResult(searchString);
        }

        public void Update(Publisher entity)
        {
           _unitofwork.Publishers.Update(entity);
           _unitofwork.Save();
        }

         public bool Update(Publisher entity, int[] productIds)
        {
            if (Validation(entity))
            {
                if (productIds.Length == 0)
                {
                    ErrorMessage +=
                        "Ürün için en az bir product seçmelisiniz.";
                    return false;
                }
             _unitofwork.Publishers.Update (entity, productIds);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(Publisher entity)
        {
            var IsValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "publisher ismi girmelisiniz.\n";
            }

             return IsValid;
        }
    }
}