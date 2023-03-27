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
    public class TranslatorController:Controller
    {
        private ITranslatorService _translatorService;
        public TranslatorController(ITranslatorService translatorService)
        {
            this._translatorService=translatorService;
        } 
        public IActionResult Details(string url)
        {
           if(url==null)
            {
                return NotFound();
            }
           Translator translator= _translatorService.GetTranslatorDetails(url);
            if(translator==null)
            {
                return NotFound();
            }
            return View(new TranslatorDetailModel{
                Translator = translator,
                Products=translator.ProductTranslators.Select(i=>i.Product).ToList(),
               
              
            });
        }

      
        public IActionResult List(string url)
        {
            
            var authorListViewModel =
                new AuthorListViewModel()
                {
                    // PageInfo = new PageInfo(){
                      
                    // },
                    
                };
            
            return View(authorListViewModel);
        }
    }
}