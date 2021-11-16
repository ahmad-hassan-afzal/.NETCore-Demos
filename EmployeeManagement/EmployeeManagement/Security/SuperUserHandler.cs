using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagement.Security
{
    public class SuperUserHandler :
        AuthorizationHandler<ManageAdminAuthorizationPolicyRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminAuthorizationPolicyRequirements requirement)
        {
            var authFilter = context.Resource as AuthorizationFilterContext;
            if(authFilter == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole("Super User"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
