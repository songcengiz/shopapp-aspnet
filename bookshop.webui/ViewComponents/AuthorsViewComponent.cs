using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.webui.ViewComponents
{
    public class AuthorsViewComponent:ViewComponent
    {
        private IAuthorService _authorService;
        public AuthorsViewComponent(IAuthorService authorService)
        {
            this._authorService=authorService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(RouteData.Values["author"]!=null)
            ViewBag.SelectedAuthor = RouteData?.Values["author"];

            return View(await _authorService.GetAll());
           
        }
    }
}