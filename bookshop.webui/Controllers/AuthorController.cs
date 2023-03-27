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
    public class AuthorController:Controller
    {
        private IAuthorService _authorService;
        private IProductService _productService;

        public AuthorController(IAuthorService authorService,IProductService productService)
        {
            this._authorService=authorService;
            this._productService=productService;
        } 
        public IActionResult Details(string url)
        {
           if(url==null)
            {
                return NotFound();
            }
            Author author= _authorService.GetAuthorDetails(url);
            if(author==null)
            {
                return NotFound();
            }
            return View(new AuthorDetailModel{
                Author = author,
                Products=author.ProductAuthors.Select(i=>i.Product).ToList(),
               
              
            });
        }

      
        public IActionResult List(string url)
        {
            
            var authorListViewModel =
                new AuthorListViewModel()
                {
                        
                    
                };
            
            return View(authorListViewModel);
        }

        public IActionResult Search(string q)
        {
            var authorViewModel =
                new AuthorListViewModel()
                {
                   
                    Authors =
                        _authorService
                            .GetSearchResult(q)
                };
            return View(authorViewModel);
        }

    }
    }
