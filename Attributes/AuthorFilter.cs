using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MVCBookingFinal_YARAB_.Attributes
{
	public class AuthorFilter(ApplicationDbContext _context, UserManager<AppUser> userManager) : ActionFilterAttribute
	{
		
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var request = context.HttpContext.Request;
			if (!context.RouteData.Values.TryGetValue("id", out var idValue) || !int.TryParse(idValue.ToString(), out var id))
			{
				context.Result = new BadRequestObjectResult(new { message = "Invalid ID" });
				return;
			}
			var entityType = context.RouteData.Values["controller"]?.ToString();
			string authorId;
			if (entityType.ToLower() == "Reviews".ToLower())
			{

			 authorId = _context.Reviews.Find(id).UserId;
			}
			else
			{
				authorId = _context.PromoCodes.Find(id).AddingUserID;
			}
			var userid = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user= userManager.FindByIdAsync(userid).GetAwaiter().GetResult();
			if (user == null)
			{
				context.Result = new BadRequestObjectResult(new { message = "user not found" });
				return;
			}
			if (user.Id!=	authorId)
			{
				context.Result = new BadRequestObjectResult(new { message = "only Author is allowed to edit" });
				return;
			}
			base.OnActionExecuting(context);
		}
	}
	public class AuthorAndAdminFilter(ApplicationDbContext _context, UserManager<AppUser> userManager) : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var request = context.HttpContext.Request;
			if (!context.RouteData.Values.TryGetValue("id", out var idValue) || !int.TryParse(idValue.ToString(), out var id))
			{
				context.Result = new BadRequestObjectResult(new { message = "Invalid ID" });
				return;
			}
			var entityType = context.RouteData.Values["controller"]?.ToString();
			string authorId;
			if (entityType.ToLower() == "Reviews".ToLower())
			{
				 authorId = _context.Reviews.Find(id).UserId;
			}
			else if(entityType.ToLower() == "UsedPromoCode".ToLower())
			{
				authorId = _context.UsedPromoCodes.Find(id).UserId;
			}
			else
			{
				authorId = _context.Invoices.Include(i => i.Reservation).ThenInclude(r => r.Reserved).ThenInclude(r => r.Room)
				   .FirstOrDefault(i => i.Id == id).Reservation.Reserved.FirstOrDefault().UserId;
			}
				var userid = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = userManager.FindByIdAsync(userid).GetAwaiter().GetResult();
			if (user == null)
			{
				context.Result = new BadRequestObjectResult(new { message = "user not found" });
				return;
			}
			if (user.Id != authorId && !context.HttpContext.User.IsInRole("ADMIN"))
			{
				context.Result = new BadRequestObjectResult(new { message = "only Author and admin are allowed to edit/delete" });
				return;
			}
			base.OnActionExecuting(context);
		}
	}
}
