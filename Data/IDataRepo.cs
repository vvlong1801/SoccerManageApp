using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoccerManageApp.Dtos;
using SoccerManageApp.Models.Entities;

namespace SoccerManage.Data
{
    public interface IDataRepo
    {
        //Team Data
        Task<Team> GetTeamByNameAsync(string name);
        Task<IEnumerable<TeamDetails>> GetTeamByName_withSearchAsync(string name,string search);
        Task<int> CreateTeamAsync(Team team);
        Task<IEnumerable<TeamDtos>> GetAllTeamsAsync();
        Task<Team> UpdateTeamAsync(Team team,string teamName);
         Task<IEnumerable<TeamDetails>> GetTeamDetailsByNameAsync(string teamName);
        
      
                //Player Data
        Player GetPlayerById(int? id);
        Task <int> CreatePlayerAsync(Player player,string teamName);
        void UpdatePlayer(Player player);
        //Stadium data
        Stadium GetStadiumByName(string name);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        Task<Player> GetPlayerByIdAsync(int? id);
        Task CreateStadiumAsync(Stadium model);
        void GetAllPlayers();
        //match data
        Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync();
        Task<int> CreateMatch(Match match);
        bool checkExist(int homeId,int awayId);
        Task<MatchInfoDtos> GetMatchById(int matchId);
        Task<IEnumerable<MatchInfoDtos>> GetMatchByDatetimeAsync(DateTime date);

        //result data
        Task<int> CreateResult(Result result);
        //score data
        Task<IEnumerable<Score>> GetScores(int matchId);
        Task<int> CreateScore(Score score);

    }
}