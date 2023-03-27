using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.data.Abstract;
using bookshop.entity;

namespace bookshop.business.Concrete
{
    public class AuthorManager : IAuthorService
    {
       private readonly IUnitOfWork _unitofwork;
        public AuthorManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public string ErrorMessage { get;set; }
        

      public bool Create(Author entity)
        {
            if (Validation(entity))
            {
                _unitofwork.Authors.Create (entity);
                _unitofwork.Save();
                return true;
            }
            return false;
        }
        
        public async Task<Author> CreateAsync(Author entity)
        {
           await _unitofwork.Authors.CreateAsync(entity);
           await _unitofwork.SaveAsync();
           return entity;
        }


        public void Delete(Author entity)
        {
           _unitofwork.Authors.Delete(entity);
           _unitofwork.Save();
        }

        public void DeleteFromAuthor(int productId, int authorId)
        {
           _unitofwork.Authors.DeleteFromAuthor(productId,authorId);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _unitofwork.Authors.GetAll();
        }

        public Author GetAuthorDetails(string url)
        {
            return _unitofwork.Authors.GetAuthorDetails(url);
        }

        public async Task<Author> GetById(int id)
        {
            return await _unitofwork.Authors.GetById(id);
        }
          public Author GetByIdWithProducts(int authorId)
        {
            return _unitofwork.Authors.GetByIdWithProducts(authorId);
        }

        public List<Author> GetSearchResult(string searchString)
        {
             return _unitofwork.Authors.GetSearchResult(searchString);
        }

        public void Update(Author entity)
        {
           _unitofwork.Authors.Update(entity);
           _unitofwork.Save();
        }

        
        public bool Update(Author entity, int[] productIds)
        {
            if (Validation(entity))
            {
                if (productIds.Length == 0)
                {
                    ErrorMessage +=
                        "Ürün için en az bir product seçmelisiniz.";
                    return false;
                }
                _unitofwork.Authors.Update (entity, productIds);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public bool Validation(Author entity)
        {
            var IsValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "yazar ismi girmelisiniz.\n";
            }

             return IsValid;
        }
    }
}