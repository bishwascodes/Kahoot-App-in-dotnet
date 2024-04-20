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
}
