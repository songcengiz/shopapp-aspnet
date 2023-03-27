using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.data.Abstract;

namespace bookshop.data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _context;
        public UnitOfWork(ShopContext context)
        {
            _context = context;
        }
        private EfCoreCartRepository _cartRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreOrderRepository _orderRepository;
        private EfCoreProductRepository _productRepository;
        private EfCoreAuthorRepository _authorRepository;
        private EfCorePublisherRepository _publisherRepository;
        private EfCoreTranslatorRepository _translatorRepository;
        public ITranslatorRepository Translators => _translatorRepository = _translatorRepository ?? new EfCoreTranslatorRepository(_context);
        public IAuthorRepository Authors => _authorRepository = _authorRepository ?? new EfCoreAuthorRepository(_context);

        public IPublisherRepository Publishers => _publisherRepository = _publisherRepository ?? new EfCorePublisherRepository(_context);

        public ICartRepository Carts => _cartRepository = _cartRepository ?? new EfCoreCartRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new EfCoreOrderRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new EfCoreProductRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
         public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}