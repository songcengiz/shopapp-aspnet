using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.entity;
using bookshop.webui.Models;

using Microsoft.AspNetCore.Mvc;

namespace bookshop.webui.Controllers
{
    public class ShopController:Controller
    {
        private IProductService _productService;
        private IAuthorService _authorService;
        private IPublisherService _publisherService;

        public ShopController(IProductService productService,IAuthorService authorService,IPublisherService publisherService)
        {
            this._productService=productService;
            this._authorService=authorService;
            this._publisherService=publisherService;
            
            
        }

        // localhost/products/telefon?page=1
        public IActionResult List(string category,int page = 1)
        {
            const int pageSize = 3;
            var productViewModel =
                new ProductListViewModel()
                {
                    PageInfo = new PageInfo(){
                        TotalItems = _productService.GetCountByCategory(category),
                        
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        CurrentCategory = category,
                      
                       
                    },
                    Products =
                        _productService
                            .GetProductsByCategory(category, page, pageSize)
                };
            
            return View(productViewModel);
        }
        public IActionResult Details(string url)
        {
            if(url==null)
            {
                return NotFound();
            }
            Product product= _productService.GetProductDetails(url);
            if(product==null)
            {
                return NotFound();
            }
            return View(new ProductDetailModel{
                Product = product,
                Categories =product.ProductCategories.Select(i=>i.Category).ToList(),
                Publishers=product.ProductPublishers.Select(i=>i.Publisher).ToList(),
                Authors=product.ProductAuthors.Select(i=>i.Author).ToList(),
                Translators=product.ProductTranslators.Select(i=>i.Translator).ToList()
             
                
              
            });
        }
      
        
        public IActionResult Search(string q)
        {
            var productViewModel =
                new ProductListViewModel()
                {Products = _productService
                            .GetSearchResult(q),
                 Authors=_authorService.GetSearchResult(q),
                 Publishers=_publisherService.GetSearchResult(q)  
                };
               
            return View(productViewModel);

      
        }

      
    }
}