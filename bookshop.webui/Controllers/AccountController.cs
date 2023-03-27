using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookshop.business.Abstract;
using bookshop.webui.EmailServices;
using bookshop.webui.Extensions;
using bookshop.webui.Identity;
using bookshop.webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.webui.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;

        private SignInManager<User> _signInManager;

        private IEmailSender _emailSender;
        private ICartService _cartService;
     

        public AccountController( ICartService cartService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender
        )
        {
            _cartService = cartService;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel() { ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState
                    .AddModelError("",
                    "Bu kullanıcı adı ile daha önce bir hesap oluşturulmadı.");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState
                    .AddModelError("",
                    "Email hesabınıza gelen linke tıklayarak üyeliğinizi onaylayın.");
                return View(model);
            }
            var result =  await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
               
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }
            ModelState
                .AddModelError("", "Girilen kullanıcı adı veya parola yanlış.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user =
                new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                
                // generic token
                var code =
                    await _userManager
                        .GenerateEmailConfirmationTokenAsync(user);
                var url = Url
                        .Action("ConfirmEmail",
                        "Account",
                        new { userId = user.Id, token = code });
                
                 await _emailSender.SendEmailAsync(model.Email,"Hesabınızı onaylayınız.",$"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:5000{url}'>tıklayınız.</a>");
                return RedirectToAction("Login","Account");
            }           

            ModelState.AddModelError("","Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData
                .Put("message",
                new AlertMessage()
                {
                    Title = "Oturum kapatıldı.",
                    Message = "Hesabınız güvenli bir şekilde kapatıldı.",
                    AlertType = "warning"
                });
            return Redirect("~/");
        }

        public async Task<IActionResult>
        ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData
                    .Put("message",
                    new AlertMessage()
                    {
                        Title = "Geçersiz token",
                        Message = "Geçersiz Token",
                        AlertType = "danger"
                    });
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    // card objesini oluştur.
                    _cartService.InitializeCart(user.Id);
                    
                    TempData
                        .Put("message",
                        new AlertMessage()
                        {
                            Title = "Hesabınız onaylandı",
                            Message = "Hesabınız onaylandı",
                            AlertType = "success"
                        });

                    return View();
                }
            }
            TempData
                .Put("message",
                new AlertMessage()
                {
                    Title = "Hesabınız onaylanmadı",
                    Message = "Hesabınız onaylanmadı",
                    AlertType = "warning"
                });
            return View();
        }

        
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
            {
                return View();
            }

            // generic token
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url =
                Url
                    .Action("ResetPassword",
                    "Account",
                    new { userId = user.Id, token = code });

          
            // email
            await _emailSender.SendEmailAsync(Email,"Reset Password",$"Parolanızı yenilemek için linke <a href='http://localhost:5000{url}'>tıklayınız.</a>");

            return View();
        
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Home", "Index");
            }
            var model = new ResetPasswordModel { Token = token };
            return View();
        }

         [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user==null)
            {
                return RedirectToAction("Home","Index");
            }

            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Login","Account");
            }

            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
