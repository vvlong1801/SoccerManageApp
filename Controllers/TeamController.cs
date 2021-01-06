using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    [Authorize(Roles="User,Admin")]
    public class TeamController:Controller
    {
        private readonly IDataRepo _repo;
        public TeamController(IDataRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> ListTeams()
        {
            var teams=await _repo.GetAllTeamsAsync(); 
            return View(teams);
        }

        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(Team model)
        {
            if(!ModelState.IsValid)
            {
                return View("Error");
            }
            var result=await _repo.CreateTeamAsync(model);
            if(result >0)
            {
                return RedirectToAction("ListTeams");
            }
           return View(model);

        }
        public async Task<IActionResult> EditTeam(int teamId)
        {
            ViewBag.teamId=teamId;
            var team=await _repo.GetTeamByIdAsync(teamId);
            return View(team);
        }
        [HttpPost]
        public async Task<IActionResult> EditTeam(Team model,int teamId)
        {
            var team=await _repo.UpdateTeamAsync(model,teamId);
            return RedirectToAction("ListTeams");
 
        }
    }
}