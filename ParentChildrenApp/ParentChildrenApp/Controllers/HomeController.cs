using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParentChildrenApp.Models;
using ParentChildrenApp.Models.DTO;
using ParentChildrenApp.Repository;

namespace ParentChildrenApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IParentRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IParentRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(ParentLoginModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction("Error"));
            }

            var validUser = _userRepository.GetUser(userModel.UserName);

            if (validUser != null)
            {
                    HttpContext.Session.SetString("userId", validUser.Id.ToString());
                    HttpContext.Session.SetString("username", validUser.UserName);
                    HttpContext.Session.SetString("usermail", validUser.EmailId);

                    return RedirectToAction("Landing");

            }
            else
            {
                return (RedirectToAction("LoginError"));
            }
        }

        [Route("landing")]
        [HttpGet]
        public IActionResult Landing()
        {
            string parentId = HttpContext.Session.GetString("userId");

            if (parentId == null)
            {
                return (RedirectToAction("Index"));
            }

            else 
            {

                return RedirectToAction(actionName: "Index", controllerName: "Child");
            }
        }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            TempData["Action"] = "Edit";
            int parentId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            ParentDTO parent= _userRepository.GetUserByID(parentId);
            ParentRegistrationModel parentmdl=new ParentRegistrationModel()
            {
                   Username = parent.UserName,
                   Gender   = parent.Gender,
                   FirstName= parent.FirstName,
                   LastName = parent.LastName,
                   MobNo    = parent.MobNo,
                   Email    = parent.EmailId,
                   EmiratesID =parent.EmiratesID,
                   Password= parent.Password
             };

            return View("SignUp", parentmdl);
        }

        [AllowAnonymous]
        [Route("signup")]
        [HttpPost]
        public IActionResult RegisterUser(ParentRegistrationModel register)
        {
            if (!ModelState.IsValid)
                return View("SignUp");
            bool result = _userRepository.CreateUser(register);
            if (!result)
            {
                ViewBag.Message = "An error occured while creating user.Try with another username!";
                return View("SignUp");
            }
            TempData["message"] = "User has been registered successfully!Please Login to continue!";
            return RedirectToAction("Index");
        }

        [Route("edituser")]
        [HttpPost]
        public IActionResult UpdateUser(ParentRegistrationModel parent)
        {
            TempData["Action"] = "Edit";
            ModelState.Remove("Gender");
            ModelState.Remove("ConfirmPassword");
            if (!ModelState.IsValid)
                return View("SignUp");
            int parentId = Convert.ToInt32(HttpContext.Session.GetString("userId"));
            ParentDTO parentDTO = new ParentDTO()
            {
                Id= parentId,
                UserName = parent.Username,
                Gender = parent.Gender,
                FirstName = parent.FirstName,
                LastName = parent.LastName,
                MobNo = parent.MobNo,
                EmailId = parent.Email,
                EmiratesID = parent.EmiratesID,
                Password = parent.Password
            };
            bool result = _userRepository.UpdateUser(parentDTO);
            if (!result)
            {
                ViewBag.Message = "An error occured while updating user!";
                RedirectToAction("EditProfile");
            }
            ViewBag.Message = "User has been updated successfully!";
            return View("SignUp");
        }

      
        public IActionResult LoginError()
        {
            ViewBag.Message = "User Authentication failed!";
            return View();
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
