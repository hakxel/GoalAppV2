using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using GoalAppV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace GoalAppV2.Areas.Identity
{
    public class IsLoggedUserHandler : AuthorizationHandler<IsLoggedUserRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsLoggedUserHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsLoggedUserRequirement requirement)
        {
            var loggedInUserId = context.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value.ToString();
            var editedUserId = _httpContextAccessor.HttpContext.Request.RouteValues["id"].ToString();


            if (loggedInUserId == editedUserId)
            {
                context.Succeed(requirement);
                return Task.FromResult(0);
            }
            
            context.Fail();
            return Task.FromResult(0);

        }
    }
}
