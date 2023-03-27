using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.data.Abstract
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        List<Publisher> GetSearchResult(string searchString);
        void DeleteFromPublisher(int productId, int publisherId);
        Publisher GetByIdWithProducts(int publisherId);
        Publisher GetPublisherDetails(string url);

        void Update(Publisher entity, int[] productIds);
    }
}