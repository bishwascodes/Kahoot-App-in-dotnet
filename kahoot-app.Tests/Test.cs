namespace kahoot_app.Tests;

using kahoot_app.Logic;
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

}
