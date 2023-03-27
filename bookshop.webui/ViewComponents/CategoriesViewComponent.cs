using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace bookshop.webui.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this._categoryService=categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(RouteData.Values["category"]!=null)
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(await _categoryService.GetAll());
           
        }
        
    }
}
