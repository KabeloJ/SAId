using Core.AccountDetails.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Core.AccountDetails.Models;

namespace SAId.Controllers
{
    public class AccountDetailsController : Controller
    {
        private readonly IAccountDetailsServices _accountDetails;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountDetailsController(IAccountDetailsServices accountDetails, SignInManager<IdentityUser> signInManager)
        {
            _accountDetails = accountDetails;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _accountDetails.Get(userId);
            if (model == null)
            {
                //User still new, needs to update details
                return View(new AccountDetailsModel() { AspNetUserId = userId });
            }
            return View(model);
        }
        [HttpPost]
        public void Submit(AccountDetailsModel model)
        {
            if (model != null)
            {
                model.IsPostalAddressSameAsPhysical = model.isPostalAddressSameAsPhysical;
            }
        }
    }
}
