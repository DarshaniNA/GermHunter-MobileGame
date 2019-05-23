using GameLeaderboard.DAL;
using GameLeaderboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLeaderboard.Helpers
{
    public class DataHelper : IDisposable
    {
        private readonly LeaderboardModel _dbContext;

        public DataHelper()
        {
            _dbContext = new LeaderboardModel();
        }

        public DataHelper(LeaderboardModel dbContext)
        {
            _dbContext = dbContext;
        }

        internal PlayerDTO NewPlayer(PlayerDTO newPlayer)
        {
            var tempPlayer = new DAL.Models.Player
            {
                Name = newPlayer.Name,
                Email = newPlayer.Email,
                Age = newPlayer.Age,
                Gender = newPlayer.Gender,
                Username = newPlayer.GamerTag,
                IsActive = newPlayer.IsActive,
                PasswordHash = PasswordHelper.Create(newPlayer.Password)
            };
            _dbContext.Players.Add(tempPlayer);
            _dbContext.SaveChanges();
            newPlayer.Id = tempPlayer.Id;
            return newPlayer;
        }

        internal PlayerDTO Login(LoginDTO login)
        {
            var tempPlayer = _dbContext.Players.Where(x => x.Username == login.Username && PasswordHelper.Validate(x.PasswordHash, login.Password)).FirstOrDefault();
            return new PlayerDTO
            {
                Id = tempPlayer.Id,
                Name = tempPlayer.Name,
                Email = tempPlayer.Email,
                Age = tempPlayer.Age,
                Gender = tempPlayer.Gender,
                GamerTag = tempPlayer.Username,
                IsActive = tempPlayer.IsActive
            };
        }

        internal ScoreDTO NewScore(ScoreDTO newScore)
        {
            var tempScore = new DAL.Models.Score
            {
                LevelId = newScore.LevelId,
                PlayerId = newScore.PlayerId,
                Points = newScore.Points,
                Pickups = newScore.Pickups,
                Time = newScore.Time
            };
            _dbContext.Scores.Add(tempScore);
            _dbContext.SaveChanges();
            newScore.Id = tempScore.Id;
            return newScore;
        }

        internal List<ScoreDTO> GetPlayerScore(int playerId)
        {
            return _dbContext.Scores.Where(x => x.PlayerId == playerId).Select(x => new ScoreDTO
            {
                Id = x.Id,
                PlayerId = x.PlayerId,
                PlayerName = x.Player.Name,
                LevelId = x.LevelId,
                LevelName = x.Level.Name,
                Pickups = x.Pickups,
                Points = x.Points,
                Time = x.Time
            }).ToList();
        }

        internal List<ScoreDTO> GetScore()
        {
            return _dbContext.Scores.Select(x => new ScoreDTO
            {
                Id = x.Id,
                PlayerId = x.PlayerId,
                PlayerName = x.Player.Name,
                LevelId = x.LevelId,
                Pickups = x.Pickups,
                Points = x.Points,
                Time = x.Time
            }).ToList();
        }

        internal List<PlayerDTO> GetPlayers()
        {
            return _dbContext.Players.Select(x => new PlayerDTO
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                Gender = x.Gender,
                GamerTag = x.Username,
                IsActive = x.IsActive
            }).ToList();
        }

        internal PlayerDTO GetPlayer(int playerId)
        {
            var tempPlayer = _dbContext.Players.FirstOrDefault(x => x.Id == playerId);
            if (tempPlayer != null)
            {
                return new PlayerDTO
                {
                    Id = tempPlayer.Id,
                    Name = tempPlayer.Name,
                    Email = tempPlayer.Email,
                    Age = tempPlayer.Age,
                    Gender = tempPlayer.Gender,
                    GamerTag = tempPlayer.Username,
                    IsActive = tempPlayer.IsActive
                };
            }
            else
            {
                return null;
            }
        }

        internal object NewLevel(string levelName)
        {
            var tempLevel = new DAL.Models.Level
            {
                Name = levelName
            };
            _dbContext.Levels.Add(tempLevel);
            _dbContext.SaveChanges();
            return tempLevel;
        }

        internal List<LevelDTO> GetLevels()
        {
            return _dbContext.Levels.Select(x => new LevelDTO { Id = x.Id, Name = x.Name }).ToList();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}