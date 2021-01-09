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

        public IActionResult CreateTeam(int stadiumID)
        {
            ViewBag.stdId=stadiumID;
            ViewBag.teamId=stadiumID;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(Team model,int stadiumID)
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
        public async Task<IActionResult> EditTeam(string teamName)
        {
            ViewBag.teamName=teamName;
            var team=await _repo.GetTeamByNameAsync(teamName);
            return View(team);
        }
        [HttpPost]
        public async Task<IActionResult> EditTeam(Team model,string teamName)
        {
            var team=await _repo.UpdateTeamAsync(model,teamName);
            return RedirectToAction("ListTeams");
 
        }
        public async Task<IActionResult> Details (string teamName)
        {
            var team_details=await _repo.GetTeamDetailsByNameAsync(teamName);
            var team= await _repo.GetTeamByNameAsync(teamName);
            ViewBag.teamName=team.TeamName;
            ViewData["TeamImage"]=team.TeamImage;
            return View(team_details);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTeam(string teamName)
        {
            await _repo.DeleteTeamAsync(teamName);
            return RedirectToAction("ListTeams");
        }
    }
}