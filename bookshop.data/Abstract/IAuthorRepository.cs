using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.data.Abstract
{
    public interface IAuthorRepository:IRepository<Author>
    {
        List<Author> GetSearchResult(string searchString);
        Author GetByIdWithProducts(int authorId);

       void DeleteFromAuthor(int productId,int authorId);
        Author GetAuthorDetails(string url);
        void Update(Author entity, int[] productIds);
    }
}