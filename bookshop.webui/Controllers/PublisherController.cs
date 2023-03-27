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
    public class PublisherController:Controller
    {
        private IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            this._publisherService=publisherService;
        } 
        public IActionResult Details(string url)
        {
           if(url==null)
            {
                return NotFound();
            }
            Publisher publisher= _publisherService.GetPublisherDetails(url);
            if(publisher==null)
            {
                return NotFound();
            }
            return View(new PublisherDetailModel{
                Publisher = publisher,
                Products=publisher.ProductPublishers.Select(i=>i.Product).ToList(),
               
              
            });
        }

        public IActionResult List(string url)
        {
            
            var publisherListViewModel =
                new PublisherListViewModel()
                {
                    PageInfo = new PageInfo(){
                       
                      
                     
                    
                      
                       
                    },
                    
                };
            
            return View(publisherListViewModel);
        }

        public IActionResult Search(string q)
        {
            var publisherViewModel =
                new PublisherListViewModel()
                {
                   
                    Publishers =
                        _publisherService
                            .GetSearchResult(q)
                };
            return View(publisherViewModel);
        }

    }
}