namespace kahoot_app.Tests;

using kahoot_app.Logic;
using kahoot_app.Persistence;
public class QuestionsTests
{
    // REQ#1.1.1
    [Fact]
    public void User_Can_Create_New_Game_Successfully()
    {

        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);

        var quizNameFromClass = quiz.QuizName;

        Assert.Equal(quizNameFromClass, quizName);
    }

    [Fact]
    public void User_Can_Join_Existing_Game_If_Available()
    {

        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);
        var playerName = "Test Player";

        var playerId = quiz.Join(playerName);
        var noOfPlayers = quiz.Players.Count;

        Assert.Equal(1, noOfPlayers); // Adds to the player list
        Assert.Single(quiz.Players); // player is added to the list
        Assert.Equal(playerName, quiz.Players[0]?.Name); // correct player name is set
    }

    // REQ#1.1.0
    // REQ#1.1.2

    [Fact]
    public void User_Cannot_Create_New_Game_Without_Quiz_Name()
    {
        string quizName = null;
        Quiz quiz = null;


        Assert.ThrowsAny<Exception>(() => new Quiz(null));
    }

    // REQ#1.2.1
    [Fact]
    public void User_Can_Interact_With_Game_Successfully()
    {
        // Arrange
        var quizName = "Test Quiz";
        var playerName = "Test Player";
        var quiz = new Quiz(quizName);
        var playerId = quiz.Join(playerName);

        // Users can Interact and set their name in the game
        Assert.Equal(playerName, quiz.Players.FirstOrDefault(player => player?.PlayerId == playerId).Name);
    }

    // REQ#1.1.0
    //REQ#1.2.2
    [Fact]
    public void User_Cannot_Interact_With_Game_Without_Valid_Data_Inputs()
    {
        // Arrange
        var quizName = "Test Quiz";
        string playerName = null;
        var quiz = new Quiz(quizName);

        // Users cannot pass the null value to set their name 

        Assert.ThrowsAny<Exception>(() => quiz.Join(playerName));
    }

    // REQ#1.1.0
    [Fact]
    public void User_Cannot_Join_After_Start_The_Quiz()
    {
        // Arrange
        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);

        quiz.Start();

        // Once the admin starts the test, user can't join

        Assert.Equal(quiz.PlayersCanJoin, false);
    }

    // REQ#1.1.0
    [Fact]
    public void Current_Question_Number_Is_Set_To_1_On_Start()
    {
        // Arrange
        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);

        quiz.Start();

        // Once the admin starts the test, the current question number becomes 1

        Assert.Equal(quiz.CurrentQuestionNumber, 1);
    }
    // REQ#1.1.0
    [Fact]
    public void Current_Question_Number_Can_be_increaded_by_1()
    {
        // Arrange
        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);

        quiz.Start();
        var after_start = quiz.CurrentQuestionNumber;

        quiz.IncrementCurrentQuestionNumber();

        // Once the admin starts the test, the current question number becomes 1 and we can increment the question number by 1

        Assert.Equal(after_start, 1);
        Assert.Equal(quiz.CurrentQuestionNumber, 2);
    }

    // REQ#1.1.0
    [Fact]
    public void Quiz_Reset_Event_Is_Triggered_When_Game_Is_Over()
    {
        // Arrange
        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);
        var isEventTriggered = false;

        // Subscribe to the QuizReset event and set IsQuizOver to true
        quiz.QuizReset += () => isEventTriggered = true;



        // Act
        // ending the game
        quiz.EndQuiz();

        // Assert
        Assert.True(isEventTriggered); // Ensure that the QuizReset event is triggered when the game is reset
    }

    // REQ#1.1.0
    [Fact]
    public void Quiz_State_Changed_Event_Is_Triggered_When_Game_Is_Started()
    {
        // Arrange
        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);
        var isEventTriggered = false;

        // Subscribe to the QuizReset event and set IsQuizOver to true
        quiz.QuizStateChanged += () => isEventTriggered = true;



        // Act
        // ending the game
        quiz.Start();

        // Assert
        Assert.True(isEventTriggered); // Ensure that the QuizReset event is triggered when the game is reset
    }

    // REQ#1.1.0
    [Fact]
    public void Player_Score_Increase_Works()
    {
        // Arrange
        var quizName = "Test Quiz";
        string playerName = "Bish";
        var quiz = new Quiz(quizName);
        quiz.PlayersCanJoin = true;
        var playerId = quiz.Join(playerName);
        var currentPlayer = quiz.Players.FirstOrDefault(player => player?.PlayerId == playerId);

        var startScore = currentPlayer?.Score.Value;
        currentPlayer?.Score.ChangeScore(10);
        var secondScore = currentPlayer?.Score.Value;

        Assert.Equal(startScore, 0);
        Assert.Equal(secondScore, 10);
    }

    // REQ#1.1.0
    [Fact]
    public void Player_Ranking_System_Works()
    {
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
        var Player1 = quiz.Players.FirstOrDefault(player => player.PlayerId == playerId1);
        var Player2 = quiz.Players.FirstOrDefault(player => player.PlayerId == playerId2);
        var Player3 = quiz.Players.FirstOrDefault(player => player.PlayerId == playerId3);

        Player1?.Score.ChangeScore(10);
        Player2?.Score.ChangeScore(15);
        Player3?.Score.ChangeScore(5);

        // Act
        var rankList = quiz.GetPlayerRanks();

        // Assert
        var PlayerRank1 = rankList.FirstOrDefault(rank => rank.playerName == playerName1).rank;
        var PlayerRank2 = rankList.FirstOrDefault(rank => rank.playerName == playerName2).rank;
        var PlayerRank3 = rankList.FirstOrDefault(rank => rank.playerName == playerName3).rank;

        Assert.Equal(2, PlayerRank1); // Player 1's rank is 2
        Assert.Equal(1, PlayerRank2); // Player 2's rank is 1
        Assert.Equal(3, PlayerRank3); // Player 3's rank is 3
    }

    // REQ#1.1.0
    [Fact]
    public void Leaderboard_Is_Upto_Date()
    {
        // Arrange
       
        var playerData = new List<(string playerName, int rank, int score)>
        {
            ("Player1", 1, 100),
            ("Player2", 2, 90),
            ("Player3", 3, 80),
            ("Player4", 4, 70),
            ("Player5", 5, 60),
            ("Player6", 6, 50),
            ("Player7", 7, 40),
            ("Player8", 8, 30),
            ("Player9", 9, 20),
            ("Player10", 10, 10)
        };
        // REQ#2.3.1
        Leaderboard.UpdateLeaderboard(playerData);
         var NewPlayerData = new List<(string playerName, int rank, int score)>
        {
            ("Player1", 1, 101),
            ("Player2", 2, 90),
            ("Player3", 3, 80),
            ("Player4", 4, 70),
            ("Player5", 5, 60),
            ("Player6", 6, 50),
            ("Player7", 7, 40),
            ("Player8", 8, 30),
            ("Player9", 9, 20),
            ("Player11", 10, 20)
        };

        // Act
        //REQ#2.3.1

        Leaderboard.UpdateLeaderboard(NewPlayerData);

        // Assert
        var expectedLeaderboard = new List<(int, string, int)>
        {
            (1, "Player1", 101),
            (2, "Player2", 90),
            (3, "Player3", 80),
            (4, "Player4", 70),
            (5, "Player5", 60),
            (6, "Player6", 50),
            (7, "Player7", 40),
            (8, "Player8", 30),
            (9, "Player9", 20),
            (10, "Player11", 20)
        };

        Assert.Equal(expectedLeaderboard, Leaderboard.LeaderboardPlayers);
    }

    // REQ#1.1.0
    [Fact]
    public void GetQuestion_Returns_Correct_Question()
    {
        // Arrange
        var questions = new Questions();
        questions.QuestionsList = new List<(string, List<(int, bool, string)>)>
        {
            ("What is the capital of France?", new List<(int, bool, string)>
                {
                    (1, false, "Berlin"),
                    (2, false, "Madrid"),
                    (3, true, "Paris"),
                    (4, false, "Rome")
                }
            ),
            ("What is the largest mammal?", new List<(int, bool, string)>
                {
                    (1, false, "Lion"),
                    (2, false, "Elephant"),
                    (3, true, "Blue Whale"),
                    (4, false, "Giraffe")
                }
            )
        };

        // Act
        var question = questions.GetQuestion(1); // Getting the second question

        // Assert
        Assert.Equal("What is the largest mammal?", question);
    }

}
