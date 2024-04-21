using System.Runtime.Serialization;
using kahoot_app.Persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kahoot_app.Logic;

// REQ#2.2.1
public interface IQuestions
{
    int GetCorrectAnswer(int questionId);
    string GetQuestion(int questionId);
    List<(int, string)> GetOptions(int questionId);
}

// REQ#2.2.1
public class Questions : IQuestions
{
    public List<(string question, List<(int optionId, bool isCorrect, string option)> options)> QuestionsList = new();

    public Questions()
    {
        // Empty Questions
    }

    public Questions(string fileName)
    {
        var quizData = new QuizData();
        QuestionsList = quizData.getDataFromJson(fileName);

    }


    public int GetCorrectAnswer(int questionId)
    {
        var question = QuestionsList[questionId];
        var correctOption = question.options.FirstOrDefault(option => option.isCorrect);
        if (correctOption != default)
        {
            return correctOption.optionId;
        }
        else
        {
            throw new NoCorrectAnswerException();
        }
    }

    public string GetQuestion(int questionId)
    {
        return QuestionsList[questionId].question;
    }

    public List<(int, string)> GetOptions(int questionId)
    {
        List<(int, string)> options = new();
        foreach (var optionItem in QuestionsList[questionId].options)
        {
            options.Add((optionItem.optionId, optionItem.option));
        }
        return options;
    }
}



// Exceptions
[Serializable]
internal class NoCorrectAnswerException : Exception
{
    public NoCorrectAnswerException()
    {
    }

    public NoCorrectAnswerException(string? message) : base(message)
    {
    }

    public NoCorrectAnswerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NoCorrectAnswerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}