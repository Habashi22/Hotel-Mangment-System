using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.Security.Claims;
using Stripe;
using System.Text.RegularExpressions;

namespace MVCBookingFinal_YARAB_.Controllers
{
	[AllowAnonymous]
    public class AccountController(IEmailSettings _emailSettings, IWebHostEnvironment env,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> _rolemanager,IUserService _userService) : Controller
    {
		
		// GET: AccounttController
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Register()
		{
			//userManager.GetUserId();
			ViewBag.operation = "Register";
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Register(RegisterViewModel vm)
		{
			ViewBag.operation = "Register";
			try
			{
				if (ModelState.IsValid)
				{



					var found = await userManager.FindByEmailAsync(vm.Email);
					if (found is not null) // If the email exists, show an error
					{
						if (await userManager.IsEmailConfirmedAsync(found))
						{
							ModelState.AddModelError("", "This email is already registered.");
						}
						else
						{
							ModelState.AddModelError("", "This email is already registered but pending confirmation. Please check your inbox.");
						}
						return View(vm);
					}
					if(vm.Password==null)
					{
						ModelState.AddModelError("", "You have to enter a password");
						return View(vm);
					}


					var user = await _userService.AddUser(vm);
					var result = await userManager.CreateAsync(user, vm.Password);
					if (result.Succeeded)
					{

						var Token = await userManager.GenerateEmailConfirmationTokenAsync(user);
						var confirmationLink = Url.ActionLink("ConfirmEmail", "Account", new { userId = user.Id, token = Token }, Request.Scheme);
						var email = new Email2()
						{
							To = user.Email,
							Subject = "Confirm Email",
							Body = confirmationLink
						};
						_emailSettings.SendEmail(email);
						return RedirectToAction(nameof(CheckYourInboxConfirmEmail));

					}
					else
					{
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
					}
				}
				return View(vm);
			}
			catch
			{
				return View(vm);
			}
		}
		//[HttpPost]
		//public async Task<ActionResult> Register(RegisterViewModel vm)
		//      {
		//	try
		//	{
		//              if(ModelState.IsValid)
		//              {
		//                  var user = await _userService.AddUser(vm);
		//                 var result= await userManager.CreateAsync(user,vm.Password);
		//                  if (result.Succeeded)
		//                  {
		//                      await _userService.AddRole(user, BookingRole.user);
		//                      await signInManager.SignInAsync(user, false);
		//                      return RedirectToAction("Index", "Home");

		//                  }
		//                  else
		//                  {
		//                      foreach (var error in result.Errors)
		//                      {
		//                          ModelState.AddModelError("", error.Description);
		//                      }
		//                  }
		//              }
		//              return View(vm);
		//	}
		//	catch
		//	{
		//		return View(vm);
		//	}
		//}

		// GET: AccounttController/Create
		[AllowAnonymous]
		public IActionResult CheckYourInboxConfirmEmail()
		{
			return View();
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			if (userId == null || token == null)
			{
				return BadRequest("Invalid email confirmation request.");
			}

			var user = await userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound("User not found.");
			}

			var result = await userManager.ConfirmEmailAsync(user, token);
			if (result.Succeeded)
			{
				return RedirectToAction("EmailConfirmed");
				//return RedirectToAction(nameof(Login));

			}
			else
			{
				return BadRequest("Email confirmation failed.");
			}
		}
		[AllowAnonymous]
		public IActionResult EmailConfirmed()
		{
			return View();
		}
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Login()
        {
			ViewBag.operation = "Login";
            return View(nameof(Register));
        }

		// POST: AccounttController/Create
		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Login(RegisterViewModel vm)
		{
			try
			{
				
					var user = (await userManager.FindByEmailAsync(vm.Usernameoremail)) ?? await userManager.FindByNameAsync(vm.Usernameoremail);

					if (user is not null)
					{
						if (!await userManager.IsEmailConfirmedAsync(user))
						{
						ModelState.Clear();

						ViewBag.confirmemail = true;
						ViewBag.invalidecomb = false;
						ModelState.AddModelError("", "You must confirm your email before logging in.");
							return View("register");
						}

						if (await userManager.CheckPasswordAsync(user, vm.loginPassword))
						{
							await _userService.AddRole(user, BookingRole.user);
							await signInManager.SignInAsync(user, vm.rememberme??false);
							return RedirectToAction("Index", "Home");
						}

					}
				ViewBag.confirmemail = false;
				ViewBag.invalidecomb = true;
				ModelState.Clear();
				ModelState.AddModelError(" ", "incorrect username/password combination");


				return View("Register", vm);
			}
			catch
			{
				return View("Register", vm);
			}
		}
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}
		[HttpGet]
		[Authorize(Roles="ADMIN")]
		public async Task<ActionResult> GiveRole()
		{
			
			return View(userManager.Users.ToList());
		}
		[HttpGet]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult> MakeAdmin(string id)
		{
			var user = await userManager.FindByIdAsync(id);
			var result=await userManager.AddToRoleAsync(user, "ADMIN");
			if (result.Succeeded)
			{
				return RedirectToAction(nameof(GiveRole));
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return RedirectToAction(nameof(GiveRole));
		}
		[Authorize(Roles = "ADMIN")]
		public async Task<IActionResult> RemoveAdmin(string id)
		{
			var user = await userManager.FindByIdAsync(id);
			var result = await userManager.RemoveFromRoleAsync(user, "ADMIN");
			if (result.Succeeded)
			{
				return RedirectToAction(nameof(GiveRole));
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return RedirectToAction(nameof(GiveRole));
		}
		//[HttpPost]
		//[Authorize(Roles = "ADMIN")]
		//public async Task<ActionResult> GiveRole(string userId)
		//{
		//	await signInManager.SignOutAsync();
		//	return RedirectToAction("Login");
		//}


		// GET: AccounttController/Edit/5
		[HttpGet]
        [Authorize]
		public async Task<ActionResult> EditAccount()
        {
			var id = User.FindFirstValue(ClaimTypes.Email);

		   var user= await userManager.FindByEmailAsync(id);
            RegisterViewModel vm = new()
            {
                Email = user.Email,
                //ConfirmEmail = user.Email,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
            };
            ViewBag.ProfilePicture = user.ProfilePicture;
            return View(vm);
        }
		[HttpPost]
        [Authorize]
		public async Task<ActionResult> EditAccount(RegisterViewModel vm)
		{
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByNameAsync(User.Identity?.Name);
                    user.Email = vm.Email;
                    //user.ConfirmEmail = vm.Email,
                    user.DateOfBirth = vm.DateOfBirth;
                    user.FirstName = vm.FirstName;
                    user.LastName = vm.LastName;
                    user.PhoneNumber = vm.PhoneNumber;
                    user.ProfilePicture = vm.ProfilePicture is not null ? vm.ProfilePicture.Save(env) : user.ProfilePicture;
                    await userManager.UpdateAsync(user);
                    return RedirectToAction("index", "home");
                }

                else
                {
                    return View(vm);
                }
            }
            catch
            {
				return View(vm);
			}
		}

		[HttpGet]
		[AllowAnonymous]

		public IActionResult ForgetPassword()
		{
			return View();
		}


		[HttpPost]
		[AllowAnonymous]

		public async Task<IActionResult> SendEmail(ForgetPasswordViewModel vm)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(vm.Email); //hat el user bt3 el email da
				if (user is not null)
				{
					var Token = await userManager.GeneratePasswordResetTokenAsync(user);
					var ResetPasswordLink = Url.Action("ResetPassword", "Account", new { email = user.Email, token = Token }, Request.Scheme); //Account/ResetPassword/userEmail  ,, Request.Scheme: protocol+host https://localhost5012

					var email = new Email2()
					{
						Subject = "Reset Password",
						To = user.Email,
						Body = ResetPasswordLink
					};
					_emailSettings.SendEmail(email);
					return RedirectToAction(nameof(CheckYourInbox));
				}
				ModelState.AddModelError("", "Email is Invalid");
			}
			return View("ForgetPassword",vm);
		}


		[HttpGet]
		[AllowAnonymous]
		public IActionResult CheckYourInbox()
		{
			return View();
		}

		[AllowAnonymous]


		public IActionResult ResetPassword(string email, string token)
		{
			TempData["email"] = email;
			TempData["token"] = token;
			return View();
		}

		[AllowAnonymous]

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel vm)
		{
			if (ModelState.IsValid)
			{
				string email = TempData["email"] as string;
				string token = TempData["token"] as string;
				var user = await userManager.FindByEmailAsync(email);
				var result = await userManager.ResetPasswordAsync(user, token, vm.NewPassword);

				if (result.Succeeded)
				{
					return RedirectToAction(nameof(Login));
				}
				foreach (var error in result.Errors)
					ModelState.AddModelError("", error.Description);
			}
			return View(vm);
		}
	




		[AllowAnonymous]
		public IActionResult ExternalLogin(string provider, string returnUrl = null)
		{
			// Request a redirect to the external login provider
			var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl, provider = provider });
			var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
			properties.Items["LoginProvider"] = provider;
			return Challenge(properties, provider);
		}
		[AllowAnonymous]
		public async Task<IActionResult> ExternalLoginCallback(string returnurl = null, string provider = "Google", string remoteError = null)
		{
			if (remoteError != null)
			{
				// Handle remote error
				return RedirectToAction("Login");
			}
			//var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//if (!authenticateResult.Succeeded)
			//{
			//	// Handle authentication failure
			//	return RedirectToAction("Login");
			//}
			//var provider = authenticateResult.Properties.Items["LoginProvider"];
			var externalAuthenticateResult = await HttpContext.AuthenticateAsync(provider);
			if (!externalAuthenticateResult.Succeeded)
			{
				// Handle authentication failure
				return RedirectToAction("Login");
			}

			//var claimsIdentity = new ClaimsIdentity(authenticateResult.Principal.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
			//await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
			var name = externalAuthenticateResult.Principal.FindFirstValue(ClaimTypes.Name);
			var email = externalAuthenticateResult.Principal.FindFirstValue(ClaimTypes.Email);
			var existinguser = (await userManager.FindByEmailAsync(email));
			if (string.IsNullOrEmpty(email))
			{
				// Handle missing email claim
				return RedirectToAction("Login", new { error = "Email claim not found" });
			}

			if (existinguser is not null)
			{
				existinguser.EmailConfirmed = true;
				await signInManager.SignInAsync(existinguser, false);
			}
			else
			{
				AppUser user = new();
				user.Email = email;
                user.UserName = Regex.Replace(name, "[^a-zA-Z0-9]", "");
				user.FirstName = name;
				user.LastName = name;
                user.CreationDate = DateTime.Now;
				user.EmailConfirmed = true;
				var Result=await userManager.CreateAsync(user);
				if(!Result.Succeeded)
				{
					foreach (var error in Result.Errors)
						ModelState.AddModelError("", error.Description);
					return RedirectToAction("Login");
				}
				
				await signInManager.SignInAsync(user, false);
			}
			return RedirectToAction("Index", "Home");

		}
	}
}
