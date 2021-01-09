using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using SoccerManageApp.Dtos;
using SoccerManageApp.Models;
using SoccerManageApp.Models.Entities;

namespace SoccerManage.Data {
    public class DataRepo : IDataRepo {
        private readonly AppDbContext _context;
        public DataRepo (AppDbContext context) {
            _context = context;
        }

        public async Task<int> CreatePlayerAsync (Player player,string teamName) {
            NpgsqlConnection conn = null;
            int row;
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {

                var cmdStr = "Insert into player values" +
                    " (@playerId,@firstname,@lastname,@kit,@position,@countryimage,@country,@teamname);";

                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    cmd.Parameters.Add ("@playerId", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.PlayerID;
                    cmd.Parameters.Add ("@firstname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.FirstName;
                    cmd.Parameters.Add ("@lastname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.LastName;
                    cmd.Parameters.Add ("@kit", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.Kit;
                    cmd.Parameters.Add ("@position", NpgsqlTypes.NpgsqlDbType.Text).Value = player.Position;
                    cmd.Parameters.Add ("@kit", NpgsqlTypes.NpgsqlDbType.Integer).Value = player.Kit;
                    cmd.Parameters.Add ("@country", NpgsqlTypes.NpgsqlDbType.Text).Value = player.Country;
                    cmd.Parameters.Add ("@countryimage", NpgsqlTypes.NpgsqlDbType.Text).Value = player.CountryImage;
                    cmd.Parameters.Add ("@teamname", NpgsqlTypes.NpgsqlDbType.Text).Value = player.TeamName;
                    row = await cmd.ExecuteNonQueryAsync ();

                }

            }
            return row;
            //    _context.Players.Add(player);
            //     _context.SaveChanges();
        }

        public bool CheckExist (string homeName, string awayName) {
            var check = _context.Matches.Any (m => m.HomeTeamName == homeName && m.AwayTeamName== awayName);
            return check;
        }

        public async Task<int> CreateMatchAsync (Match match) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into match values " +
                    "(@matchID,@datetime,@attendance,@stadiumid,@awayname,@homename);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchID", match.MatchID);
                    cmd.Parameters.AddWithValue ("@datetime", match.Datetime);
                    cmd.Parameters.AddWithValue ("@attendance", match.Attendance);
                    cmd.Parameters.AddWithValue ("@homename", match.HomeTeamName);
                    cmd.Parameters.AddWithValue ("@awayname", match.AwayTeamName);
                    cmd.Parameters.AddWithValue ("@stadiumid", match.StadiumID);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();
                }
            }
            return rows;

            /* _context.Matches.Add(match);
             _context.SaveChanges();*/
        }

        public async Task<int> CreateResultAsync (Result result,int matchId) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into result values(@matchid,@homeres,@awayres);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", result.MatchID);
                    cmd.Parameters.AddWithValue ("@homeres", result.Homeres);
                    cmd.Parameters.AddWithValue ("@awayres", result.Awayres);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();

                }
            }
            return rows;

        }

        public async Task<int> CreateScore (Score score) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into score values(@scoreid,@matchid,@playerid,@teamname);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@scoreid", score.ScoreID);
                    cmd.Parameters.AddWithValue ("@matchid", score.MatchID);
                    cmd.Parameters.AddWithValue ("@playerid", score.PlayerID);
                    cmd.Parameters.AddWithValue ("@teamname", score.TeamName);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();

                }
            }
            return rows;

        }

        public async Task<int> CreateTeamAsync (Team team) {
            var connStr = DbConnection.connectionString;
            int rows;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Insert into team values(@teamname,@teamimage,@stadiumid);";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {

                    cmd.Parameters.AddWithValue ("@teamname", team.TeamName);
                    cmd.Parameters.AddWithValue ("@teamimage", team.TeamImage);
                    cmd.Parameters.AddWithValue ("@stadiumid", team.StadiumID);

                    await conn.OpenAsync ();
                    rows = await cmd.ExecuteNonQueryAsync ();

                }
            }
            return rows;
        }

        public async Task<IEnumerable<MatchInfoDtos>> GetAllMatchAsync () {

            List<MatchInfoDtos> matches = new List<MatchInfoDtos> ();
            var connStr = DbConnection.connectionString;
            using (NpgsqlConnection conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "select * from match_info_dto";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                        var match = new MatchInfoDtos () {
                        MatchID = Convert.ToInt32(rd["match_id"]),
                        Datetime = rd.GetDateTime ("datetime"),
                        Attendance = rd.GetInt32 ("attendance"),
                        HomeName = rd.GetString ("hometeam_name"),
                        AwayName = rd.GetString ("awayteam_name"),
                        StadiumName = rd.GetString ("stadium_name"),
                        HomeRes = rd.GetInt32 ("home_res"),
                        AwayRes = rd.GetInt32 ("away_res"),
                        HomeImage = rd.GetString ("home_image"),
                        AwayImage = rd.GetString ("away_image")

                            };
                            matches.Add (match);
                        }
                    }

                }
            }

            return matches;
        }

        public void GetAllPlayers () {
            NpgsqlConnection conn = null;
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                conn.Open ();
                var cmdStr = "Select * from player";
                NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn);
                using (NpgsqlDataReader rd = cmd.ExecuteReader ()) {
                    while (rd.Read ()) {
                        Console.WriteLine ("{0},{1},{2}", rd[0], rd[1], rd[2]);
                    }
                }

            }
        }

        public async Task<IEnumerable<TeamDtos>> GetAllTeamsAsync () {
            NpgsqlConnection conn = null;
            List<TeamDtos> list = new List<TeamDtos> ();
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "Select * from team_dto";
                using (NpgsqlCommand command = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync ()) {
                        while (reader.Read ()) {
                        var team = new TeamDtos () {

                       
                        TeamName = reader["team_name"].ToString(),
                        TeamImage = reader["team_image"].ToString (),
                         StadiumID = Convert.ToInt32(reader["stadium_id"]),
                        StadiumName = reader["stadium_name"].ToString ()

                            };
                            list.Add (team);
                        }
                    }
                }

            }
            return list;

        }

        public async Task<IEnumerable<MatchInfoDtos>> GetMatchByDatetimeAsync (DateTime date) {
            var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from match_info_dto4 where \"Datetime\"=@datetime;";
            var matches = new List<MatchInfoDtos> ();
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    await conn.OpenAsync ();
                    cmd.Parameters.AddWithValue ("@datetime", date);
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                        var match = new MatchInfoDtos () {
                        MatchID = rd.GetInt32 (1),
                        Datetime = rd.GetDateTime (2),
                        Attendance = rd.GetInt32 (3),
                        HomeName = rd.GetString (11),
                        AwayName = rd.GetString (13),
                        StadiumName = rd.GetString (8),
                        HomeRes = rd.GetInt32 (6),
                        AwayRes = rd.GetInt32 (7),
                        HomeImage = rd.GetString (12),
                        AwayImage = rd.GetString (14)

                            };
                            matches.Add (match);
                        }
                    }

                }
            }
            return matches;
        }

        public async Task<MatchInfoDtos> GetMatchByIdAsync (int matchId) {
            MatchInfoDtos match = new MatchInfoDtos ();
            NpgsqlConnection conn = null;
            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                var cmdStr = "select * from match_info_dto4 where \"MatchID\"=@matchid;";
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@matchid", matchId);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {

                        while (rd.Read ()) {

                            match.HomeName = rd.GetString (11);
                            match.AwayName = rd.GetString (13);
                            match.HomeImage = rd.GetString (12);
                            match.AwayImage = rd.GetString (14);

                        };
                    }
                }

            }
            return match;

        }

        public Player GetPlayerById (int? id) {
            return _context.Players
                .Include (t => t.Team).AsNoTracking ()
                .FirstOrDefault (p => p.PlayerID == id);
        }

        public async Task<Player> GetPlayerByIdAsync (int? id) {
            var player = await _context.Players.FirstOrDefaultAsync (p => p.PlayerID == id);
            return player;
        }

        public async Task<IEnumerable<Score>> GetScores (int matchId) {
            var scores = await _context.Scores.Where (m => m.MatchID == matchId)
                .Include (p => p.Player)
                .Include (t => t.Team)
                .AsNoTracking ().ToListAsync ();
            return scores;
        }

        public Stadium GetStadiumByName (string name) {
            var stadium = _context.Stadiums
                .Include (t => t.Team).AsNoTracking ()
                .FirstOrDefault (f => f.StadiumName == name);
            return stadium;
        }

        // public async Task<Team> GetTeamAsync (int? id) {
        //     return await _context.Teams.FirstOrDefaultAsync (t => t.TeamID == id);
        // }

        public async Task<IEnumerable<TeamDetails>> GetTeamByName_withSearchAsync (string name, string search) {
            var connStr = DbConnection.connectionString;
            var cmdStr = "Select * from getteambynamewithsearch(@name,@search);";
            List<TeamDetails> teams = null;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", name);
                    cmd.Parameters.AddWithValue ("@search", search);
                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            var team = new TeamDetails ();
                            team.TeamName = rd["TeamName"].ToString ();
                            team.TeamImage = rd["TeamImage"].ToString ();
                            team.FirstName = rd["FirstName"].ToString ();
                            team.LastName = rd["LastName"].ToString ();
                            team.Position = rd["position"].ToString ();
                            team.CountryImage = rd["CountryImage"].ToString ();
                            teams.Add (team);
                        }
                    }

                }
            }
            return teams;
        }

        public bool SaveChanges () {
            return _context.SaveChanges () > 0;
        }

        public async Task<bool> SaveChangesAsync () {
            return await _context.SaveChangesAsync () > 0;
        }

        public async Task UpdatePlayerAsync (Player model,int playerId) {
             NpgsqlConnection conn = null;
            var cmdStr = "update player set kit = @kit, position = @position , country = @country, country_image = @countryimage where player_id=@playerId;";

            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
        
                    cmd.Parameters.AddWithValue ("@kit", model.Kit);
                    cmd.Parameters.AddWithValue ("@position", model.Position);
                    cmd.Parameters.AddWithValue("@countryimage",model.CountryImage);
                    cmd.Parameters.AddWithValue("@country",model.Country);
                    cmd.Parameters.AddWithValue("@playerId",playerId);
                    await conn.OpenAsync ();
                    await cmd.ExecuteNonQueryAsync ();
                }
            }
        
        }

        public async Task<Team> GetTeamByNameAsync (string name) {
            
            return await _context.Teams.FirstOrDefaultAsync(t=>t.TeamName==name);
        }

        Task<IEnumerable<TeamDetails>> IDataRepo.GetTeamByName_withSearchAsync (string name, string search) {
            throw new NotImplementedException ();
        }

        Task<IEnumerable<MatchInfoDtos>> IDataRepo.GetMatchByDatetimeAsync (DateTime date) {
            throw new NotImplementedException ();
        }
        public async Task<Team> UpdateTeamAsync (Team model,string teamName) {
            NpgsqlConnection conn = null;
            var cmdStr = "update team set team_image = @teamimage, stadium_id = @stadium_id where team_name=@teamname;";

            var connStr = DbConnection.connectionString;
            using (conn = new NpgsqlConnection (connStr)) {
                using (NpgsqlCommand cmd = new NpgsqlCommand (cmdStr, conn)) {
        
                    cmd.Parameters.AddWithValue ("@teamimage", model.TeamImage);
                    cmd.Parameters.AddWithValue ("@stadiumid", model.StadiumID);
                    cmd.Parameters.AddWithValue("@teamname",teamName);
                    await conn.OpenAsync ();
                    await cmd.ExecuteNonQueryAsync ();
                }
            }
        var team=await _context.Teams.FirstOrDefaultAsync (t => t.TeamName == teamName);
            return team;

        }

        public async Task CreateStadiumAsync(Stadium model)
        {
            _context.Stadiums.Add(model);
           await _context.SaveChangesAsync();
        }

        // public async Task<IEnumerable<TeamDetails>> GetTeamDetailsByNameAsync(string teamName)
        // {
        //     var connStr = DbConnection.connectionString;
        //     var cmdStr = "select * from team_details where team_name=@name;";
        //     List<TeamDetails> teams = new List<TeamDetails>() ;
        //     using (var conn = new NpgsqlConnection (connStr)) {
        //         using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
        //             cmd.Parameters.AddWithValue ("@name", teamName);

        //             await conn.OpenAsync ();
        //             using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
        //                 while (rd.Read ()) {
        //                     var team = new TeamDetails ();
        //                     team.PlayerID=Convert.ToInt32(rd["player_id"]);
        //                     team.TeamName = rd["team_name"].ToString ();
        //                     team.TeamImage = rd["team_image"].ToString ();
        //                     team.FirstName = rd["first_name"].ToString ();
        //                     team.LastName = rd["last_name"].ToString ();
        //                     team.Position = rd["position"].ToString ();
        //                     team.CountryImage = rd["country_image"].ToString ();
        //                     teams.Add (team);
        //                 }
        //             }

        //         }
        //     }
        //     return teams;
        // }

        public Task<Team> GetTeamByIdAsync(int teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeamDetails>> GetTeamDetailsByNameAsync(string teamName)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "select * from team_details where team_name=@name;";
            List<TeamDetails> teams = new List<TeamDetails>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {
                    cmd.Parameters.AddWithValue ("@name", teamName);

                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            var team = new TeamDetails ();
                            team.PlayerID=Convert.ToInt32(rd["player_id"]);
                            team.TeamName = rd["team_name"].ToString ();
                            team.TeamImage = rd["team_image"].ToString ();
                            team.FirstName = rd["first_name"].ToString ();
                            team.LastName = rd["last_name"].ToString ();
                            team.Position = rd["position"].ToString ();
                            team.CountryImage = rd["country_image"].ToString ();
                            teams.Add (team);
                        }
                    }

                }
                
            }
            return teams;
        }

        public async Task DeletePlayerAsync(int playerId)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "delete from player where player_id=@playerId";
           
            using (var conn = new NpgsqlConnection (connStr)) {
                using(var cmd=new NpgsqlCommand(cmdStr,conn))
                {
                    cmd.Parameters.AddWithValue("@playerId",playerId);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                
        }
    }

        public async Task DeleteTeamAsync(string teamName)
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "delete from team where team_name=@teamName";
           
            using (var conn = new NpgsqlConnection (connStr)) {
                using(var cmd=new NpgsqlCommand(cmdStr,conn))
                {
                    cmd.Parameters.AddWithValue("@teamname",teamName);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                
        }
    }

        public async Task<IEnumerable<RankingDto>> GetRankAsync()
        {
            var connStr = DbConnection.connectionString;
            var cmdStr = "select * from rank_table";

            List<RankingDto> teams = new List<RankingDto>() ;
            using (var conn = new NpgsqlConnection (connStr)) {
                using (var cmd = new NpgsqlCommand (cmdStr, conn)) {

                    await conn.OpenAsync ();
                    using (NpgsqlDataReader rd = await cmd.ExecuteReaderAsync ()) {
                        while (rd.Read ()) {
                            var team = new RankingDto ();
                            team.WinMatch=Convert.ToInt32(rd["win_match"]);
                            team.DrawMatch = rd.GetInt32("draw_match");
                            team.LoseMatch = rd.GetInt32("lose_match");
                            team.WinMatch = rd.GetInt32("win_match");
                            team.TeamName = rd["team_name"].ToString ();
                             team.TeamImage = rd["team_image"].ToString ();
                            team.GoalFor = rd.GetInt32("goal_for");
                            team.GoalAgainst = rd.GetInt32("goal_againt");
                            team.MatchPlayed=rd.GetInt32("played");
                            team.Point=rd.GetInt32("point");
                            teams.Add (team);
                        }
                    }

                }
            }
            return teams;
        }


        // public async Task<Team> GetTeamByIdAsync(int teamId)
        // {
        //     return await _context.Teams.FirstOrDefaultAsync(t=>t.TeamID==teamId);
        // }

    }
}