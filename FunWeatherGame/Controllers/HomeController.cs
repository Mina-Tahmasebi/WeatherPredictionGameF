using FunWeatherGame.ApiCaller;
using FunWeatherGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FunWeatherGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GameServiceCaller _gameServiceCaller;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _gameServiceCaller = new GameServiceCaller();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            ViewBag.Message = null;
            if (!string.IsNullOrEmpty(model.UserName))
            {
                return RedirectToAction("StartGame", new { userName = model.UserName }); 
            } else
            {
                ViewBag.Message = "name is empty!";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> StartGame(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserName = userName;
            int gameId = await _gameServiceCaller.InitGame(userName);
            List<CityDto> model =await _gameServiceCaller.GetCitiesByGameId(gameId);
            ViewBag.UserId = await _gameServiceCaller.GetUserIdByGameId(gameId);
            ViewBag.GameId = gameId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetGame(UserGuessModel model)
        {
            model.LstUserGuessItemDto = JsonConvert.DeserializeObject<List<UserGuessItemDto>>(model.UserGuessesJson);
            await _gameServiceCaller.InitUserGuess(model.LstUserGuessItemDto, model.UserId, model.GameId);
            return Json(new { model.GameId, model.UserId });
        }
        [HttpGet]
        public async Task<IActionResult> GameResult(int gameId, int userId)
        {
            GameResultDto result =await _gameServiceCaller.CalculateResultGame(gameId, userId);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> AllRecords()
        {
            List<GameRecordItem> result =await _gameServiceCaller.AllGameRecords();
            return View(result);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
