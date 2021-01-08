using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    public class PlayerController:Controller
    {
        private readonly IDataRepo _repo;
        public PlayerController(IDataRepo repo)
        {
            _repo=repo;
        }
        public IActionResult CreatePlayer(string teamName)
        {
            //var team=await _repo.GetTeamByNameAsync(teamName);
            ViewBag.teamName=teamName;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlayer(Player model,string teamName)
        {
            await _repo.CreatePlayerAsync(model,teamName);
            return RedirectToAction("Details","Team",new {teamName=teamName});
        }
        public async Task<IActionResult> EditPlayer(int playerId,bool success=false)
        {
            var player=await _repo.GetPlayerByIdAsync(playerId);
            ViewBag.Success=success;
            return View(player);
        }
        [HttpPost]
        public async Task<IActionResult> EditPlayer(Player model,int playerId)
        {
            await _repo.UpdatePlayerAsync(model,playerId);
            return RedirectToAction("EditPlayer",new{playerId=playerId,success=true});
        }
        [HttpPost]
        public async Task<IActionResult> DeletePlayer(int playerId)
        {
            var player=await _repo.GetPlayerByIdAsync(playerId);
            await _repo.DeletePlayerAsync(playerId);
            return RedirectToAction("Details","Team",new {teamName=player.TeamName});
        }



    }
}