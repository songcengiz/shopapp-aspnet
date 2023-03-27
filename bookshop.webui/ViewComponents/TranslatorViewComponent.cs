using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.webui.ViewComponents
{
    public class TranslatorViewComponent:ViewComponent
    {
        private ITranslatorService _translatorService;
        public TranslatorViewComponent(ITranslatorService translatorService)
        {
            this._translatorService=translatorService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(RouteData.Values["translator"]!=null)
            ViewBag.SelectedTranslator = RouteData?.Values["translator"];

            return View(await _translatorService.GetAll());
           
        }
    }
}