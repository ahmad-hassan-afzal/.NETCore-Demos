using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagement.Security
{
    public class CanOnlyManageOtherAdmins :
        AuthorizationHandler<ManageAdminAuthorizationPolicyRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminAuthorizationPolicyRequirements requirement)
        {
            var authFilter = context.Resource as AuthorizationFilterContext;
            if(authFilter == null)
            {
                return Task.CompletedTask;
            }
            string logedInId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            string adminBeingEdited = authFilter.HttpContext.Request.Query["userId"];

            if (
                (context.User.IsInRole("Admin") &&
                context.User.HasClaim(c => c.Type == "Edit Role" && c.Value == "true") &&
                adminBeingEdited.ToLower() != logedInId.ToLower()) 
                //|| context.User.IsInRole("Super User") // Another Way but not appriciated
                )
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
