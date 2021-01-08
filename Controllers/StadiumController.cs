using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerManage.Data;
using SoccerManageApp.Models.Entities;

namespace SoccerManageApp.Controllers
{
    public class StadiumController:Controller
    {
        private readonly IDataRepo _repo;
        public StadiumController( IDataRepo repo)
        {
            _repo=repo;
        }
        public IActionResult CreateStadium()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStadium(Stadium model)
        {
            if(ModelState.IsValid)
            {
                await _repo.CreateStadiumAsync(model);
            }
            return RedirectToAction("CreateTeam","Team",new {stadiumID=model.StadiumID});
;        }
    }
}