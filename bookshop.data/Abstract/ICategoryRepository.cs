using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.entity;

namespace bookshop.data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
     
       Category GetByIdWithProducts(int categoryId);

       void DeleteFromCategory(int productId,int categoryId);
    }
}