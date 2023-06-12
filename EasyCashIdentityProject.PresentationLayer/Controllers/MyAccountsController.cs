using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
  //"Authorize" attributini(özelliğini) eklediğimiz zaman - bu sayfada artık login işlemi zorunda kalmış olur ||Yani kullanıcı login yapmazsa bu sayfaya erişimi sağlayamaz || Разрешить , Yetki vermek
     [Authorize]   //HTTP ERROR 404 - döner
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Sisteme login yapan bilğisini getiriyor olacak
            var values = await _userManager.FindByNameAsync(User.Identity.Name); 
            AppUserEditDto appUserEditDto = new AppUserEditDto();
            appUserEditDto.Name = values.Name;  
            appUserEditDto.Surname = values.SurName;
            appUserEditDto.PhoneNumber = values.PhoneNumber;
            appUserEditDto.Email = values.Email;
            appUserEditDto.City = values.City;
            appUserEditDto.District = values.District;  
            appUserEditDto.ImageUrl = values.ImageUrl;  
            return View(appUserEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        {
            //Eğer "appUSerEditDto dan" gelen "Password" --> "appUserEdit den " gelen "ConfirimPassworde"eşit ise, işlem gerçekleşisin, eşleşmitorsa bir uyarı versin 
             if(appUserEditDto.Password == appUserEditDto.CofirmPassword) {
                 var user = await _userManager.FindByNameAsync(User.Identity.Name);
                 user.PhoneNumber = appUserEditDto.PhoneNumber;
                 user.SurName = appUserEditDto.Surname;
                 user.City = appUserEditDto.City;    
                 user.District = appUserEditDto.District;
                 user.Name = appUserEditDto.Name;
                 user.ImageUrl = "test";
                 user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result = await _userManager.UpdateAsync(user);  
                if(result.Succeeded) 
                {
                    //eğer sonucu başarılı dönerse --> Bizi Index/Login ne yönlendirsin
                    return RedirectToAction("Index", "Login");  
                }
             }
             return View();
            
        }
    }
}
