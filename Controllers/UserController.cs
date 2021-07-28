using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studio___Spa_Day.ViewModels;


namespace SpaDay.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Route("user/add")] ///user
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        //[HttpGet]
        [HttpPost]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                if (addUserViewModel.Password == addUserViewModel.VerifyPassword)
                {
                    User newUser = new User
                    {
                        Username = addUserViewModel.Username,
                        Email = addUserViewModel.Email,
                        Password = addUserViewModel.Password,
                        VerifyPassword = addUserViewModel.VerifyPassword
                    };
                    return View("Index", addUserViewModel); //view
                }
                else
                {
                    User newuser = new User
                    {
                        Username = addUserViewModel.Username,
                        Email = addUserViewModel.Email

                    };
                    ViewBag.Error = "Please ensure passwords match";
                    return View("Add", addUserViewModel);
                }
            }
            return View("Add");
            /*
            ViewBag.NewUsername = newUser.Username;
            ViewBag.NewEmail= newUser.Email;
            ViewBag.Error = "Error: Passwords do not match";
            */
        }
            
            

        
    }
}
