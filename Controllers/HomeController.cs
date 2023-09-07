using ExpenseTrackerAPI.Constants;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IExpensesService _expensesService;
        public HomeController(IAuthService authService, IExpensesService expensesService)
        {
            _authService = authService;
            _expensesService = expensesService;
        }
        public async Task<ActionResult> Index()
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

        public async Task<ActionResult> Create()
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

        public async Task<ActionResult> Dashboard()
        {
            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");
            if (UserID == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var stats = await _expensesService.Statistics();
                return View(stats);
            }

        }

        public async Task<ActionResult> AddCategory()
        {
            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");
            if (UserID == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = new ViewModel<List<ListCategoryResp>>();
                var categoryList = await _expensesService.ListCategory(UserID);
                viewModel.Data = categoryList;

                return View(viewModel);
            }

        }

        public async Task<ActionResult> AddBudget()
        {
            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");
            if (UserID == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var viewModel = new ViewModel<List<ListBudgetResp>>();
                var listBudget = await _expensesService.ListBudget(UserID);
                var categoryList = await _expensesService.ListCategory(UserID);
                viewModel.Data = listBudget;
                viewModel.Category = categoryList;

                return View(viewModel);
            }
        }

        //public async Task<ActionResult> AddExpenses()
        //{
        //    //get userID from session
        //    var UserID = HttpContext.Session.GetString("ExpenseUserID");
        //    if (UserID == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        var viewModel = new ViewModel<List<ListExpensesResp>>();
        //        var listExpenses = await _expensesService.ListExpenses(UserID);
        //        viewModel.Data = listExpenses;

        //        return View(viewModel);
        //    }
        //}

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

        [HttpPost]
        public async Task<ActionResult> AddCategory(AddCategoryRq req)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };
            var viewModel = new ViewModel<List<ListCategoryResp>>();
            
            //check if request is valid
            if (ModelState.IsValid)
            {               
                //if everything is okay call the Expenses service
                response = await _expensesService.AddCategory(req);                
            }
            else
            {
                //if request is not valid set description 
                response.StatusDescription = "Invalid Request";
            }


            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");

            var categoryList = await _expensesService.ListCategory(UserID);

            viewModel.Data = categoryList;
            viewModel.Response = response;

            return View(viewModel);

        }

        [HttpPost]
        public async Task<ActionResult> AddBudget(AddBudgetsRq req)
        {
            var response = new BaseResponse()
            {
                StatusCode = ErrorCodes.ERROR_CODE,
                StatusDescription = ErrorCodes.ERROR_MSG,
                Success = false
            };
            var viewModel = new ViewModel<List<ListBudgetResp>>();

            //check if request is valid
            if (ModelState.IsValid)
            {
                //if everything is okay call the Expenses service
                response = await _expensesService.AddBudget(req);
            }
            else
            {
                //if request is not valid set description 
                response.StatusDescription = "Invalid Request";
            }

            //get userID from session
            var UserID = HttpContext.Session.GetString("ExpenseUserID");

            var listBudget = await _expensesService.ListBudget(UserID);
            var categoryList = await _expensesService.ListCategory(UserID);
         
            viewModel.Category = categoryList;
            viewModel.Data = listBudget;
            viewModel.Response = response;

            return View(viewModel);

        }

        //[HttpPost]
        //public async Task<ActionResult> AddExpenses(AddExpensesRq req)
        //{
        //    var response = new BaseResponse()
        //    {
        //        StatusCode = ErrorCodes.ERROR_CODE,
        //        StatusDescription = ErrorCodes.ERROR_MSG,
        //        Success = false
        //    };
        //    var viewModel = new ViewModel<List<ListExpensesResp>>();

        //    //check if request is valid
        //    if (ModelState.IsValid)
        //    {
        //        //if everything is okay call the Expenses service
        //        response = await _expensesService.AddExpenses(req);
        //    }
        //    else
        //    {
        //        //if request is not valid set description 
        //        response.StatusDescription = "Invalid Request";
        //    }

        //    //get userID from session
        //    var UserID = HttpContext.Session.GetString("ExpenseUserID");

        //    var listExpenses = await _expensesService.ListExpenses(UserID);

        //    viewModel.Data = listExpenses;
        //    viewModel.Response = response;

        //    return View(viewModel);

        //}
    }
}
