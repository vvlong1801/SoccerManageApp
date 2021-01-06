using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoccerManageApp.Models.Admin;

namespace SoccerManageApp.Controllers {
    // [Authorize(Policy="RequireUser")]
    public class AdminController : Controller {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController (UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }
         [Authorize(Roles="Admin")]
        public IActionResult CreateRole () {
            return View ();
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateRole (RoleModel model) {
            if (ModelState.IsValid) {
                IdentityRole role = new IdentityRole () {
                    Name = model.Rolename
                };
                var result = await _roleManager.CreateAsync (role);
                if (result.Succeeded) {
                    return RedirectToAction ("ListRoles");
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError ("", error.Description);
                }
                return View (model);
            }
            return View (model);
        }
        public IActionResult ListRoles () {
            var roles = _roleManager.Roles.ToList ();
            return View (roles);
        }
        public async Task<IActionResult> EditRole (string roleId) {
            ViewBag.roleId = roleId;
            var role = await _roleManager.FindByIdAsync (roleId);
            if (role == null) {
                ViewBag.ErrorMessage = $"Role with id={roleId} not found";
                return View ("NotFound");
            }
            var roleEdit = new EditRoleModel () {
                RoleId = role.Id,
                RoleName = role.Name
            };
            foreach (var user in _userManager.Users.ToList ()) {

                if (await _userManager.IsInRoleAsync (user, role.Name)) {
                    roleEdit.Users.Add (user.UserName);
                }

            }
            return View (roleEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole (List<UserInRoleModel> model, string roleId) {
            var role = await _roleManager.FindByIdAsync (roleId);
            IdentityResult result = null;;
            if (role == null) {
                ViewBag.ErrorMessage = $"Role with id={roleId} not found";
                return View ("NotFound");
            }
            for (int i = 0; i < model.Count; i++) {
                var user = await _userManager.FindByIdAsync (model[i].UserId);
                if (user == null) {
                    ViewBag.ErrorMessage = $"User with id={model[i].UserId} not found";
                    return View ("NotFound");
                }
                if (!await _userManager.IsInRoleAsync (user, role.Name) && model[i].IsSelected) {
                    result = await _userManager.AddToRoleAsync (user, role.Name);
                } else if (await _userManager.IsInRoleAsync (user, role.Name) && !model[i].IsSelected) {
                    result = await _userManager.RemoveFromRoleAsync (user, role.Name);
                } else {
                    continue;
                }
                if (result.Succeeded) {
                    if (i < model.Count - 1) {
                        continue;
                    }
                    return RedirectToAction ("ListRoles");
                }
            }

            return RedirectToAction ("EditRole", new { roleId = roleId });
        }
        public IActionResult ListUsers () {
            var users = _userManager.Users.ToList ();
            return View (users);
        }
        public async Task<IActionResult> EditUser (string userId) {
            ViewBag.UserId = userId;
            var user = await _userManager.FindByIdAsync (userId);
            if (user == null) {
                ViewBag.ErrorMessage = $"Role with id={userId} not found";
                return View ("NotFound");
            }
            var roles = await _userManager.GetRolesAsync (user);
            var model = new EditUserModel () {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Roles = roles
            };
            return View (model);

        }
        public async Task<IActionResult> EditUserInRole (string roleId) {
            var role = await _roleManager.FindByIdAsync (roleId);
            if (role == null) {
                ViewBag.ErrorMessage = $"User with id={roleId} not found";
                return View ("NotFound");
            }
            List<UserInRoleModel> models = new List<UserInRoleModel> ();
            foreach (var user in _userManager.Users.ToList ()) {
                UserInRoleModel model = new UserInRoleModel ();
                model.UserId = user.Id;
                model.Username = user.UserName;
                if (await _userManager.IsInRoleAsync (user, role.Name)) {
                    model.IsSelected = true;
                } else {
                    model.IsSelected = false;
                }
                models.Add (model);
            }
            return View (models);

        }

        [HttpPost]
        public async Task<IActionResult> EditUserInRole (List<UserInRoleModel> model, string roleId) {
            var role = await _roleManager.FindByIdAsync (roleId);
            if (role == null) {
                ViewBag.ErrorMessage = $"User with id={roleId} not found";
                return View ("NotFound");
            }
            IdentityResult result = null;
            for (int i = 0; i < model.Count; i++) {
                var user = await _userManager.FindByIdAsync (model[i].UserId);
                if (user == null) {
                    ViewBag.ErrorMessage = $"User with id={model[i].UserId} not found";
                    return View ("NotFound");
                }
                if (model[i].IsSelected && !await _userManager.IsInRoleAsync (user, role.Name)) {
                    result = await _userManager.AddToRoleAsync (user, role.Name);
                } else if (!model[i].IsSelected && await _userManager.IsInRoleAsync (user, role.Name)) {
                    result = await _userManager.RemoveFromRoleAsync (user, role.Name);
                } else {
                    continue;
                }
                if (result.Succeeded) {
                    if (i < model.Count - 1) {
                        continue;
                    } else {
                        return RedirectToAction ("EditRole", new { roleId = roleId });
                    }
                }

            }
            return RedirectToAction ("EditRole", new { roleId = roleId });
        }
        public async Task<IActionResult> EditRoleInUser (string userId) {
            ViewBag.userId = userId;

            var user = await _userManager.FindByIdAsync (userId);
            ViewBag.Username = user.UserName;
            if (user == null) {
                ViewBag.ErrorMessage = $"User with id={userId} not found";
                return View ("NotFound");
            }
            List<RoleInUserModel> models = new List<RoleInUserModel> ();

            foreach (var role in _roleManager.Roles.ToList ()) {
                RoleInUserModel model = new RoleInUserModel () {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync (user, role.Name)) {
                    model.IsSelected = true;
                } else {
                    model.IsSelected = false;
                }
                models.Add (model);

            }
            return View (models);
        }
         [HttpPost]
         public async Task<IActionResult> EditRoleInUser (List<RoleInUserModel> model,string userId) 
         {
             
              var user = await _userManager.FindByIdAsync (userId);
            if (user == null) {
                ViewBag.ErrorMessage = $"User with id={userId} not found";
                return View ("NotFound");
            }
            IdentityResult result=null;
            for(int i=0;i<model.Count;i++)
            {
                var role=await _roleManager.FindByIdAsync(model[i].RoleId);
                if(model[i].IsSelected && !await _userManager.IsInRoleAsync(user,model[i].RoleName))
                {
                    result=await _userManager.AddToRoleAsync(user,model[i].RoleName);
                }
                else if(!model[i].IsSelected && await _userManager.IsInRoleAsync(user,model[i].RoleName))
                {
                    result =await _userManager.RemoveFromRoleAsync(user,model[i].RoleName);
                }
                else
                {
                    continue;
                }
                if(result.Succeeded)
                {
                    if(i<model.Count-1)
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditUser",new {userId=userId});
                    }
                }
            }
           return RedirectToAction("EditUser",new {userId=userId});
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user=await _userManager.FindByIdAsync(userId);
             if (user == null) {
                ViewBag.ErrorMessage = $"User with id={userId} not found";
                return View ("NotFound");
            }
            var result=await _userManager.DeleteAsync(user);
            if(!result.Succeeded)
            {
                 ModelState.AddModelError("","Can't delete user");
            }
           
            return RedirectToAction("ListUsers");


        }
    }
       

}