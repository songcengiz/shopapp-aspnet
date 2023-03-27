using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.business.Abstract
{
    public interface IPublisherService:IValidator<Publisher>
    {
        Publisher GetPublisherDetails(string url);
        List<Publisher> GetSearchResult(string searchString);
        Task<Publisher> GetById(int id);

        Publisher GetByIdWithProducts(int publisherId);
        Task<List<Publisher>> GetAll();

        bool Create(Publisher entity);
        Task<Publisher> CreateAsync(Publisher entity);

        void Update(Publisher entity);
        bool Update(Publisher entity, int[] productIds);

        void Delete(Publisher entity);

        void DeleteFromPublisher(int productId,int publisherId);
    }
}