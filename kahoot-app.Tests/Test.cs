namespace kahoot_app.Tests;

using kahoot_app.Logic;
public class QuestionsTests
{
    // REQ#1.1.1
    [Fact]
    public void User_Can_Create_New_Game_Successfully()
    {
        // Arrange
        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);

        // Act
        quiz.getQuestions();

        // Assert
        Assert.NotNull(quiz.Questions);
    }

    [Fact]
    public void User_Can_Join_Existing_Game_If_Available()
    {
        // Arrange
        var quizName = "Test Quiz";
        var quiz = new Quiz(quizName);
        var playerName = "Test Player";
        var expectedPlayerId = 1; // the first player gets ID 1

        // Act
        var playerId = quiz.Join(playerName);

        // Assert
        Assert.Equal(expectedPlayerId, playerId); // player is added and gets correct ID
        Assert.Single(quiz.Players); // player is added to the list
        Assert.Equal(playerName, quiz.Players[0]?.Name); // correct player name is set
    }
}
