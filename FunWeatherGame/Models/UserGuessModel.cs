using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWeatherGame.Models
{
    public class UserGuessModel
    {
        public string UserGuessesJson { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public List<UserGuessItemDto> LstUserGuessItemDto = new List<UserGuessItemDto>();
    }

    public class UserModel
    {
        public string UserName { get; set; }
    }
}
