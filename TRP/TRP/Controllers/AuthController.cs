using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using TRP.DTOs;
using TRP.EF;

namespace TRP.Controllers
{
    public class AuthController : Controller
    {
        TRPEntities database = new TRPEntities();
        public static User Convert(UserDTO ur)
        {
            return new User()
            {
                UserId = ur.UserId,
                UserName = ur.UserName,
                Email = ur.Email,
                Password = ur.Password,
                Role = ur.Role
            };
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new UserDTO());
        }

        [HttpPost]
        public ActionResult Registration(UserDTO ur1)
        {
            if (ModelState.IsValid)
            {
                var ExistingUser = (from i in database.Users
                                    where i.UserName == ur1.UserName
                                    select i).FirstOrDefault();
                if (ExistingUser == null)
                {
                    var user = Convert(ur1);
                    database.Users.Add(user);
                    database.SaveChanges();

                    TempData["Mgs"] = "User created successfully!";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Mgs"] = "This UserName already exists! Please Try another UseraName";
                    return RedirectToAction("Registration");
                }

            }
            return View(ur1);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new UserDTO());
        }

        [HttpPost]
        public ActionResult Login(LoginDTO loginData)
        {
            if (ModelState.IsValid)
            {
                // Check if the username and password match an existing user
                var LoginUser = (from i in database.Users
                                 where i.UserName == loginData.UserName && i.Password == loginData.Password
                                 select i).FirstOrDefault();

                if (LoginUser != null) // Successful login
                {
                    Session["user"] = LoginUser;
                    TempData["Mgs"] = "Login successful!";
                    return RedirectToAction("List", "Channel"); // Redirect to the Channel's List action
                }
                else // Invalid credentials
                {
                    TempData["Mgs"] = "Invalid username or password. Please try again.";
                    return RedirectToAction("Login"); // Redirect back to Login to show the error
                }
            }

            // If ModelState is invalid, re-render the view
            return View(loginData);
        }





    }
}

