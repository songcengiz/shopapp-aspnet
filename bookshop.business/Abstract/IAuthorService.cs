using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.business.Abstract
{
    public interface IAuthorService:IValidator<Author>
    {
        List<Author> GetSearchResult(string searchString);
        Author GetAuthorDetails(string url);
        Task<Author> GetById(int id);

        Author GetByIdWithProducts(int categoryId);
        Task<List<Author>> GetAll();

        bool Create(Author entity);
        Task<Author> CreateAsync(Author entity);

        bool Update(Author entity, int[] productIds);

        void Update(Author entity);

        void Delete(Author entity);

        void DeleteFromAuthor(int productId,int authorId); 
    }
}