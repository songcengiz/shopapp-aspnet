using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.entity;
using bookshop.webui.Extensions;
using bookshop.webui.Identity;
using bookshop.webui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace bookshop.webui.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;

        private ICategoryService _categoryService;

        private IAuthorService _authorService;

        private IPublisherService _publisherService;

        private ITranslatorService _translatorService;

        private RoleManager<IdentityRole> _roleManager;

        private UserManager<User> _userManager;

        public AdminController(
            IProductService productService,
            ICategoryService categoryService,
            IPublisherService publisherService,
            ITranslatorService translatorService,
            IAuthorService authorService,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager

        )
        {
            _productService = productService;
            _categoryService = categoryService;
            _authorService=authorService;
            _publisherService=publisherService;
            _translatorService=translatorService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user!=null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i=>i.Name);

                ViewBag.Roles=roles;
                return View(new UserDetailsModel(){
                    UserId=user.Id,
                    UserName=user.UserName,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                    EmailConfirmed=user.EmailConfirmed,
                    
                    SelectedRoles=selectedRoles

                });
            }
            return Redirect("~/admin/user/list");
        }
         
         [HttpPost]
         public async Task<IActionResult> UserEdit(UserDetailsModel model,string[] selectedRoles)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user!=null)
                {
                    user.FirstName=model.FirstName;
                    user.LastName=model.LastName;
                    user.UserName=model.UserName;
                    user.Email=model.Email;
                    user.EmailConfirmed=model.EmailConfirmed;

                    var result = await _userManager.UpdateAsync(user);
                    if(result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles?? new string[]{};
                        await _userManager.AddToRolesAsync(user,selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user,userRoles.Except(selectedRoles).ToArray<string>());

                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }
            return View(model);
        }


        public IActionResult UserList()
        {
            
            return View(_userManager.Users);
        }
         public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user,role.Name)
                                ?members:nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if(ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                              foreach (var error in result.Errors)
                              { 
                                ModelState.AddModelError("", error.Description);  
                              }  
                        }
                    }
                }
          
                foreach (var userId in model.IdsToDelete ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user,model.RoleName);
                        if(!result.Succeeded)
                        {
                              foreach (var error in result.Errors)
                              { 
                                ModelState.AddModelError("", error.Description);  
                              }  
                        }
                    }
                }
            }
            return Redirect("/admin/role/"+model.RoleId);
        }
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        } 
         public IActionResult RoleCreate()
        {
            return View();
        } 
        [HttpPost]
         public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if(result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
                
            }
            return View();
        } 

        public async Task<IActionResult> ProductList()
        { var products=await _productService.GetAll();
            return View(new ProductListViewModel()
            { Products = products});
        }
         public async Task<IActionResult> AuthorList()
        {
            var authors=await _authorService.GetAll();
            return View(new AuthorListViewModel()
            { Authors = authors });
        }
         public async Task<IActionResult> PublisherList()
        {
            var publishers=await _publisherService.GetAll();
            return View(new PublisherListViewModel()
            { Publishers = publishers });
        }
         public async Task<IActionResult> TranslatorList()
        {
            var translators=await _translatorService.GetAll();
            return View(new TranslatorListViewModel()
            { Translators = translators });
        }

        public async Task<IActionResult> CategoryList()
        {
            var categories=await _categoryService.GetAll();
            return View(new CategoryListViewModel()
            { Categories = categories});
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    new Product()
                    {
                        Name = model.Name,
                        Url = model.Url,
                        Price = model.Price,
                        Description = model.Description,
                        ImageUrl = model.ImageUrl,
                        Language=model.Language,
                        ISBN=model.ISBN,
                        NumberOfPage=model.NumberOfPage,
                        PaperType=model.PaperType,
                        DateAdded=model.DateAdded
                    };
                if (_productService.Create(entity))
                {
                     TempData.Put("message", new AlertMessage()
                {
                    Title = "Kayıt eklendi",
                    Message = "Kayıt eklendi",
                    AlertType = "success"
                });
                    
                    return RedirectToAction("ProductList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _productService.ErrorMessage,
                    AlertType = "danger"
                });
               
                return View(model);
            }
            return View(model);
        }
         [HttpGet]
        public IActionResult AuthorCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AuthorCreate(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    new Author()
                    {
                        Name = model.Name,
                        Url = model.Url,
                        Description = model.Description,
                        ImageAuthor = model.ImageAuthor
                       
                    };
                if (_authorService.Create(entity))
                {
                     TempData.Put("message", new AlertMessage()
                {
                    Title = "Kayıt eklendi",
                    Message = "Kayıt eklendi",
                    AlertType = "success"
                });
                    
                    return RedirectToAction("AuthorList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _authorService.ErrorMessage,
                    AlertType = "danger"
                });
               
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PublisherCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PublisherCreate(PublisherModel model)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    new Publisher()
                    {
                        Name = model.Name,
                        Url = model.Url,
                        Description = model.Description,
                        ImageLogo = model.ImageLogo,
                        Email=model.Email,
                        Website=model.Website,
                        Phone=model.Phone,
                        Appellation=model.Appellation,
                        Address=model.Address

                       
                    };
                if (_publisherService.Create(entity))
                {
                     TempData.Put("message", new AlertMessage()
                {
                    Title = "Kayıt eklendi",
                    Message = "Kayıt eklendi",
                    AlertType = "success"
                });
                    
                    return RedirectToAction("PublisherList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _publisherService.ErrorMessage,
                    AlertType = "danger"
                });
               
                return View(model);
            }
            return View(model);
        }

          [HttpGet]
        public IActionResult TranslatorCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TranslatorCreate(TranslatorModel model)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    new Translator()
                    {
                        Name = model.Name,
                        Url = model.Url,
                        Description = model.Description,
                        ImageTranslator = model.ImageTranslator
                       
                    };
                if (_translatorService.Create(entity))
                {
                     TempData.Put("message", new AlertMessage()
                {
                    Title = "Kayıt eklendi",
                    Message = "Kayıt eklendi",
                    AlertType = "success"
                });
                    
                    return RedirectToAction("TranslatorList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _translatorService.ErrorMessage,
                    AlertType = "danger"
                });
               
                return View(model);
            }
            return View(model);
        }
      
      

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity =
                    new Category() { Name = model.Name, Url = model.Url };
                _categoryService.Create (entity);
                TempData.Put("message",new AlertMessage()
                {
                    Title = "Kayıt eklendi.",
                    Message =  $"{entity.Name} isimli kategori eklendi.",
                    AlertType = "success"
                });
                
                return RedirectToAction("CategoryList");
            }
            return View(model);
        }

        [HttpGet]
        public async Task< IActionResult> ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategories((int) id);
             if (entity == null)
            {
                return NotFound();
            }
            var entity1 = _productService.GetByIdWithAuthors((int) id);
            if (entity1 == null)
            {
                return NotFound();
            }
                var entity2 = _productService.GetByIdWithPublishers((int) id);
            if (entity1 == null)
            {
                return NotFound();
            }
                var entity3 = _productService.GetByIdWithTranslators((int) id);
            if (entity1 == null)
            {
                return NotFound();
            }
            var model =
                new ProductModel()
                {
                    ProductId = entity.ProductId,
                    Name = entity.Name,
                    Url = entity.Url,
                    Price = entity.Price,
                    ImageUrl = entity.ImageUrl,
                    Description = entity.Description,
                    IsApproved = entity.IsApproved,
                    IsHome = entity.IsHome,
                    Language=entity.Language,
                    ISBN=entity.ISBN,
                    NumberOfPage=entity.NumberOfPage,
                    PaperType=entity.PaperType,
                    DateAdded=entity.DateAdded,
                    SelectedCategories =
                        entity
                            .ProductCategories
                            .Select(i => i.Category)
                            .ToList(),
                    SelectedAuthors =
                        entity
                            .ProductAuthors
                            .Select(i => i.Author)
                            .ToList(),
                    SelectedPublishers =
                        entity
                            .ProductPublishers
                            .Select(i => i.Publisher)
                            .ToList(),
                    SelectedTranslators =
                        entity
                            .ProductTranslators
                            .Select(i => i.Translator)
                            .ToList()
                };

            ViewBag.Categories = await _categoryService.GetAll();
            ViewBag.Authors=await _authorService.GetAll();
            ViewBag.Publishers=await _publisherService.GetAll();
            ViewBag.Translators=await _translatorService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model, int[] categoryIds,int[] authorIds,int[] publisherIds,int[] translatorIds,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = await _productService.GetById(model.ProductId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Description = model.Description;
               
                entity.Url = model.Url;
                entity.IsApproved=model.IsApproved;
                entity.IsHome=model.IsHome;
                entity.Language=model.Language;
                entity.ISBN=model.ISBN;
                entity.NumberOfPage=model.NumberOfPage;
                entity.PaperType=model.PaperType;
                entity.DateAdded=model.DateAdded;
                
                if(file!=null)
                {
                   
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\coverpage",randomName);


                    using(var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }

                if (_productService.Update(entity, categoryIds,authorIds,publisherIds,translatorIds))
                {
                    TempData.Put("message",new AlertMessage()
                {
                    Title = "kayıt güncellendi",
                    Message = "kayıt güncellendi",
                    AlertType = "success"
                });
                   
                    return RedirectToAction("ProductList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _productService.ErrorMessage,
                    AlertType = "danger"
                });
               
            }
            ViewBag.Categories =await _categoryService.GetAll();
            ViewBag.Authors=await _authorService.GetAll();
            ViewBag.Publishers=await _publisherService.GetAll();
            ViewBag.Translators=await _translatorService.GetAll();
            return View(model);
        }

         [HttpGet]
        public async Task<IActionResult> AuthorEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _authorService.GetByIdWithProducts((int) id);
            if (entity == null)
            {
                return NotFound();
            }
            var model =
                new AuthorModel()
                {
                    AuthorId = entity.AuthorId,
                    Name = entity.Name,
                    Url = entity.Url,
                    ImageAuthor = entity.ImageAuthor,
                    Description = entity.Description,
                    SelectedProducts =
                        entity
                            .ProductAuthors
                            .Select(i => i.Product)
                            .ToList()
                };

            ViewBag.Products = await _productService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AuthorEdit(AuthorModel model, int[] productIds,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = await _authorService.GetById(model.AuthorId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
         
                entity.Description = model.Description;
               
                entity.Url = model.Url;
           
                
                if(file!=null)
                {
                   
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageAuthor = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\imageauthor",randomName);


                    using(var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }

                if (_authorService.Update(entity, productIds))
                {
                    TempData.Put("message",new AlertMessage()
                {
                    Title = "kayıt güncellendi",
                    Message = "kayıt güncellendi",
                    AlertType = "success"
                });
                   
                    return RedirectToAction("AuthorList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _authorService.ErrorMessage,
                    AlertType = "danger"
                });
               
            }
            ViewBag.Products = await _productService.GetAll();
            return View(model);
        }

          [HttpGet]
        public async Task<IActionResult> PublisherEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _publisherService.GetByIdWithProducts((int) id);
            if (entity == null)
            {
                return NotFound();
            }
            var model =
                new PublisherModel()
                {
                    PublisherId = entity.PublisherId,
                    Name = entity.Name,
                    Url = entity.Url,
            
                    ImageLogo = entity. ImageLogo,
                    Description = entity.Description,
                    Email = entity.Email,
                    Website = entity.Website,
                    Phone=entity.Phone,
                    Address=entity.Address,
                    Appellation=entity.Appellation,
                 
                    SelectedProducts =
                        entity
                            .ProductPublishers
                            .Select(i => i.Product)
                            .ToList()
                };

            ViewBag.Products = await _productService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PublisherEdit(PublisherModel model, int[] productIds,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = await _publisherService.GetById(model.PublisherId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;

                entity.Description = model.Description;
               
                entity.Url = model.Url;
                entity.Email=model.Email;
                entity.Appellation=model.Appellation;
                entity.Address=model.Address;
                entity.Website=model.Website;
                entity.Phone=model.Phone;
      
                
                if(file!=null)
                {
                   
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageLogo = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\logo",randomName);


                    using(var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }

                if (_publisherService.Update(entity, productIds))
                {
                    TempData.Put("message",new AlertMessage()
                {
                    Title = "kayıt güncellendi",
                    Message = "kayıt güncellendi",
                    AlertType = "success"
                });
                   
                    return RedirectToAction("PublisherList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _publisherService.ErrorMessage,
                    AlertType = "danger"
                });
               
            }
            ViewBag.Products= await _productService.GetAll();
            return View(model);
        }

         [HttpGet]
        public async Task<IActionResult> TranslatorEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _translatorService.GetByIdWithProducts((int) id);
            if (entity == null)
            {
                return NotFound();
            }
            var model =
                new TranslatorModel()
                {
                    TranslatorId = entity.TranslatorId,
                    Name = entity.Name,
                    Url = entity.Url,
                    ImageTranslator = entity.ImageTranslator,
                    Description = entity.Description,
                    SelectedProducts =
                        entity
                            .ProductTranslators
                            .Select(i => i.Product)
                            .ToList()
                };

            ViewBag.Products = await _productService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TranslatorEdit(TranslatorModel model, int[] productIds,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = await _translatorService.GetById(model.TranslatorId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
         
                entity.Description = model.Description;
               
                entity.Url = model.Url;
           
                
                if(file!=null)
                {
                   
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageTranslator= randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\imagetranslator",randomName);


                    using(var stream=new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }

                if (_translatorService.Update(entity, productIds))
                {
                    TempData.Put("message",new AlertMessage()
                {
                    Title = "kayıt güncellendi",
                    Message = "kayıt güncellendi",
                    AlertType = "success"
                });
                   
                    return RedirectToAction("TranslatorList");
                }
                 TempData.Put("message",new AlertMessage()
                {
                    Title = "Hata",
                    Message = _authorService.ErrorMessage,
                    AlertType = "danger"
                });
               
            }
            ViewBag.Products = await _productService.GetAll();
            return View(model);
        }


        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetByIdWithProducts((int) id);
            if (entity == null)
            {
                return NotFound();
            }
            var model =
                new CategoryModel()
                {
                    CategoryId = entity.CategoryId,
                    Name = entity.Name,
                    Url = entity.Url,
                    Products =
                        entity.ProductCategories.Select(p => p.Product).ToList()
                };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _categoryService.GetById(model.CategoryId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Url = model.Url;

                _categoryService.Update (entity);
                var msg =
                    new AlertMessage()
                    {
                        Message = $"{entity.Name} isimli kitap güncellendi.",
                        AlertType = "success"
                    };

                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("CategoryList");
            }
            return View(model);
        }

        public async Task< IActionResult> DeleteProduct(int productId)
        {
            var entity = await _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete (entity);
            }
            var msg =
                new AlertMessage()
                {
                    Message = $"{entity.Name} isimli kitap silindi.",
                    AlertType = "danger"
                };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("ProductList");
        }

         public async Task< IActionResult> DeleteAuthor(int authorId)
        {
            var entity = await _authorService.GetById(authorId);
            if (entity != null)
            {
                _authorService.Delete (entity);
            }
            var msg =
                new AlertMessage()
                {
                    Message = $"{entity.Name} isimli yazar silindi.",
                    AlertType = "danger"
                };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("AuthorList");
        }

         public async Task<IActionResult> DeletePublisher(int publisherId)
        {
            var entity = await _publisherService.GetById(publisherId);
            if (entity != null)
            {
                _publisherService.Delete (entity);
            }
            var msg =
                new AlertMessage()
                {
                    Message = $"{entity.Name} isimli yayınevi silindi.",
                    AlertType = "danger"
                };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("PublisherList");
        }

         public async Task<IActionResult> DeleteTranslator(int translatorId)
        {
            var entity = await _translatorService.GetById(translatorId);
            if (entity != null)
            {
                _translatorService.Delete (entity);
            }
            var msg =
                new AlertMessage()
                {
                    Message = $"{entity.Name} isimli çevirmen silindi.",
                    AlertType = "danger"
                };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("TranslatorList");
        }



        public async Task< IActionResult> DeleteCategory(int categoryId)
        {
            var entity = await _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete (entity);
            }
            var msg =
                new AlertMessage()
                {
                    Message = $"{entity.Name} isimli kategori silindi.",
                    AlertType = "danger"
                };

            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory (productId, categoryId);
            return Redirect("/admin/categories/" + categoryId);
        }

        [HttpPost]
        public IActionResult DeleteFromAuthor(int productId, int authorId)
        {
            _authorService.DeleteFromAuthor (productId, authorId);
            return Redirect("/admin/authors/" + authorId);
        }
         [HttpPost]
        public IActionResult DeleteFromPublisher(int productId, int publisherId)
        {
            _publisherService.DeleteFromPublisher (productId, publisherId);
            return Redirect("/admin/publishers/" + publisherId);
        }
         [HttpPost]
        public IActionResult DeleteFromTranslator(int productId, int translatorId)
        {
            _translatorService.DeleteFromTranslator (productId, translatorId);
            return Redirect("/admin/translators/" + translatorId);
        }
    }
}
