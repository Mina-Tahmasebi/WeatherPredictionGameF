# WeatherPredictionGameF
Front End
This is a simple app based on guesswork.  And anyone who can guess the temperature of the cities better, can set a better record.
 The game is such that the user enters the game, 5 cities are displayed to him that the user must number them according to the guessed-temperature and after clicking the submit, the result will be shown to her.
 All results can be seen on the "AllGameRecord" page.
 - The source of this is written with asp .net core 3.1.
For running ing the game, "Api" s from the backend project have been used.
" ApiCaller" class have been used for calling "Api" s.
The "GameServiceCaller" calls our wanted services with the help of "ApiCaller". Calling them deffers, depending on the kind of "hhtpMethod" .
For Implementation of the "Razor" in this project, 
-UI has been used to communicate with "ajax". Depending on the needs, "Controllers " have been used
