using ExpenseTrackerAPI.Constants;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;
        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }
        public ActionResult Index()
        {
            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");
            if (UserID == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginRq req)
        {
            //create an instant of the loginResp class and set it to a default value
            var response = new LoginResp()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false,
                UserId = null,
                USerName = null
            };
            //check if login request is valid
            if (ModelState.IsValid)
            {
                //if login request is valid then call login service
                response = await _authService.AuthenticateUser(req);

                //check if login is successful then redirect to dashboard
                if(response.StatusCode == ErrorCodes.SUCCESS_CODE && response.Success)
                {
                    HttpContext.Session.SetString("ExpenseUserID", response.UserId);
                    HttpContext.Session.SetString("ExpenseUserName", response.USerName);
                    return RedirectToAction("Dashboard");
                }
            }

            return View(response);
        }

        public ActionResult Create()
        {
            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");
            if(UserID == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Dashboard");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Create(RegisterUserRq req)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };
            //check if request is valid
            if (ModelState.IsValid)
            {
                //check if password does not match
                if(req.Password != req.ConfirmPassword)
                {
                    //if does not match set status description and return error
                    response.StatusDescription = "Password does not match";
                    return View(response);
                }

                //if everything is okay call the registration service
                response = await _authService.RegisterUser(req);
            }
            else
            {
                //if request is not valid set description 
                response.StatusDescription = "Invalid Request";
            }
            return View(response);
        }

        public ActionResult Dashboard()
        {
            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");
            if (UserID == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }


    }
}
