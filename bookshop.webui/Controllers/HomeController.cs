using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookshop.data.Abstract;
using bookshop.business.Abstract;
using bookshop.webui.Models;
using System.Net.Http;
using bookshop.entity;
using Newtonsoft.Json;

namespace bookshop.webui.Controllers
{
    public class HomeController:Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService=productService;
        }
        public IActionResult Index()
        {
            var productViewModel = new ProductListViewModel()
            {
               
                Products = _productService.GetHomePageProduct()
            };
            return View(productViewModel);
        }

        public async Task<IActionResult> GetProductsFromRestApi()
        {
            var products = new List<Product>();
            using(var httpClient=new HttpClient())
            {
                using(var response=await httpClient.GetAsync("http://localhost:4200/api/products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(products);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View("MyView");
        }
    }
}