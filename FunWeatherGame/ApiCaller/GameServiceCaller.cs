using FunWeatherGame.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FunWeatherGame.ApiCaller
{
    public class GameServiceCaller
    {
        private readonly string baseUrl; 
        public GameServiceCaller()
        {
            baseUrl = "https://localhost:44308/";
        }
        internal async Task<int> InitGame(string userName)
        {
            return await ApiCaller.Call<int>(HttpMethod.Post, baseUrl + "weatherforecast/InitGame", new { UserName = userName });
        }

        internal async Task<List<CityDto>> GetCitiesByGameId(int gameId)
        {
            return await ApiCaller.Call<List<CityDto>>(HttpMethod.Get, baseUrl + string.Format("weatherforecast/GetCitiesByGameId?GameId={0}" , gameId));
        }

        internal async Task<int> GetUserIdByGameId(int gameId)
        {
             return await ApiCaller.Call<int>(HttpMethod.Get, baseUrl + string.Format("weatherforecast/GetUserIdByGameId?GameId={0}", gameId));
        }

        internal async Task InitUserGuess(List<UserGuessItemDto> lstUserGuessItemDto, int userId, int gameId)
        {
             await ApiCaller.Call<object>(HttpMethod.Post, baseUrl + "weatherforecast/InitUserGuess", new { GameId = gameId, UserId = userId, LstUserGuessItemDto = lstUserGuessItemDto });
        }

        internal async Task<GameResultDto> CalculateResultGame(int gameId, int userId)
        {
            return await ApiCaller.Call<GameResultDto>(HttpMethod.Post, baseUrl + "weatherforecast/CalculateResultGame", new { GameId = gameId, UserId = userId });
        }

        internal async Task<List<GameRecordItem>> AllGameRecords()
        {
            return await ApiCaller.Call<List<GameRecordItem>>(HttpMethod.Get, baseUrl + "weatherforecast/AllGameRecords");
        }
    }
}
