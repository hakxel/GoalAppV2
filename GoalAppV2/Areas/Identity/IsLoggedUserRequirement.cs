using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GoalAppV2.Areas.Identity
{
    public class IsLoggedUserRequirement : IAuthorizationRequirement
    {
        //protected string LoggedUserid { get; set; }

        //public IsLoggedUserRequirement(string userId)
        //{
        //    LoggedUserid = userId;
        //}
    }
}
