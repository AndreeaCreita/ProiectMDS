using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMDS.Areas.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET /account/register
        [AllowAnonymous]
        public IActionResult Register() => View();
        
    }
}
