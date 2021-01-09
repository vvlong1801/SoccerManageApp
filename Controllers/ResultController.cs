using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    public class ResultController:Controller
    {
        private readonly IDataRepo _repo;
        public ResultController(IDataRepo repo)
        {
            _repo=repo;
        }
        public IActionResult CreateResult(int matchId)
        {
            ViewBag.matchId=matchId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateResult(Result result,int matchId)
        {
            await _repo.CreateResultAsync(result,matchId);
            return RedirectToAction("ListMatches","Match");
        }
        public async Task<IActionResult> Ranking()
        {
            var rank=await _repo.GetRankAsync();
            return View(rank);
        }
    }
}