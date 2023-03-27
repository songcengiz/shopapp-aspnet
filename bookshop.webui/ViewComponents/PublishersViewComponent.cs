using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.webui.ViewComponents
{
    public class PublishersViewComponent:ViewComponent
    {
        private IPublisherService _publisherService;
        public PublishersViewComponent(IPublisherService publisherService)
        {
            this._publisherService=publisherService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(RouteData.Values["publisher"]!=null)
            ViewBag.SelectedPublisher = RouteData?.Values["publisher"];

            return View(await _publisherService.GetAll());
           
        }
        
    }
}