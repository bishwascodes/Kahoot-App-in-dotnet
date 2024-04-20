namespace kahoot_app.Tests;

using kahoot_app.Logic;
public class QuestionsTests
{
    [Fact]
    public void GetCorrectAnswer_Returns_Correct_Answer_Id()
    {
        // Arrange
        var options = new List<Options>
        {
            new Options(1, false, "Option 1"),
            new Options(2, true, "Option 2"),
            new Options(3, false, "Option 3")
        };
        var questions = new Questions
        {
            QuestionsList = new List<Question>
            {
                new Question("Question 1", options)
            }
        };

        // Act
        var correctAnswer = questions.GetCorrectAnswer(0);

        // Assert
        Assert.Equal(2, correctAnswer);
    }

    [Fact]
    public void GetQuestion_Returns_Question_Text()
    {
        // Arrange
        var options = new List<Options>
        {
            new Options(1, false, "Option 1"),
            new Options(2, true, "Option 2"),
            new Options(3, false, "Option 3")
        };
        var questions = new Questions
        {
            QuestionsList = new List<Question>
            {
                new Question("Question 1", options)
            }
        };

        // Act
        var question = questions.GetQuestion(0);

        // Assert
        Assert.Equal("Question 1", question);
    }

    [Fact]
    public void GetOptions_Returns_Options_List()
    {
        // Arrange
        var options = new List<Options>
        {
            new Options(1, false, "Option 1"),
            new Options(2, true, "Option 2"),
            new Options(3, false, "Option 3")
        };
        var questions = new Questions
        {
            QuestionsList = new List<Question>
            {
                new Question("Question 1", options)
            }
        };

        // Act
        var questionOptions = questions.GetOptions(0);

        // Assert
        Assert.Collection(questionOptions,
            option => Assert.Equal((1, "Option 1"), option),
            option => Assert.Equal((2, "Option 2"), option),
            option => Assert.Equal((3, "Option 3"), option)
        );
    }
}
