using System.Runtime.Serialization;
using kahoot_app.Persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kahoot_app.Logic;
public record Options(int optionId, bool isCorrect, string option);
public record Question(string question, List<Options> options);
public class Questions
{
    public List<Question> QuestionsList = new();
    public Questions(string fileName)
    {
        var quizData = new QuizData();
        var rawData = quizData.getDataFromJson(fileName);
        foreach (var item in rawData)
            {
                List<Options> _options = new();
                foreach (var option in item.options)
                {
                    _options.Add(new Options(
                        option.optionId,
                        option.isCorrect,
                        option.option
                    ));
                }

                QuestionsList.Add(new Question(item.question, _options));
            }

    }


    public int GetCorrectAnswer(int questionId)
    {
        var question = QuestionsList[questionId];
        var correctOption = question.options.FirstOrDefault(option => option.isCorrect);
        if (correctOption != null)
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