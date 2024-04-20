// Bishwas Thapa - CS1410 - Spring 2024 - Final Project
using kahoot_app.Logic;
using kahoot_app.Persistence;


// var test = new QuizData();

// // Call the FindFile method on the instance
// string fileName = "quiz_1.json";

// var result = test.getDataFromJson(fileName);
// Arrange

var quizName = "Test Quiz";
string playerName1 = "Bish";
string playerName2 = "John";
string playerName3 = "Nike";
var quiz = new Quiz(quizName);
quiz.PlayersCanJoin = true;
var playerId1 = quiz.Join(playerName1);
var playerId2 = quiz.Join(playerName2);
var playerId3 = quiz.Join(playerName3);
var Player1 = quiz.Players.FirstOrDefault(player => player?.PlayerId == playerId1);
var Player2 = quiz.Players.FirstOrDefault(player => player?.PlayerId == playerId2);
var Player3 = quiz.Players.FirstOrDefault(player => player?.PlayerId == playerId3);

Player1?.Score.ChangeScore(10);
Player1?.Score.ChangeScore(15);
Player1?.Score.ChangeScore(5);

// Act
var rankList = quiz.GetPlayerRanks();

// Assert
var PlayerRank1 = rankList.FirstOrDefault(rank => rank.playerName == playerName1).rank;
var PlayerRank2 = rankList.FirstOrDefault(rank => rank.playerName == playerName2).rank;
var PlayerRank3 = rankList.FirstOrDefault(rank => rank.playerName == playerName3).rank;

Console.WriteLine("Hello");
