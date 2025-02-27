﻿using HomeBookkeeping.Web.Models;
using HomeBookkeeping.Web.Models.HomeBookkeeping;
using HomeBookkeeping.Web.Models.Paging;
using HomeBookkeeping.Web.Models.ViewModels;
using HomeBookkeeping.Web.Services;
using HomeBookkeeping.Web.Services.Interfaces.IHomeBookkeepingService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HomeBookkeeping.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)=> _userService = userService;


        [HttpGet]
        public async Task <IActionResult> UserIndex(int page = 1)
        {
            UserVM userVM = new();
            var respons = await _userService.GetUsersAsync<ResponseBase>(new PagingParameters() { PageNumber = page });
            if (respons != null)
            {
                userVM.Users = JsonConvert.DeserializeObject<List<UserDTOBase>>(Convert.ToString(respons.Result));
                userVM.Paging = respons.PagedList;
            }
            return View(userVM);
        }


        [HttpGet]
        public IActionResult UserCreate()=> View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreate(UserDTOBase model)
        {
            if (ModelState.IsValid)
            {
                var respons = await _userService.CreateUserAsync<ResponseBase>(model);
                if (respons != null)
                    return RedirectToAction(nameof(UserIndex));
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UserEdit(int userId)
        {
            var respons = await _userService.GetByIdUserAsync<ResponseBase>(userId);
            if (respons != null)
            {
                UserDTOBase? model = JsonConvert.DeserializeObject<UserDTOBase>(Convert.ToString(respons.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(UserDTOBase model)
        {
            if (ModelState.IsValid)
            {
                var respons = await _userService.UpdateUserAsync<ResponseBase>(model);
                if (respons != null)
                    return RedirectToAction(nameof(UserIndex));
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UserDelete(int userId)
        {          
            var respons = await _userService.GetByIdUserAsync<ResponseBase>(userId);
            if (respons != null)
            {
                UserDTOBase? model = JsonConvert.DeserializeObject<UserDTOBase>(Convert.ToString(respons.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDelete(UserDTOBase model)
        {
            if (ModelState.IsValid)
            {
                var respons = await _userService.DeleteUserAsync<ResponseBase>(model.UserId);
                return RedirectToAction(nameof(UserIndex));
            }
            return View(model);
        }
    }
}
