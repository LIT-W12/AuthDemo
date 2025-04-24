using AuthDemo.Data;
using AuthDemo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.WebSockets;

namespace AuthDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=AuthDemo;Integrated Security=true;Trust Server Certificate=true;";
        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            if (User.Identity.IsAuthenticated)
            {
                vm.Message = "Welcome logged in user!!";
                var repo = new UserRepository(_connectionString);
                var user = repo.GetByEmail(User.Identity.Name);
                vm.User = user;
            }
            else
            {
                vm.Message = "Welcome guest!!!";
            }
            return View(vm);
        }

        [Authorize]
        public IActionResult Secret()
        {
            var repo = new UserRepository(_connectionString);
            var user = repo.GetByEmail(User.Identity.Name);
            return View(new SecretViewModel
            {
                User = user
            });
        }

    }


}

/*Create an application where users can post simple ads for others to see.
 An ad consists of a Title, Phone number and description. To create an ad, a user must be logged in. 

Here are the basic pages you'll need:

Home Page - on this page, display all the ads in the system. If the current user is logged in,
and some of the ads belong to them, those ads should also have a delete button that gives that user 
the ability to delete that ad.

New Ad - (Put a link to this page up in the nav bar using the layout page) - When this page is accessed, 
if the current user isn't logged in, they should be redirected to a login page. 
If they are logged in however, they should be shown a form where they can create a new ad. 

My Account (this should be shown in the nav bar using the layout as well - however, 
this link should only be shown if the current user is logged in) - 
on this page, display all the ads that the current user has created as well as a delete button for each one.

Finally, in the nav bar on top, if the current user is logged in, display a Logout link. 
If they're NOT logged in, display a link called Login.
*/
